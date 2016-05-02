using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

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
    [DefaultClassOptions]
public class ConceptoClase : BasicObject
    {
        private string _fNombre;

        public ConceptoClase(Session session) : base(session)
        {
        }

        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
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