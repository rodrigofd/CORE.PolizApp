using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Xpo;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.PropiedadValor")]
    [DefaultProperty("Valor")]
    [System.ComponentModel.DisplayName("Valor predefinido de propiedad")]
    public class personas_PropiedadValor : BasicObject
    {
        private int fOrden;
        private personas_Propiedad fPropiedad;
        private string fValor;

        public personas_PropiedadValor(Session session)
            : base(session)
        {
        }

        [Association(@"PropiedadesValoresReferencesPropiedades")]
        public personas_Propiedad Propiedad
        {
            get { return fPropiedad; }
            set { SetPropertyValue("Propiedad", ref fPropiedad, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Valor
        {
            get { return fValor; }
            set { SetPropertyValue("Valor", ref fValor, value); }
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