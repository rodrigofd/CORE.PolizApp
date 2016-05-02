using CORE.PolizApp.Fondos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.LiquidacionIntermadiarioItem")]
    public class LiquidacionIntermadiarioItem : BasicObject
    {
        private decimal _fCambio;
        private decimal _fComisionCobranza;
        private decimal _fComisionCobranzaTasa;
        private decimal _fComisionPrima;
        private decimal _fComisionPrimaTasa;
        private Especie _fEspecie;
        private LiquidacionIntermediario _fLiquidacionIntermediario;
        private LiquidacionItem _fLiquidacionItem;
        private RendicionItem _fRendicionItem;

        public LiquidacionIntermadiarioItem(Session session) : base(session)
        {
        }

        [Association(@"LiquidacionIntermadiarioItemReferencesLiquidacionIntermediario")]
        public LiquidacionIntermediario LiquidacionIntermediario
        {
            get { return _fLiquidacionIntermediario; }
            set { SetPropertyValue("LiquidacionIntermediario", ref _fLiquidacionIntermediario, value); }
        }

        [Association(@"LiquidacionIntermadiarioItemReferencesLiquidacionItem")]
        public LiquidacionItem LiquidacionItem
        {
            get { return _fLiquidacionItem; }
            set { SetPropertyValue("LiquidacionItem", ref _fLiquidacionItem, value); }
        }

        [Association(@"LiquidacionIntermadiarioItemReferencesRendicionItem")]
        public RendicionItem RendicionItem
        {
            get { return _fRendicionItem; }
            set { SetPropertyValue("RendicionItem", ref _fRendicionItem, value); }
        }

        public Especie Especie
        {
            get { return _fEspecie; }
            set { SetPropertyValue<Especie>("Especie", ref _fEspecie, value); }
        }

        public decimal Cambio
        {
            get { return _fCambio; }
            set { SetPropertyValue<decimal>("Cambio", ref _fCambio, value); }
        }

        public decimal ComisionPrima
        {
            get { return _fComisionPrima; }
            set { SetPropertyValue<decimal>("ComisionPrima", ref _fComisionPrima, value); }
        }

        public decimal ComisionCobranza
        {
            get { return _fComisionCobranza; }
            set { SetPropertyValue<decimal>("ComisionCobranza", ref _fComisionCobranza, value); }
        }

        public decimal ComisionPrimaTasa
        {
            get { return _fComisionPrimaTasa; }
            set { SetPropertyValue<decimal>("ComisionPrimaTasa", ref _fComisionPrimaTasa, value); }
        }

        public decimal ComisionCobranzaTasa
        {
            get { return _fComisionCobranzaTasa; }
            set { SetPropertyValue<decimal>("ComisionCobranzaTasa", ref _fComisionCobranzaTasa, value); }
        }
    }
}