using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.Negocio")]
    public class Negocio : BasicObject
    {
        private Aseguradora _fAseguradora;
        private NegocioLinea _fNegocioLinea;

        public Negocio(Session session) : base(session)
        {
        }

        [Association(@"NegocioReferencesAseguradora")]
        public Aseguradora Aseguradora
        {
            get { return _fAseguradora; }
            set { SetPropertyValue("Aseguradora", ref _fAseguradora, value); }
        }

        [Association(@"NegocioReferencesNegocioLinea")]
        public NegocioLinea NegocioLinea
        {
            get { return _fNegocioLinea; }
            set { SetPropertyValue("NegocioLinea", ref _fNegocioLinea, value); }
        }

        [Association(@"NegocioRamoReferencesNegocio")]
        public XPCollection<NegocioRamo> Ramos => GetCollection<NegocioRamo>("Ramos");
    }
}