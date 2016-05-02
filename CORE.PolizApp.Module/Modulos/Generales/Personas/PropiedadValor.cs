using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.PropiedadValor")]
    [DefaultProperty("Valor")]
    [System.ComponentModel.DisplayName("Valor predefinido de propiedad")]
    [DefaultClassOptions]
public class PropiedadValor : BasicObject
    {
        private int _fOrden;
        private Propiedad _fPropiedad;
        private string _fValor;

        public PropiedadValor(Session session)
            : base(session)
        {
        }

        [Association(@"PropiedadesValoresReferencesPropiedades")]
        public Propiedad Propiedad
        {
            get { return _fPropiedad; }
            set { SetPropertyValue("Propiedad", ref _fPropiedad, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Valor
        {
            get { return _fValor; }
            set { SetPropertyValue("Valor", ref _fValor, value); }
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