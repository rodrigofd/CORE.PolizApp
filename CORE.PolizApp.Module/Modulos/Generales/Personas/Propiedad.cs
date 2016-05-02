using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Personas
{
    [ImageName("property")]
    [Persistent(@"personas.Propiedad")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Propiedad")]
    [DefaultClassOptions]
public class Propiedad : BasicObject
    {
        private string _fNombre;
        private TipoPersona _fTipoPersona;

        public Propiedad(Session session)
            : base(session)
        {
        }

        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [ImmediatePostData]
        [System.ComponentModel.DisplayName("Para tipo de persona")]
        public TipoPersona TipoPersona
        {
            get { return _fTipoPersona; }
            set { SetPropertyValue("TipoPersona", ref _fTipoPersona, value); }
        }

        [Association(@"PropiedadesValoresReferencesPropiedades", typeof (PropiedadValor))]
        [System.ComponentModel.DisplayName("Valores predefinidos")]
        public XPCollection<PropiedadValor> Valores => GetCollection<PropiedadValor>("Valores");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            TipoPersona = TipoPersona.Fisica;
            ;
        }
    }
}