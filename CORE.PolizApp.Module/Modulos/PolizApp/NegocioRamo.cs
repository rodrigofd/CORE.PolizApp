using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.NegocioRamo")]
    public class NegocioRamo : BasicObject
    {
        private decimal _fComision;
        private Negocio _fNegocio;
        private int _fRamo;
        private decimal _fTasa;

        public NegocioRamo(Session session) : base(session)
        {
        }

        [Association(@"NegocioRamoReferencesNegocio")]
        public Negocio Negocio
        {
            get { return _fNegocio; }
            set { SetPropertyValue("Negocio", ref _fNegocio, value); }
        }

        public int Ramo
        {
            get { return _fRamo; }
            set { SetPropertyValue<int>("Ramo", ref _fRamo, value); }
        }

        public decimal Tasa
        {
            get { return _fTasa; }
            set { SetPropertyValue<decimal>("Tasa", ref _fTasa, value); }
        }

        public decimal Comision
        {
            get { return _fComision; }
            set { SetPropertyValue<decimal>("Comision", ref _fComision, value); }
        }

        [Association(@"NegocioRamoPlanReferencesNegocioRamo")]
        public XPCollection<NegocioRamoPlan> Planes => GetCollection<NegocioRamoPlan>("Planes");
    }
}