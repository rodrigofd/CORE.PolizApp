using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.PersonaContacto")]
    [System.ComponentModel.DisplayName("Contacto de persona")]
    [DefaultClassOptions]
public class PersonaContacto : BasicObject //, IObjetoPorGrupo
    {
        private ContactoTipo _fContactoTipo;
        private string _fNombre;
        private int _fOrden;
        private Persona _fPersona;
        private string _fUbicacion;

        public PersonaContacto(Session session)
            : base(session)
        {
        }

        [Browsable(false)]
        [Association(@"PersonasContactosReferencesPersonas")]
        public Persona Persona
        {
            get { return _fPersona; }
            set { SetPropertyValue("Persona", ref _fPersona, value); }
        }

        [System.ComponentModel.DisplayName("Tipo")]
        public ContactoTipo ContactoTipo
        {
            get { return _fContactoTipo; }
            set { SetPropertyValue("ContactoTipo", ref _fContactoTipo, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [System.ComponentModel.DisplayName("Ubicación")]
        [Size(SizeAttribute.Unlimited)]
        public string Ubicacion
        {
            get { return _fUbicacion; }
            set { SetPropertyValue("Ubicacion", ref _fUbicacion, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}