using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.LiquidacionItem")]
    public class LiquidacionItem : BasicObject
    {
        private decimal _fComisionCobranza;
        private decimal _fComisionPrima;
        private Liquidacion _fLiquidacion;
        private int _fPagoAplicacion;

        public LiquidacionItem(Session session) : base(session)
        {
        }

        [Association(@"LiquidacionItemReferencesLiquidacion")]
        public Liquidacion Liquidacion
        {
            get { return _fLiquidacion; }
            set { SetPropertyValue("Liquidacion", ref _fLiquidacion, value); }
        }

        //TODO: FK ? 
        public int PagoAplicacion
        {
            get { return _fPagoAplicacion; }
            set { SetPropertyValue<int>("PagoAplicacion", ref _fPagoAplicacion, value); }
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

        [Association(@"LiquidacionIntermadiarioItemReferencesLiquidacionItem")]
        public XPCollection<LiquidacionIntermadiarioItem> LiquidacionIntermadiarioItems => GetCollection<LiquidacionIntermadiarioItem>("LiquidacionIntermadiarioItems");
    }
}