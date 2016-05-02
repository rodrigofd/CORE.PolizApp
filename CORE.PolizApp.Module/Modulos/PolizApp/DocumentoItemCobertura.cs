using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.DocumentoItemCobertura")]
    public class DocumentoItemCobertura : BasicObject
    {
        private Cobertura _fCobertura;
        private string _fCoberturaArea;
        private CoberturaTipo _fCoberturaTipo;
        private string _fDeducible;
        private DocumentoItem _fDocumentoItem;
        private decimal _fIva;
        private decimal _fIvaTasa;
        private string _fNota;
        private int _fOrden;
        private decimal _fPremio;
        private decimal _fPrima;
        private decimal _fSumaAsegurada;
        private decimal _fTasaRiesgo;
        private int _fTasaRiesgoUm;

        public DocumentoItemCobertura(Session session) : base(session)
        {
        }

        [Association(@"DocumentoItemCoberturaReferencesDocumentoItem")]
        public DocumentoItem DocumentoItem
        {
            get { return _fDocumentoItem; }
            set { SetPropertyValue("DocumentoItem", ref _fDocumentoItem, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }

        [Association(@"DocumentoItemCoberturaReferencesCoberturaTipo")]
        public CoberturaTipo CoberturaTipo
        {
            get { return _fCoberturaTipo; }
            set { SetPropertyValue("CoberturaTipo", ref _fCoberturaTipo, value); }
        }

        [Association(@"DocumentoItemCoberturaReferencesCobertura")]
        public Cobertura Cobertura
        {
            get { return _fCobertura; }
            set { SetPropertyValue("Cobertura", ref _fCobertura, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string CoberturaArea
        {
            get { return _fCoberturaArea; }
            set { SetPropertyValue("CoberturaArea", ref _fCoberturaArea, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Deducible
        {
            get { return _fDeducible; }
            set { SetPropertyValue("Deducible", ref _fDeducible, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Nota
        {
            get { return _fNota; }
            set { SetPropertyValue("Nota", ref _fNota, value); }
        }

        public decimal SumaAsegurada
        {
            get { return _fSumaAsegurada; }
            set { SetPropertyValue<decimal>("SumaAsegurada", ref _fSumaAsegurada, value); }
        }

        public decimal TasaRiesgo
        {
            get { return _fTasaRiesgo; }
            set { SetPropertyValue<decimal>("TasaRiesgo", ref _fTasaRiesgo, value); }
        }

        public int TasaRiesgoUm
        {
            get { return _fTasaRiesgoUm; }
            set { SetPropertyValue<int>("TasaRiesgoUM", ref _fTasaRiesgoUm, value); }
        }

        public decimal Prima
        {
            get { return _fPrima; }
            set { SetPropertyValue<decimal>("Prima", ref _fPrima, value); }
        }

        public decimal IvaTasa
        {
            get { return _fIvaTasa; }
            set { SetPropertyValue<decimal>("IvaTasa", ref _fIvaTasa, value); }
        }

        public decimal Iva
        {
            get { return _fIva; }
            set { SetPropertyValue<decimal>("Iva", ref _fIva, value); }
        }

        //TODO: es computed. arreglar
        public decimal Premio
        {
            get { return _fPremio; }
            set { SetPropertyValue<decimal>("Premio", ref _fPremio, value); }
        }
    }
}