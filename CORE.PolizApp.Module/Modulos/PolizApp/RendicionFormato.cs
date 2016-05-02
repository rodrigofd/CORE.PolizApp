using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.RendicionFormato")]
    public class RendicionFormato : BasicObject
    {
        private string _fNombre;
        private string _fUbicacionRuta;

        public RendicionFormato(Session session) : base(session)
        {
        }

        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string UbicacionRuta
        {
            get { return _fUbicacionRuta; }
            set { SetPropertyValue("UbicacionRuta", ref _fUbicacionRuta, value); }
        }

        [Association(@"RendicionReferencesRendicionFormato")]
        public XPCollection<Rendicion> Rendiciones => GetCollection<Rendicion>("Rendiciones");
    }
}