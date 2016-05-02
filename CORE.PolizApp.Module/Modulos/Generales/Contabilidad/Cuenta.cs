using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using FDIT.Core.Sistema;

namespace CORE.PolizApp.Contabilidad
{
    [Persistent(@"contabilidad.Cuenta")]
    //[DefaultClassOptions]
    [DefaultProperty("Descripcion")]
    [System.ComponentModel.DisplayName("Cuenta contable")]
    [DefaultClassOptions]
public class Cuenta : BasicObject, IObjetoPorEmpresa, ITreeNode
    {
        private bool _fActiva;
        private string _fCodigo;
        private Cuenta _fCuentaPadre;
        private CuentaRubro _fCuentaRubro;
        private Empresa _fEmpresa;
        private string _fNombre;

        public Cuenta(Session session) : base(session)
        {
        }

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [VisibleInLookupListView(false)]
        [PersistentAlias("ISNULL(Codigo, '') + ' - ' + Nombre")]
        public string Descripcion => Convert.ToString(EvaluateAlias("Descripcion"));

        [Size(50)]
        [Index(0)]
        [VisibleInLookupListView(true)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Association]
        public Cuenta CuentaPadre
        {
            get { return _fCuentaPadre; }
            set { SetPropertyValue("CuentaPadre", ref _fCuentaPadre, value); }
        }

        [Association]
        public XPCollection<Cuenta> CuentasHijas => GetCollection<Cuenta>("CuentasHijas");

        public CuentaRubro CuentaRubro
        {
            get { return _fCuentaRubro; }
            set { SetPropertyValue("CuentaRubro", ref _fCuentaRubro, value); }
        }

        public bool Activa
        {
            get { return _fActiva; }
            set { SetPropertyValue("Activa", ref _fActiva, value); }
        }

        [Browsable(false)]
        public Empresa Empresa
        {
            get { return _fEmpresa; }
            set { SetPropertyValue("Empresa", ref _fEmpresa, value); }
        }

        string ITreeNode.Name => Descripcion;

        [Browsable(false)]
        ITreeNode ITreeNode.Parent => CuentaPadre;

        [Browsable(false)]
        IBindingList ITreeNode.Children => CuentasHijas;

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}