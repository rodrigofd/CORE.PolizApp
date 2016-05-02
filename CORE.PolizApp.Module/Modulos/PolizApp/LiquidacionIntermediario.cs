using System;
using CORE.PolizApp.Personas;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using FDIT.Core.Sistema;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.LiquidacionIntermediario")]
    public class LiquidacionIntermediario : BasicObject, IObjetoPorEmpresa
    {
        private Empresa _fEmpresa;
        private int _fEspecie;
        private DateTime _fFecha;
        private DateTime _fFechaCerrada;
        private decimal _fGastos;
        private Persona _fIntermediario;
        private decimal _fIva;
        private string _fNota;
        private int _fNumero;

        public LiquidacionIntermediario(Session session) : base(session)
        {
        }

        public Empresa Empresa
        {
            get { return _fEmpresa; }
            set { SetPropertyValue<Empresa>("Empresa", ref _fEmpresa, value); }
        }

        public Persona Intermediario
        {
            get { return _fIntermediario; }
            set { SetPropertyValue("Intermediario", ref _fIntermediario, value); }
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

        public int Especie
        {
            get { return _fEspecie; }
            set { SetPropertyValue<int>("Especie", ref _fEspecie, value); }
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

        [Association(@"LiquidacionIntermadiarioItemReferencesLiquidacionIntermediario")]
        public XPCollection<LiquidacionIntermadiarioItem> Items => GetCollection<LiquidacionIntermadiarioItem>("Items");
    }
}