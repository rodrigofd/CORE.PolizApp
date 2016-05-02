using System.ComponentModel;
using CORE.PolizApp.Contabilidad;
using CORE.PolizApp.Impuestos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Gestion
{
    [Persistent(@"gestion.Concepto")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Concepto de facturación")]
    [DefaultClassOptions]
public class Concepto : BasicObject
    {
        private bool _fAbreCentrosCosto;
        private bool _fActivo;
        private bool _fAutomatico;
        private ConceptoClase _fClase;
        private string _fCodigo;
        private string _fCodigoLegal;
        private bool _fCompra;
        private Cuenta _fCuentaContable;
        private bool _fDetallaCantidad;
        private bool _fEsIndice;
        private ConceptoGrupoFacturacion _fGrupoFacturacion;
        private ImpuestoTipo _fImpuestoTipoIVA;
        private string _fNombre;
        private Regimen _fRegimen;
        private decimal _fValor;
        private string _fValorFormula;
        private decimal _fValorMaximo;
        private decimal _fValorMinimo;
        private string _fValorNotas;
        private int _fValorRedondeo;
        private bool _fVenta;

        public Concepto(Session session) : base(session)
        {
        }

        [Size(50)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(50)]
        public string CodigoLegal
        {
            get { return _fCodigoLegal; }
            set { SetPropertyValue("CodigoLegal", ref _fCodigoLegal, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [Index(1)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Association(@"ConceptosReferencesConceptosClases")]
        public ConceptoClase Clase
        {
            get { return _fClase; }
            set { SetPropertyValue("Clase", ref _fClase, value); }
        }

        [Association(@"ConceptosReferencesimpuestos_ImpuestoTipo")]
        public ImpuestoTipo ImpuestoTipoIVA
        {
            get { return _fImpuestoTipoIVA; }
            set { SetPropertyValue("ImpuestoTipoIVA", ref _fImpuestoTipoIVA, value); }
        }

        public bool DetallaCantidad
        {
            get { return _fDetallaCantidad; }
            set { SetPropertyValue("DetallaCantidad", ref _fDetallaCantidad, value); }
        }

        public bool Automatico
        {
            get { return _fAutomatico; }
            set { SetPropertyValue("Automatico", ref _fAutomatico, value); }
        }

        public Regimen Regimen
        {
            get { return _fRegimen; }
            set { SetPropertyValue("Regimen", ref _fRegimen, value); }
        }

        [Association(@"ConceptosReferencesConceptosGruposFacturacion")]
        public ConceptoGrupoFacturacion GrupoFacturacion
        {
            get { return _fGrupoFacturacion; }
            set { SetPropertyValue("GrupoFacturacion", ref _fGrupoFacturacion, value); }
        }

        public bool AbreCentrosCosto
        {
            get { return _fAbreCentrosCosto; }
            set { SetPropertyValue("AbreCentrosCosto", ref _fAbreCentrosCosto, value); }
        }

        public Cuenta CuentaContable
        {
            get { return _fCuentaContable; }
            set { SetPropertyValue("CuentaContable", ref _fCuentaContable, value); }
        }

        public bool EsIndice
        {
            get { return _fEsIndice; }
            set { SetPropertyValue("EsIndice", ref _fEsIndice, value); }
        }

        public decimal Valor
        {
            get { return _fValor; }
            set { SetPropertyValue<decimal>("Valor", ref _fValor, value); }
        }

        public decimal ValorMinimo
        {
            get { return _fValorMinimo; }
            set { SetPropertyValue<decimal>("ValorMinimo", ref _fValorMinimo, value); }
        }

        public decimal ValorMaximo
        {
            get { return _fValorMaximo; }
            set { SetPropertyValue<decimal>("ValorMaximo", ref _fValorMaximo, value); }
        }

        public int ValorRedondeo
        {
            get { return _fValorRedondeo; }
            set { SetPropertyValue<int>("ValorRedondeo", ref _fValorRedondeo, value); }
        }

        public string ValorFormula
        {
            get { return _fValorFormula; }
            set { SetPropertyValue("ValorFormula", ref _fValorFormula, value); }
        }

        public string ValorNotas
        {
            get { return _fValorNotas; }
            set { SetPropertyValue("ValorNotas", ref _fValorNotas, value); }
        }

        public bool Activo
        {
            get { return _fActivo; }
            set { SetPropertyValue("Activo", ref _fActivo, value); }
        }

        public bool Compra
        {
            get { return _fCompra; }
            set { SetPropertyValue("Compra", ref _fCompra, value); }
        }

        public bool Venta
        {
            get { return _fVenta; }
            set { SetPropertyValue("Venta", ref _fVenta, value); }
        }
    }
}