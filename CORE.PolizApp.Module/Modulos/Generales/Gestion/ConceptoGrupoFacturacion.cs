using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo;

namespace CORE.PolizApp.Gestion
{
    [Persistent(@"gestion.ConceptoGrupoFacturacion")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Grupos de conceptos para Facturación")]
    public class ConceptoGrupoFacturacion : BasicObject
    {
        private string fNombre;

        public ConceptoGrupoFacturacion(Session session) : base(session)
        {
        }

        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [Association(@"ConceptosReferencesConceptosGruposFacturacion", typeof (Concepto))]
        public XPCollection<Concepto> Conceptos => GetCollection<Concepto>("Conceptos");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }
    }
}