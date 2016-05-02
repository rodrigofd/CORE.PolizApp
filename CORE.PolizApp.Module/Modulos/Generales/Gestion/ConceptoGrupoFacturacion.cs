using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Gestion
{
    [Persistent(@"gestion.ConceptoGrupoFacturacion")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Grupos de conceptos para Facturación")]
    [DefaultClassOptions]
public class ConceptoGrupoFacturacion : BasicObject
    {
        private string _fNombre;

        public ConceptoGrupoFacturacion(Session session) : base(session)
        {
        }

        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
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