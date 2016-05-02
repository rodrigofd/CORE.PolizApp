using System;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using FDIT.Core.Sistema;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.RendicionVo")]
    public class RendicionVO : BasicObject, IObjetoPorEmpresa
    {
        private Aseguradora _fAseguradora;
        private Empresa _fEmpresa;
        private DateTime _fFecha;
        private string _fNota;
        private string _fArchivoImportar;
        private DateTime _fPeriodoDesde;
        private DateTime _fPeriodoHasta;
        private DateTime _fProcesado;

        public RendicionVO(Session session) : base(session)
        {
        }

        public Empresa Empresa
        {
            get { return _fEmpresa; }
            set { SetPropertyValue<Empresa>("Empresa", ref _fEmpresa, value); }
        }

        [Association(@"RendicionVoReferencesAseguradora")]
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

        public DateTime PeriodoDesde
        {
            get { return _fPeriodoDesde; }
            set { SetPropertyValue<DateTime>("PeriodoDesde", ref _fPeriodoDesde, value); }
        }

        public DateTime PeriodoHasta
        {
            get { return _fPeriodoHasta; }
            set { SetPropertyValue<DateTime>("PeriodoHasta", ref _fPeriodoHasta, value); }
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
            set { SetPropertyValue("P_ArchivoImportar", ref _fArchivoImportar, value); }
        }

        [Association(@"RendicionVoItemReferencesRendicionVo")]
        public XPCollection<RendicionVOItem> Items => GetCollection<RendicionVOItem>("Items");
    }
}