using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Contabilidad
{
    [Persistent("contabilidad.CuentaRubro")]
    [DefaultProperty("Descripcion")]
    [System.ComponentModel.DisplayName("Rubro de cuenta contable")]
    //[DefaultClassOptions]
    [DefaultClassOptions]
public class CuentaRubro : BasicObject
    {
        private bool _fActiva;
        private CuentaClase _fClase;
        private string _fCodigo;
        private Empresa _fEmpresa;
        private string _fNombre;

        public CuentaRubro(Session session) : base(session)
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
            set { SetPropertyValue("Descripcion", ref _fNombre, value); }
        }

        public CuentaClase Clase
        {
            get { return _fClase; }
            set { SetPropertyValue("Clase", ref _fClase, value); }
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
    }
}