using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo;

namespace CORE.PolizApp.Gestion
{
    /*
    public enum ConceptoClase
    {
    No Gravado = 1,
    Gravado = 2,
    Impuesto = 3
    }
    */

    [Persistent(@"gestion.ConceptoClase")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Conceptos Clases")]
    public class ConceptoClase : BasicObject
    {
        private string fNombre;

        public ConceptoClase(Session session) : base(session)
        {
        }

        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [Browsable(false)]
        [Aggregated]
        [Association(@"ConceptosReferencesConceptosClases", typeof (Concepto))]
        public XPCollection<Concepto> Conceptos => GetCollection<Concepto>("Conceptos");
        
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}