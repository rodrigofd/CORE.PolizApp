using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.Cobertura")]
    public class Cobertura : BasicObject
    {
        private int _fCoberturaTipoPredeterminada;
        private string _fCodigo;
        private bool _fIva;
        private decimal _fIva1Tasa;
        private string _fNombre;
        private int _fOrden;
        private Ramo _fRamo;
        private TasaRiesgoUm _fTasaRiesgoUm;

        public Cobertura(Session session) : base(session)
        {
        }

        //[Association(@"CoberturaReferencesRamo")]
        public Ramo Ramo
        {
            get { return _fRamo; }
            set { SetPropertyValue("Ramo", ref _fRamo, value); }
        }

        public int CoberturaTipoPredeterminada
        {
            get { return _fCoberturaTipoPredeterminada; }
            set { SetPropertyValue<int>("CoberturaTipoPredeterminada", ref _fCoberturaTipoPredeterminada, value); }
        }

        [Size(50)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        public bool Iva
        {
            get { return _fIva; }
            set { SetPropertyValue("Iva", ref _fIva, value); }
        }

        public decimal Iva1Tasa
        {
            get { return _fIva1Tasa; }
            set { SetPropertyValue<decimal>("Iva1Tasa", ref _fIva1Tasa, value); }
        }

        [Association(@"CoberturaReferencesTasaRiesgoUM")]
        public TasaRiesgoUm TasaRiesgoUm
        {
            get { return _fTasaRiesgoUm; }
            set { SetPropertyValue("TasaRiesgoUM", ref _fTasaRiesgoUm, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }

        [Association(@"CoberturaPlanReferencesCobertura")]
        public XPCollection<CoberturaPlan> Planes => GetCollection<CoberturaPlan>("Planes");

        [Association(@"DocumentoItemCoberturaReferencesCobertura")]
        public XPCollection<DocumentoItemCobertura> DocumentoItemCoberturas => GetCollection<DocumentoItemCobertura>("DocumentoItemCoberturas");
    }
}