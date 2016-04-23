using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

//using CORE.General.Modulos.Sistema;

namespace CORE.PolizApp.Personas
{
    [ImageName("property")]
    [Persistent(@"personas.Propiedad")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Propiedad")]
    public class personas_Propiedad : BasicObject
    {
        private string fNombre;
        private personas_TipoPersona fTipoPersona;

        public personas_Propiedad(Session session)
            : base(session)
        {
        }

        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [ImmediatePostData]
        [System.ComponentModel.DisplayName("Para tipo de persona")]
        public personas_TipoPersona TipoPersona
        {
            get { return fTipoPersona; }
            set { SetPropertyValue("TipoPersona", ref fTipoPersona, value); }
        }

        [Association(@"PropiedadesValoresReferencesPropiedades", typeof (personas_PropiedadValor))]
        [System.ComponentModel.DisplayName("Valores predefinidos")]
        public XPCollection<personas_PropiedadValor> Valores
        {
            get { return GetCollection<personas_PropiedadValor>("Valores"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            TipoPersona = personas_TipoPersona.Fisica;
            ;
        }
    }
}