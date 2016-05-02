using System;
using CORE.PolizApp.Fondos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.RendicionItemImportado")]
    public class RendicionItemImportado : BasicObject
    {
        private decimal _fComision;
        private string _fComprobante;
        private int _fCuota;
        private string _fDetalle;
        private DocumentoCuota _fDocumentoCuota;
        private string _fEndosoNumero;
        private Especie _fEspecie;
        private DateTime _fFecha;
        private string _fPolizaNumero;
        private decimal _fPremio;
        private decimal _fPrima;
        private Ramo _fRamo;
        private Rendicion _fRendicionDeAseguradora;
        private bool _fRendido;
        private bool _fRendidoManual;
        private string _fValido;

        public RendicionItemImportado(Session session) : base(session)
        {
        }

        [Association(@"RendicionItemImportadoReferencesRendicion")]
        public Rendicion RendicionDeAseguradora
        {
            get { return _fRendicionDeAseguradora; }
            set { SetPropertyValue("RendicionDeAseguradora", ref _fRendicionDeAseguradora, value); }
        }

        public DateTime Fecha
        {
            get { return _fFecha; }
            set { SetPropertyValue<DateTime>("Fecha", ref _fFecha, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Comprobante
        {
            get { return _fComprobante; }
            set { SetPropertyValue("Comprobante", ref _fComprobante, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Detalle
        {
            get { return _fDetalle; }
            set { SetPropertyValue("Detalle", ref _fDetalle, value); }
        }

        [Association(@"RendicionItemImportadoReferencesRamo")]
        public Ramo Ramo
        {
            get { return _fRamo; }
            set { SetPropertyValue("Ramo", ref _fRamo, value); }
        }

        [Size(20)]
        public string PolizaNumero
        {
            get { return _fPolizaNumero; }
            set { SetPropertyValue("PolizaNumero", ref _fPolizaNumero, value); }
        }

        [Size(20)]
        public string EndosoNumero
        {
            get { return _fEndosoNumero; }
            set { SetPropertyValue("EndosoNumero", ref _fEndosoNumero, value); }
        }

        public Especie Especie
        {
            get { return _fEspecie; }
            set { SetPropertyValue("Especie", ref _fEspecie, value); }
        }

        public int Cuota
        {
            get { return _fCuota; }
            set { SetPropertyValue<int>("Cuota", ref _fCuota, value); }
        }

        public decimal Prima
        {
            get { return _fPrima; }
            set { SetPropertyValue<decimal>("Prima", ref _fPrima, value); }
        }

        public decimal Premio
        {
            get { return _fPremio; }
            set { SetPropertyValue<decimal>("Premio", ref _fPremio, value); }
        }

        public decimal Comision
        {
            get { return _fComision; }
            set { SetPropertyValue<decimal>("Comision", ref _fComision, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Valido
        {
            get { return _fValido; }
            set { SetPropertyValue("Valido", ref _fValido, value); }
        }

        [Association(@"RendicionItemImportadoReferencesDocumentoCuota")]
        public DocumentoCuota DocumentoCuota
        {
            get { return _fDocumentoCuota; }
            set { SetPropertyValue("DocumentoCuota", ref _fDocumentoCuota, value); }
        }

        public bool Rendido
        {
            get { return _fRendido; }
            set { SetPropertyValue("Rendido", ref _fRendido, value); }
        }

        public bool RendidoManual
        {
            get { return _fRendidoManual; }
            set { SetPropertyValue("RendidoManual", ref _fRendidoManual, value); }
        }
    }
}