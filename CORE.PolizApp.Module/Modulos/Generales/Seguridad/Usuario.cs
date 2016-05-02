using CORE.PolizApp.Personas;
using CORE.PolizApp.Regionales;
using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Seguridad
{
    [Persistent(@"seguridad.Usuario")]
    [System.ComponentModel.DisplayName("Usuario del sistema")]
    [DefaultClassOptions]
public class Usuario : SecuritySystemUser
    {
        private PaisIdioma _fCulturaPredeterminada;
        private Identificacion _fEmailIdentificacion;
        private Empresa _fEmpresaPredeterminada;
        private Idioma _fIdiomaPredeterminado;
        private Persona _fPersona;

        public Usuario(Session session) :
            base(session)
        {
        }

        [ImmediatePostData]
        public Persona Persona
        {
            get { return _fPersona; }
            set { SetPropertyValue("Persona", ref _fPersona, value); }
        }

        [DataSourceProperty("Persona.Identificaciones")]
        [System.ComponentModel.DisplayName("E-Mail primario del usuario")]
        public Identificacion EmailIdentificacion
        {
            get { return _fEmailIdentificacion; }
            set { SetPropertyValue("EmailIdentificacion", ref _fEmailIdentificacion, value); }
        }

        [DataSourceProperty("EmpresasHabilitadas")]
        public Empresa EmpresaPredeterminada
        {
            get { return _fEmpresaPredeterminada; }
            set { SetPropertyValue("EmpresaPredeterminada", ref _fEmpresaPredeterminada, value); }
        }

        public Idioma IdiomaPredeterminado
        {
            get { return _fIdiomaPredeterminado; }
            set { SetPropertyValue("IdiomaPredeterminado", ref _fIdiomaPredeterminado, value); }
        }

        public PaisIdioma CulturaPredeterminada
        {
            get { return _fCulturaPredeterminada; }
            set { SetPropertyValue("CulturaPredeterminada", ref _fCulturaPredeterminada, value); }
        }

        [Association(@"seguridad.UsuarioEmpresa", typeof (Empresa), UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Empresa> EmpresasHabilitadas => GetCollection<Empresa>("EmpresasHabilitadas");
    }
}