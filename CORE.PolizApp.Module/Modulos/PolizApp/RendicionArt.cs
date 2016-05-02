using System;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using FDIT.Core.Sistema;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.RendicionArt")]
    public class RendicionART : BasicObject, IObjetoPorEmpresa
    {
        private Aseguradora _fAseguradora;
        private Empresa _fEmpresa;
        private DateTime _fFecha;
        private string _fNota;
        private string _fArchivoImportar;
        private DateTime _fPeriodoFin;
        private DateTime _fPeriodoInicio;
        private DateTime _fProcesado;

        public RendicionART(Session session) : base(session)
        {
        }

        public Empresa Empresa
        {
            get { return _fEmpresa; }
            set { SetPropertyValue<Empresa>("Empresa", ref _fEmpresa, value); }
        }

        [Association(@"RendicionArtReferencesAseguradora")]
        public Aseguradora Aseguradora
        {
            get { return _fAseguradora; }
            set { SetPropertyValue("Aseguradora", ref _fAseguradora, value); }
        }

        public DateTime Fecha
        {
            get { return _fFecha; }
            set { SetPropertyValue<DateTime>("Fecha", ref _fFecha, value); }
        }

        public DateTime PeriodoInicio
        {
            get { return _fPeriodoInicio; }
            set { SetPropertyValue<DateTime>("PeriodoInicio", ref _fPeriodoInicio, value); }
        }

        public DateTime PeriodoFin
        {
            get { return _fPeriodoFin; }
            set { SetPropertyValue<DateTime>("PeriodoFin", ref _fPeriodoFin, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Nota
        {
            get { return _fNota; }
            set { SetPropertyValue("Nota", ref _fNota, value); }
        }

        public DateTime Procesado
        {
            get { return _fProcesado; }
            set { SetPropertyValue<DateTime>("Procesado", ref _fProcesado, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [Persistent(@"_ArchivoImportar")]
        public string ArchivoImportar
        {
            get { return _fArchivoImportar; }
            set { SetPropertyValue("ArchivoImportar", ref _fArchivoImportar, value); }
        }

        [Association(@"RendicionArtItemReferencesRendicionArt")]
        public XPCollection<RendicionARTItem> Items => GetCollection<RendicionARTItem>("Items");
    }
}