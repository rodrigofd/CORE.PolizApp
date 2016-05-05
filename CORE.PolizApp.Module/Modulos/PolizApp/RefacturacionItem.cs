using System;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.RefacturacionItem")]
    public class RefacturacionItem : BasicObject
    {
        private string _fComprobante;
        private Documento _fDocumentoGenerado;
        private DateTime _fEmitidaFecha;
        private string _fEndosoNumero;
        private decimal _fGastos;
        private decimal _fImpuestos;
        private decimal _fIva;
        private string _fPolizaNumero;
        private decimal _fPremio;
        private decimal _fPrima;
        private Ramo _fRamo;
        private Refacturacion _fRefacturacion;
        private decimal _fSumaAsegurada;
        private string _fValido;
        private DateTime _fVigenciaFin;
        private DateTime _fVigenciaInicio;

        public RefacturacionItem(Session session) : base(session)
        {
        }

        [Association(@"RefacturacionItemReferencesRefacturacion")]
        public Refacturacion Refacturacion
        {
            get { return _fRefacturacion; }
            set { SetPropertyValue("Refacturacion", ref _fRefacturacion, value); }
        }

        //[Association(@"RefacturacionItemReferencesRamo")]
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

        public DateTime EmitidaFecha
        {
            get { return _fEmitidaFecha; }
            set { SetPropertyValue<DateTime>("EmitidaFecha", ref _fEmitidaFecha, value); }
        }

        public DateTime VigenciaInicio
        {
            get { return _fVigenciaInicio; }
            set { SetPropertyValue<DateTime>("VigenciaInicio", ref _fVigenciaInicio, value); }
        }

        public DateTime VigenciaFin
        {
            get { return _fVigenciaFin; }
            set { SetPropertyValue<DateTime>("VigenciaFin", ref _fVigenciaFin, value); }
        }

        public decimal SumaAsegurada
        {
            get { return _fSumaAsegurada; }
            set { SetPropertyValue<decimal>("SumaAsegurada", ref _fSumaAsegurada, value); }
        }

        public decimal Prima
        {
            get { return _fPrima; }
            set { SetPropertyValue<decimal>("Prima", ref _fPrima, value); }
        }

        public decimal Gastos
        {
            get { return _fGastos; }
            set { SetPropertyValue<decimal>("Gastos", ref _fGastos, value); }
        }

        public decimal Iva
        {
            get { return _fIva; }
            set { SetPropertyValue<decimal>("Iva", ref _fIva, value); }
        }

        public decimal Impuestos
        {
            get { return _fImpuestos; }
            set { SetPropertyValue<decimal>("Impuestos", ref _fImpuestos, value); }
        }

        public decimal Premio
        {
            get { return _fPremio; }
            set { SetPropertyValue<decimal>("Premio", ref _fPremio, value); }
        }

        [Size(50)]
        public string Comprobante
        {
            get { return _fComprobante; }
            set { SetPropertyValue("Comprobante", ref _fComprobante, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Valido
        {
            get { return _fValido; }
            set { SetPropertyValue("Valido", ref _fValido, value); }
        }

        [Association(@"RefacturacionItemReferencesDocumento")]
        public Documento DocumentoGenerado
        {
            get { return _fDocumentoGenerado; }
            set { SetPropertyValue("DocumentoGenerado", ref _fDocumentoGenerado, value); }
        }
    }
}