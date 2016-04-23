using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Xpo;

//using CORE.General.Modulos.Sistema;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.PersonaContacto")]
    [System.ComponentModel.DisplayName("Contacto de persona")]
    public class personas_PersonaContacto : BasicObject //, IObjetoPorGrupo
    {
        private ContactoTipo fContactoTipo;
        private string fNombre;
        //private Grupo fGrupo;
        private int fOrden;
        private Persona fPersona;
        private string fUbicacion;

        public personas_PersonaContacto(Session session)
            : base(session)
        {
        }

        [Browsable(false)]
        [Association(@"PersonasContactosReferencesPersonas")]
        public Persona Persona
        {
            get { return fPersona; }
            set { SetPropertyValue("Persona", ref fPersona, value); }
        }

        [System.ComponentModel.DisplayName("Tipo")]
        public ContactoTipo ContactoTipo
        {
            get { return fContactoTipo; }
            set { SetPropertyValue("ContactoTipo", ref fContactoTipo, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [System.ComponentModel.DisplayName("Ubicaci�n")]
        [Size(SizeAttribute.Unlimited)]
        public string Ubicacion
        {
            get { return fUbicacion; }
            set { SetPropertyValue("Ubicacion", ref fUbicacion, value); }
        }

        public int Orden
        {
            get { return fOrden; }
            set { SetPropertyValue<int>("Orden", ref fOrden, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}