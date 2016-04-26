using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Continente")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Continente")]
    public class Continente : BasicObject
    {
        private string fCodigo;
        private string fNombre;

        public Continente(Session session) : base(session)
        {
        }

        [Size(2)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(20)]
        [Index(1)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [Association(@"PaisesReferencesContinentes", typeof (Pais))]
        public XPCollection<Pais> Paises => GetCollection<Pais>("Paises");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}