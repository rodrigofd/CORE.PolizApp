using System;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.DocumentoCuota")]
    public class DocumentoCuota : BasicObject
    {
        private int _fCuota;
        private Documento _fDocumento;
        private DateTime _fFecha;
        private decimal _fImporte;

        public DocumentoCuota(Session session) : base(session)
        {
        }

        [Association(@"DocumentoCuotaReferencesDocumento")]
        public Documento Documento
        {
            get { return _fDocumento; }
            set { SetPropertyValue("Documento", ref _fDocumento, value); }
        }

        public int Cuota
        {
            get { return _fCuota; }
            set { SetPropertyValue<int>("Cuota", ref _fCuota, value); }
        }

        public DateTime Fecha
        {
            get { return _fFecha; }
            set { SetPropertyValue<DateTime>("Fecha", ref _fFecha, value); }
        }

        public decimal Importe
        {
            get { return _fImporte; }
            set { SetPropertyValue<decimal>("Importe", ref _fImporte, value); }
        }

        [Association(@"RendicionItemReferencesDocumentoCuota")]
        public XPCollection<RendicionItem> RendicionItems => GetCollection<RendicionItem>("RendicionItems");

        [Association(@"RendicionItemImportadoReferencesDocumentoCuota")]
        public XPCollection<RendicionItemImportado> RendicionItemImportados => GetCollection<RendicionItemImportado>("RendicionItemImportados");
    }
}