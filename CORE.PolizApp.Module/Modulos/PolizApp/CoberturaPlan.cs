using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.CoberturaPlan")]
    public class CoberturaPlan : BasicObject
    {
        private Cobertura _fCobertura;
        private NegocioRamoPlan _fNegocioRiesgoPlan;
        private int _fOrden;

        public CoberturaPlan(Session session) : base(session)
        {
        }

        [Association(@"CoberturaPlanReferencesCobertura")]
        public Cobertura Cobertura
        {
            get { return _fCobertura; }
            set { SetPropertyValue("Cobertura", ref _fCobertura, value); }
        }

        [Association(@"CoberturaPlanReferencesNegocioRamoPlan")]
        public NegocioRamoPlan NegocioRiesgoPlan
        {
            get { return _fNegocioRiesgoPlan; }
            set { SetPropertyValue("NegocioRiesgoPlan", ref _fNegocioRiesgoPlan, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }
    }
}