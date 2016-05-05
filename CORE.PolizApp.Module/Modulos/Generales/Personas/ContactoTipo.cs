using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.ContactoTipo")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Tipo de contacto")]
    [DefaultClassOptions]
public class ContactoTipo : BasicObject
    {
        private string _fContactoTipo;

        public ContactoTipo(Session session) : base(session)
        {
        }

        public string Nombre
        {
            get {
                return _fContactoTipo;
            }
            set { SetPropertyValue("Nombre", ref _fContactoTipo, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}