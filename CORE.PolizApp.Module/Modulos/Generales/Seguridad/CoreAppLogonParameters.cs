using System;
using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Seguridad
{
    [NonPersistent]
    [ModelDefault("Caption", "Log On")]
    public class CoreAppLogonParameters : ICustomObjectSerialize, ISupportResetLogonParameters
    {
        private Empresa _loginEmpresa;
        private string _loginGrupoCodigo;
        private string _loginUserName;

        private XPCollection<Empresa> _seleccionEmpresa;

        [Browsable(false)] public int EmpresaActualId = -1;

        [Browsable(false)] public int GrupoActualId = -1;

        [Browsable(false)] public Guid UsuarioActualId = Guid.Empty;

        [Browsable(false)]
        public IObjectSpace ObjectSpace { get; set; }

        [Browsable(false)]
        [CollectionOperationSet(AllowAdd = false)]
        public XPCollection<Empresa> SeleccionEmpresa
        {
            get
            {
                if (_seleccionEmpresa == null)
                {
                    var empresas = (XPCollection<Empresa>) ObjectSpace.GetObjects<Empresa>();
                    _seleccionEmpresa = empresas;
                    _seleccionEmpresa.Criteria = CriteriaOperator.Parse("1 = 0");
                    _seleccionEmpresa.BindingBehavior = CollectionBindingBehavior.AllowNone;
                }
                return _seleccionEmpresa;
            }
        }

        public static CoreAppLogonParameters Instance => (CoreAppLogonParameters) SecuritySystem.LogonParameters;

        void ICustomObjectSerialize.ReadPropertyValues(SettingsStorage storage)
        {
            if (!string.IsNullOrWhiteSpace(storage.LoadOption("", "UserName")))
                LoginUserName = storage.LoadOption("", "UserName");
            if (!string.IsNullOrWhiteSpace(storage.LoadOption("", "IdGrupo")))
            {
                var grupo = ObjectSpace.FindObject<Grupo>(new BinaryOperator("Oid", storage.LoadOption("", "IdGrupo")));
                LoginGrupoCodigo = grupo == null ? "" : grupo.Codigo;

                if (!string.IsNullOrWhiteSpace(storage.LoadOption("", "IdEmpresa")))
                {
                    var empresa = SeleccionEmpresa.Lookup(Convert.ToInt32(storage.LoadOption("", "IdEmpresa")));
                    LoginEmpresa = empresa;
                }
            }
        }

        void ICustomObjectSerialize.WritePropertyValues(SettingsStorage storage)
        {
            storage.SaveOption("", "UserName", LoginUserName);
            if (GrupoActualId != -1)
                storage.SaveOption("", "IdGrupo", GrupoActualId.ToString());
            if (EmpresaActualId != -1)
                storage.SaveOption("", "IdEmpresa", EmpresaActualId.ToString());
        }

        void ISupportResetLogonParameters.Reset()
        {
            if (ObjectSpace != null)
            {
                ObjectSpace.Dispose();
                ObjectSpace = null;
            }

            LoginUserName = null;
            LoginGrupoCodigo = null;
            LoginEmpresa = null;
            Password = null;

            _seleccionEmpresa = null;
        }

        public Usuario UsuarioActual()
        {
            return UsuarioActual(ObjectSpace);
        }

        public Usuario UsuarioActual(Session session)
        {
            return UsuarioActualId == Guid.Empty || session == null
                ? null
                : session.GetObjectByKey<Usuario>(UsuarioActualId);
        }

        public Usuario UsuarioActual(IObjectSpace objSpace)
        {
            return UsuarioActualId == Guid.Empty || objSpace == null
                ? null
                : objSpace.GetObjectByKey<Usuario>(UsuarioActualId);
        }

        public Empresa EmpresaActual()
        {
            return EmpresaActual(ObjectSpace);
        }

        public Empresa EmpresaActual(Session session)
        {
            return EmpresaActualId == -1 || session == null ? null : session.GetObjectByKey<Empresa>(EmpresaActualId);
        }

        public Empresa EmpresaActual(IObjectSpace objSpace)
        {
            return EmpresaActualId == -1 || objSpace == null ? null : objSpace.GetObjectByKey<Empresa>(EmpresaActualId);
        }

        public XPCollection<Empresa> EmpresasParaUsuarioActual(IObjectSpace objSpace)
        {
            var empresas = (XPCollection<Empresa>) objSpace.GetObjects<Empresa>();
            empresas.BindingBehavior = CollectionBindingBehavior.AllowNone;
            filtrarEmpresasDelGrupoYUsuario(empresas, GrupoActual(objSpace), UsuarioActual(objSpace));
            return empresas;
        }

        private void filtrarEmpresasDelGrupoYUsuario(XPCollection<Empresa> empresas, Grupo grupo, Usuario usuario)
        {
            //TODO: estamos filtrando empresas del grupo actual, pero no las del usuario actual (las permitidas)
            empresas.Criteria = usuario == null || grupo == null
                ? new BinaryOperator("Oid", -1)
                : new BinaryOperator("Persona.Grupo.Oid", grupo.Oid);
        }

        #region Campos de la pantalla login

        [ImmediatePostData]
        [Index(0)]
        public string LoginUserName
        {
            get { return _loginUserName; }
            set
            {
                _loginUserName = value;
                var usuario = ObjectSpace.FindObject<Usuario>(new BinaryOperator("UserName", _loginUserName));
                UsuarioActualId = usuario == null ? Guid.Empty : usuario.Oid;

                filtrarEmpresasDelGrupoYUsuario(SeleccionEmpresa, GrupoActual(), UsuarioActual());
            }
        }

        [ImmediatePostData]
        [Index(1)]
        public string LoginGrupoCodigo
        {
            get { return _loginGrupoCodigo; }
            set
            {
                _loginGrupoCodigo = value;
                var grupo = ObjectSpace.FindObject<Grupo>(new BinaryOperator("Codigo", value));
                GrupoActualId = grupo == null ? -1 : grupo.Oid;

                filtrarEmpresasDelGrupoYUsuario(SeleccionEmpresa, GrupoActual(), UsuarioActual());
            }
        }

        [DataSourceProperty("SeleccionEmpresa")]
        [Index(2)]
        public Empresa LoginEmpresa
        {
            get { return _loginEmpresa; }
            set
            {
                _loginEmpresa = value;
                EmpresaActualId = value == null ? -1 : value.Oid;
            }
        }

        [PasswordPropertyText(true)]
        [Index(2)]
        public string Password { get; set; }

        #endregion
    }
}