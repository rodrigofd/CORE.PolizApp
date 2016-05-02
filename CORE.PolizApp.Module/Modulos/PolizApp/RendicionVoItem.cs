using System;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.RendicionVoItem")]
    public class RendicionVOItem : BasicObject
    {
        private Documento _fDocumentoGenerado;
        private string _fEndosoNumero;
        private DateTime _fFechaPago;
        private string _fPolizaNumero;
        private decimal _fPremio;
        private decimal _fPrima;
        private RendicionVO _fRendicionVO;
        private string _fValido;
        private DateTime _fVigenciaFin;
        private DateTime _fVigenciaInicio;

        public RendicionVOItem(Session session) : base(session)
        {
        }

        [Association(@"RendicionVoItemReferencesRendicionVo")]
        public RendicionVO RendicionVO
        {
            get { return _fRendicionVO; }
            set { SetPropertyValue("RendicionVO", ref _fRendicionVO, value); }
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

        public DateTime FechaPago
        {
            get { return _fFechaPago; }
            set { SetPropertyValue<DateTime>("FechaPago", ref _fFechaPago, value); }
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

        [Size(SizeAttribute.Unlimited)]
        public string Valido
        {
            get { return _fValido; }
            set { SetPropertyValue("Valido", ref _fValido, value); }
        }

        [Association(@"RendicionVoItemReferencesDocumento")]
        public Documento DocumentoGenerado
        {
            get { return _fDocumentoGenerado; }
            set { SetPropertyValue("DocumentoGenerado", ref _fDocumentoGenerado, value); }
        }
    }
}