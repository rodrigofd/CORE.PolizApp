using System.ComponentModel;
using CORE.PolizApp.Contabilidad;
using CORE.PolizApp.Impuestos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Gestion
{
    [Persistent(@"gestion.Concepto")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Concepto de facturación")]
    public class Concepto : BasicObject
    {
        private bool fAbreCentrosCosto;
        private bool fActivo;
        private bool fAutomatico;
        private ConceptoClase fClase;
        private string fCodigo;
        private string fCodigoLegal;
        private bool fCompra;
        private Cuenta fCuentaContable;
        private bool fDetallaCantidad;
        private bool fEsIndice;
        private ConceptoGrupoFacturacion fGrupoFacturacion;
        private ImpuestoTipo fImpuestoTipoIVA;
        private string fNombre;
        private Regimen fRegimen;
        private decimal fValor;
        private string fValorFormula;
        private decimal fValorMaximo;
        private decimal fValorMinimo;
        private string fValorNotas;
        private int fValorRedondeo;
        private bool fVenta;

        public Concepto(Session session) : base(session)
        {
        }

        [Size(50)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(50)]
        public string CodigoLegal
        {
            get { return fCodigoLegal; }
            set { SetPropertyValue("CodigoLegal", ref fCodigoLegal, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [Index(1)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [Association(@"ConceptosReferencesConceptosClases")]
        public ConceptoClase Clase
        {
            get { return fClase; }
            set { SetPropertyValue("Clase", ref fClase, value); }
        }

        [Association(@"ConceptosReferencesimpuestos_ImpuestoTipo")]
        public ImpuestoTipo ImpuestoTipoIVA
        {
            get { return fImpuestoTipoIVA; }
            set { SetPropertyValue("ImpuestoTipoIVA", ref fImpuestoTipoIVA, value); }
        }

        public bool DetallaCantidad
        {
            get { return fDetallaCantidad; }
            set { SetPropertyValue("DetallaCantidad", ref fDetallaCantidad, value); }
        }

        public bool Automatico
        {
            get { return fAutomatico; }
            set { SetPropertyValue("Automatico", ref fAutomatico, value); }
        }

        public Regimen Regimen
        {
            get { return fRegimen; }
            set { SetPropertyValue("Regimen", ref fRegimen, value); }
        }

        [Association(@"ConceptosReferencesConceptosGruposFacturacion")]
        public ConceptoGrupoFacturacion GrupoFacturacion
        {
            get { return fGrupoFacturacion; }
            set { SetPropertyValue("GrupoFacturacion", ref fGrupoFacturacion, value); }
        }

        public bool AbreCentrosCosto
        {
            get { return fAbreCentrosCosto; }
            set { SetPropertyValue("AbreCentrosCosto", ref fAbreCentrosCosto, value); }
        }

        public Cuenta CuentaContable
        {
            get { return fCuentaContable; }
            set { SetPropertyValue("CuentaContable", ref fCuentaContable, value); }
        }

        public bool EsIndice
        {
            get { return fEsIndice; }
            set { SetPropertyValue("EsIndice", ref fEsIndice, value); }
        }

        public decimal Valor
        {
            get { return fValor; }
            set { SetPropertyValue<decimal>("Valor", ref fValor, value); }
        }

        public decimal ValorMinimo
        {
            get { return fValorMinimo; }
            set { SetPropertyValue<decimal>("ValorMinimo", ref fValorMinimo, value); }
        }

        public decimal ValorMaximo
        {
            get { return fValorMaximo; }
            set { SetPropertyValue<decimal>("ValorMaximo", ref fValorMaximo, value); }
        }

        public int ValorRedondeo
        {
            get { return fValorRedondeo; }
            set { SetPropertyValue<int>("ValorRedondeo", ref fValorRedondeo, value); }
        }

        public string ValorFormula
        {
            get { return fValorFormula; }
            set { SetPropertyValue("ValorFormula", ref fValorFormula, value); }
        }

        public string ValorNotas
        {
            get { return fValorNotas; }
            set { SetPropertyValue("ValorNotas", ref fValorNotas, value); }
        }

        public bool Activo
        {
            get { return fActivo; }
            set { SetPropertyValue("Activo", ref fActivo, value); }
        }

        public bool Compra
        {
            get { return fCompra; }
            set { SetPropertyValue("Compra", ref fCompra, value); }
        }

        public bool Venta
        {
            get { return fVenta; }
            set { SetPropertyValue("Venta", ref fVenta, value); }
        }
    }
}