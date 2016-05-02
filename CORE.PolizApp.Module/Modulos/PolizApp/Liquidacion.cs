using System;
using CORE.PolizApp.Fondos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using FDIT.Core.Sistema;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.Liquidacion")]
    public class Liquidacion : BasicObject, IObjetoPorEmpresa
    {
        private Aseguradora _fAseguradora;
        private bool _fBruta;
        private Empresa _fEmpresa;
        private Especie _fEspecieCobrada;
        private Especie _fEspecieDocumento;
        private DateTime _fFecha;
        private decimal _fIvaTasa;
        private string _fNota;
        private int _fNumero;
        private decimal _fRetencionTasa1;
        private decimal _fRetencionTasa2;
        private decimal _fRetencionTasa3;
        private decimal _fRetencionTasa4;

        public Liquidacion(Session session) : base(session)
        {
        }

        public Empresa Empresa
        {
            get { return _fEmpresa; }
            set { SetPropertyValue<Empresa>("Empresa", ref _fEmpresa, value); }
        }

        [Association(@"LiquidacionReferencesAseguradora")]
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

        public bool Bruta
        {
            get { return _fBruta; }
            set { SetPropertyValue("Bruta", ref _fBruta, value); }
        }

        public Especie EspecieDocumento
        {
            get { return _fEspecieDocumento; }
            set { SetPropertyValue<Especie>("EspecieDocumento", ref _fEspecieDocumento, value); }
        }

        public Especie EspecieCobrada
        {
            get { return _fEspecieCobrada; }
            set { SetPropertyValue<Especie>("EspecieCobrada", ref _fEspecieCobrada, value); }
        }

        public decimal IvaTasa
        {
            get { return _fIvaTasa; }
            set { SetPropertyValue<decimal>("IvaTasa", ref _fIvaTasa, value); }
        }

        public decimal RetencionTasa1
        {
            get { return _fRetencionTasa1; }
            set { SetPropertyValue<decimal>("RetencionTasa1", ref _fRetencionTasa1, value); }
        }

        public decimal RetencionTasa2
        {
            get { return _fRetencionTasa2; }
            set { SetPropertyValue<decimal>("RetencionTasa2", ref _fRetencionTasa2, value); }
        }

        public decimal RetencionTasa3
        {
            get { return _fRetencionTasa3; }
            set { SetPropertyValue<decimal>("RetencionTasa3", ref _fRetencionTasa3, value); }
        }

        public decimal RetencionTasa4
        {
            get { return _fRetencionTasa4; }
            set { SetPropertyValue<decimal>("RetencionTasa4", ref _fRetencionTasa4, value); }
        }

        [Size(255)]
        public string Nota
        {
            get { return _fNota; }
            set { SetPropertyValue("Nota", ref _fNota, value); }
        }

        [Association(@"LiquidacionItemReferencesLiquidacion")]
        public XPCollection<LiquidacionItem> Items => GetCollection<LiquidacionItem>("Items");
    }
}