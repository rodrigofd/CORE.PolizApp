using System;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.RendicionArtItem")]
    public class RendicionARTItem : BasicObject
    {
        private decimal _fComision;
        private Documento _fDocumentoGenerado;
        private DateTime _fFechaPago;
        private decimal _fMssa;
        private int _fPersonal;
        private string _fPolizaNumero;
        private RendicionART _fRendicionART;
        private decimal _fSuss;
        private string _fValido;
        private DateTime _fVigenciaFin;
        private DateTime _fVigenciaInicio;

        public RendicionARTItem(Session session) : base(session)
        {
        }

        [Association(@"RendicionArtItemReferencesRendicionArt")]
        public RendicionART RendicionART
        {
            get { return _fRendicionART; }
            set { SetPropertyValue("RendicionART", ref _fRendicionART, value); }
        }

        [Size(20)]
        public string PolizaNumero
        {
            get { return _fPolizaNumero; }
            set { SetPropertyValue("PolizaNumero", ref _fPolizaNumero, value); }
        }

        public decimal MSSA
        {
            get { return _fMssa; }
            set { SetPropertyValue<decimal>("MSSA", ref _fMssa, value); }
        }

        public int Personal
        {
            get { return _fPersonal; }
            set { SetPropertyValue<int>("Personal", ref _fPersonal, value); }
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

        public decimal SUSS
        {
            get { return _fSuss; }
            set { SetPropertyValue<decimal>("SUSS", ref _fSuss, value); }
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

        [Association(@"RendicionArtItemReferencesDocumento")]
        public Documento DocumentoGenerado
        {
            get { return _fDocumentoGenerado; }
            set { SetPropertyValue("DocumentoGenerado", ref _fDocumentoGenerado, value); }
        }
    }
}