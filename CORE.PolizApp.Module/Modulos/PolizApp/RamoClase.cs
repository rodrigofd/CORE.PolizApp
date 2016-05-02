using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.RamoClase")]
    public class RamoClase : BasicObject
    {
        private string _fNombre;

        public RamoClase(Session session) : base(session)
        {
        }

        [Size(50)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Association(@"RamoReferencesRamoClase")]
        public XPCollection<Ramo> Ramos => GetCollection<Ramo>("Ramos");
    }
}