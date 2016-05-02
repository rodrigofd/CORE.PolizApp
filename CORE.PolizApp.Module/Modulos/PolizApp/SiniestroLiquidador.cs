using CORE.PolizApp.Personas;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.SiniestroLiquidador")]
    public class SiniestroLiquidador : BasicObject
    {
        private string _fCodigo;
        private int _fOrden;
        private Persona _fPersona;

        public SiniestroLiquidador(Session session) : base(session)
        {
        }

        public Persona Persona
        {
            get { return _fPersona; }
            set { SetPropertyValue("Persona", ref _fPersona, value); }
        }

        [Size(10)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }

        [Association(@"SiniestroReferencesSiniestroLiquidador")]
        public XPCollection<Siniestro> Siniestros => GetCollection<Siniestro>("Siniestros");
    }
}