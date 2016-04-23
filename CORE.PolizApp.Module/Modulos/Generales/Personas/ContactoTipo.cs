using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Xpo;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.ContactoTipo")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Tipo de contacto")]
    public class ContactoTipo : BasicObject
    {
        private string fContactoTipo;

        public ContactoTipo(Session session) : base(session)
        {
        }

        public string Nombre
        {
            get { return fContactoTipo; }
            set { SetPropertyValue("Nombre", ref fContactoTipo, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}