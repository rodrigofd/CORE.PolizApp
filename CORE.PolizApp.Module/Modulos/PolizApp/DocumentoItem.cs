using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.DocumentoItem")]
    public class DocumentoItem : BasicObject
    {
        private string _fBeneficios;
        private string _fCobertura;
        private bool _fCoberturaApertura;
        private string _fCoberturaArea;
        private string _fDeducible; 
        private Documento _fDocumento;
        private DocumentoItemTipo _tipo;
        private int _fInfoautoID;
        private decimal _fIva;
        private decimal _fIvaTasa;
        private string _fMateriaAsegurada;
        private string _fMateriaAseguradaUbicacion;
        private string _fMinuta;
        private int _fNegocioRamoPlan;
        private string _fNota;
        private int _fNumero;
        private string _fNumeroAseguradora;
        private decimal _fPremio;
        private decimal _fPrimaGravada;
        private decimal _fPrimaNoGravada;
        private decimal _fSumaAsegurada;
        private bool _fVehiculo0Km;
        private int _fVehiculoAño;
        private string _fVehiculoCaracteristica;
        private string _fVehiculoChasis;
        private VehiculoMarca _fVehiculoMarca;
        private string _fVehiculoMarcaOtra;
        private VehiculoModelo _fVehiculoModelo;
        private string _fVehiculoModeloOtro;
        private string _fVehiculoMotor;
        private string _fVehiculoPatente;
        private VehiculoTipo _fVehiculoTipo;
        private VehiculoUso _fVehiculoUso;

        public DocumentoItem(Session session) : base(session)
        {
        }

        [Association(@"DocumentoItemReferencesDocumento")]
        public Documento Documento
        {
            get { return _fDocumento; }
            set { SetPropertyValue("Documento", ref _fDocumento, value); }
        }

        [Association(@"DocumentoItemReferencesDocumentoItemTipo")]
        [Persistent(@"DocumentoItemTipo")]
        public DocumentoItemTipo Tipo
        {
            get { return _tipo; }
            set { SetPropertyValue("Tipo", ref _tipo, value); }
        }

        public int Numero
        {
            get { return _fNumero; }
            set { SetPropertyValue<int>("Numero", ref _fNumero, value); }
        }

        [Size(50)]
        public string NumeroAseguradora
        {
            get { return _fNumeroAseguradora; }
            set { SetPropertyValue("NumeroAseguradora", ref _fNumeroAseguradora, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string MateriaAsegurada
        {
            get { return _fMateriaAsegurada; }
            set { SetPropertyValue("MateriaAsegurada", ref _fMateriaAsegurada, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string MateriaAseguradaUbicacion
        {
            get { return _fMateriaAseguradaUbicacion; }
            set { SetPropertyValue("MateriaAseguradaUbicacion", ref _fMateriaAseguradaUbicacion, value); }
        }

        //TODO: FK falta?
        public int NegocioRamoPlan
        {
            get { return _fNegocioRamoPlan; }
            set { SetPropertyValue<int>("NegocioRamoPlan", ref _fNegocioRamoPlan, value); }
        }

        public bool CoberturaApertura
        {
            get { return _fCoberturaApertura; }
            set { SetPropertyValue("CoberturaApertura", ref _fCoberturaApertura, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Cobertura
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
        public string Beneficios
        {
            get { return _fBeneficios; }
            set { SetPropertyValue("Beneficios", ref _fBeneficios, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Minuta
        {
            get { return _fMinuta; }
            set { SetPropertyValue("Minuta", ref _fMinuta, value); }
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

        public decimal PrimaGravada
        {
            get { return _fPrimaGravada; }
            set { SetPropertyValue<decimal>("PrimaGravada", ref _fPrimaGravada, value); }
        }

        public decimal PrimaNoGravada
        {
            get { return _fPrimaNoGravada; }
            set { SetPropertyValue<decimal>("PrimaNoGravada", ref _fPrimaNoGravada, value); }
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

        public decimal Premio
        {
            get { return _fPremio; }
            set { SetPropertyValue<decimal>("Premio", ref _fPremio, value); }
        }

        public int InfoautoID
        {
            get { return _fInfoautoID; }
            set { SetPropertyValue<int>("InfoautoID", ref _fInfoautoID, value); }
        }

        [Association(@"DocumentoItemReferencesVehiculoTipo")]
        public VehiculoTipo VehiculoTipo
        {
            get { return _fVehiculoTipo; }
            set { SetPropertyValue("VehiculoTipo", ref _fVehiculoTipo, value); }
        }

        [Association(@"DocumentoItemReferencesVehiculoMarca")]
        public VehiculoMarca VehiculoMarca
        {
            get { return _fVehiculoMarca; }
            set { SetPropertyValue("VehiculoMarca", ref _fVehiculoMarca, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string VehiculoMarcaOtra
        {
            get { return _fVehiculoMarcaOtra; }
            set { SetPropertyValue("VehiculoMarcaOtra", ref _fVehiculoMarcaOtra, value); }
        }

        [Association(@"DocumentoItemReferencesVehiculoModelo")]
        public VehiculoModelo VehiculoModelo
        {
            get { return _fVehiculoModelo; }
            set { SetPropertyValue("VehiculoModelo", ref _fVehiculoModelo, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string VehiculoModeloOtro
        {
            get { return _fVehiculoModeloOtro; }
            set { SetPropertyValue("VehiculoModeloOtro", ref _fVehiculoModeloOtro, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string VehiculoCaracteristica
        {
            get { return _fVehiculoCaracteristica; }
            set { SetPropertyValue("VehiculoCaracteristica", ref _fVehiculoCaracteristica, value); }
        }

        public int VehiculoAño
        {
            get { return _fVehiculoAño; }
            set { SetPropertyValue<int>("VehiculoAño", ref _fVehiculoAño, value); }
        }

        public bool Vehiculo0Km
        {
            get { return _fVehiculo0Km; }
            set { SetPropertyValue("Vehiculo0Km", ref _fVehiculo0Km, value); }
        }

        [Size(50)]
        public string VehiculoPatente
        {
            get { return _fVehiculoPatente; }
            set { SetPropertyValue("VehiculoPatente", ref _fVehiculoPatente, value); }
        }

        [Size(50)]
        public string VehiculoMotor
        {
            get { return _fVehiculoMotor; }
            set { SetPropertyValue("VehiculoMotor", ref _fVehiculoMotor, value); }
        }

        [Size(50)]
        public string VehiculoChasis
        {
            get { return _fVehiculoChasis; }
            set { SetPropertyValue("VehiculoChasis", ref _fVehiculoChasis, value); }
        }

        [Association(@"DocumentoItemReferencesVehiculoUso")]
        public VehiculoUso VehiculoUso
        {
            get { return _fVehiculoUso; }
            set { SetPropertyValue("VehiculoUso", ref _fVehiculoUso, value); }
        }

        [Association(@"DocumentoIntervinienteReferencesDocumentoItem")]
        public XPCollection<DocumentoInterviniente> Intervinientes => GetCollection<DocumentoInterviniente>("Intervinientes");

        [Association(@"DocumentoItemCoberturaReferencesDocumentoItem")]
        public XPCollection<DocumentoItemCobertura> Coberturas => GetCollection<DocumentoItemCobertura>("Coberturas");

        [Association(@"SiniestroReferencesDocumentoItem")]
        public XPCollection<Siniestro> Siniestros => GetCollection<Siniestro>("Siniestros");
    }
}