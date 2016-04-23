using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Gestion
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
        public XPCollection<Concepto> Conceptos
        {
            get { return GetCollection<Concepto>("Conceptos"); }
        }

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