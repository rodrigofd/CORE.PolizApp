using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.NegocioLinea")]
    public class NegocioLinea : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;
        private int _fOrden;

        public NegocioLinea(Session session) : base(session)
        {
        }

        [Size(50)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(50)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }

        [Association(@"IntermediarioComisionReferencesNegocioLinea")]
        public XPCollection<IntermediarioComision> IntermediarioComisiones => GetCollection<IntermediarioComision>("IntermediarioComisiones");

        [Association(@"NegocioReferencesNegocioLinea")]
        public XPCollection<Negocio> Negocios => GetCollection<Negocio>("Negocios");
    }
}