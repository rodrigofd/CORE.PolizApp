using CORE.PolizApp.Personas;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.IntermediarioComision")]
    public class IntermediarioComision : BasicObject
    {
        private Aseguradora _fAseguradora;
        private decimal _fComisionCobranzaTasa;
        private decimal _fComisionPrimaTasa;
        private Persona _fIntermediario;
        private NegocioLinea _fNegocioLinea;
        private Persona _fProductor;
        private Ramo _fRamo;
        private Persona _fTomador;

        public IntermediarioComision(Session session) : base(session)
        {
        }

        public Persona Intermediario
        {
            get { return _fIntermediario; }
            set { SetPropertyValue<Persona>("Intermediario", ref _fIntermediario, value); }
        }

        [Association(@"IntermediarioComisionReferencesAseguradora")]
        public Aseguradora Aseguradora
        {
            get { return _fAseguradora; }
            set { SetPropertyValue("Aseguradora", ref _fAseguradora, value); }
        }

        public Persona Tomador
        {
            get { return _fTomador; }
            set { SetPropertyValue<Persona>("Tomador", ref _fTomador, value); }
        }

        public Persona Productor
        {
            get { return _fProductor; }
            set { SetPropertyValue<Persona>("Productor", ref _fProductor, value); }
        }

        [Association(@"IntermediarioComisionReferencesNegocioLinea")]
        public NegocioLinea NegocioLinea
        {
            get { return _fNegocioLinea; }
            set { SetPropertyValue("NegocioLinea", ref _fNegocioLinea, value); }
        }

        [Association(@"IntermediarioComisionReferencesRamo")]
        public Ramo Ramo
        {
            get { return _fRamo; }
            set { SetPropertyValue("Ramo", ref _fRamo, value); }
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