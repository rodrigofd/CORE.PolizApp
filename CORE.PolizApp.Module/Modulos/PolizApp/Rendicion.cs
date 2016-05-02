using System;
using CORE.PolizApp.Fondos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using FDIT.Core.Sistema;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.Rendicion")]
    public class Rendicion : BasicObject, IObjetoPorEmpresa
    {
        private decimal _fAjuste;
        private Aseguradora _fAseguradora;
        private decimal _fCambioPropuesto;
        private Empresa _fEmpresa;
        private Especie _fEspecie;
        private DateTime _fFecha;
        private DateTime _fFechaCerrada;
        private DateTime _fFechaCobro;
        private DateTime _fFechaRendicion;
        private string _fNota;
        private int _fNumero;
        private string _fArchivoImportar;
        private DateTime _fPeriodoFin;
        private DateTime _fPeriodoInicio;
        private RendicionFormato _fFormato;
        private decimal _fSaldoFinal;
        private decimal _fSaldoInicio;

        public Rendicion(Session session) : base(session)
        {
        }

        public Empresa Empresa
        {
            get { return _fEmpresa; }
            set { SetPropertyValue<Empresa>("Empresa", ref _fEmpresa, value); }
        }

        [Association(@"RendicionReferencesAseguradora")]
        public Aseguradora Aseguradora
        {
            get { return _fAseguradora; }
            set { SetPropertyValue("Aseguradora", ref _fAseguradora, value); }
        }

        public int Numero
        {
            get { return _fNumero; }
            set { SetPropertyValue<int>("Numero", ref _fNumero, value); }
        }

        public DateTime Fecha
        {
            get { return _fFecha; }
            set { SetPropertyValue<DateTime>("Fecha", ref _fFecha, value); }
        }

        public DateTime FechaRendicion
        {
            get { return _fFechaRendicion; }
            set { SetPropertyValue<DateTime>("FechaRendicion", ref _fFechaRendicion, value); }
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

        public DateTime FechaCobro
        {
            get { return _fFechaCobro; }
            set { SetPropertyValue<DateTime>("FechaCobro", ref _fFechaCobro, value); }
        }

        public Especie Especie
        {
            get { return _fEspecie; }
            set { SetPropertyValue("Especie", ref _fEspecie, value); }
        }

        public decimal CambioPropuesto
        {
            get { return _fCambioPropuesto; }
            set { SetPropertyValue<decimal>("CambioPropuesto", ref _fCambioPropuesto, value); }
        }

        [Size(255)]
        public string Nota
        {
            get { return _fNota; }
            set { SetPropertyValue("Nota", ref _fNota, value); }
        }

        public DateTime FechaCerrada
        {
            get { return _fFechaCerrada; }
            set { SetPropertyValue<DateTime>("FechaCerrada", ref _fFechaCerrada, value); }
        }

        public decimal SaldoInicio
        {
            get { return _fSaldoInicio; }
            set { SetPropertyValue<decimal>("SaldoInicio", ref _fSaldoInicio, value); }
        }

        public decimal Ajuste
        {
            get { return _fAjuste; }
            set { SetPropertyValue<decimal>("Ajuste", ref _fAjuste, value); }
        }

        public decimal SaldoFinal
        {
            get { return _fSaldoFinal; }
            set { SetPropertyValue<decimal>("SaldoFinal", ref _fSaldoFinal, value); }
        }

        [Association(@"RendicionReferencesRendicionFormato")]
        [Persistent(@"RendicionDeAseguradoraFormato")]
        public RendicionFormato Formato
        {
            get { return _fFormato; }
            set { SetPropertyValue("Formato", ref _fFormato, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [Persistent(@"_ArchivoImportar")]
        public string ArchivoImportar
        {
            get { return _fArchivoImportar; }
            set { SetPropertyValue("ArchivoImportar", ref _fArchivoImportar, value); }
        }

        [Association(@"RendicionItemReferencesRendicion")]
        public XPCollection<RendicionItem> Items => GetCollection<RendicionItem>("Items");

        [Association(@"RendicionItemImportadoReferencesRendicion")]
        public XPCollection<RendicionItemImportado> ItemsImportados => GetCollection<RendicionItemImportado>("ItemsImportados");
    }
}