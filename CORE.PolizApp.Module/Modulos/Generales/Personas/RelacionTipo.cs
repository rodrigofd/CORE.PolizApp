using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.RelacionTipo")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Tipo de relación")]
    public class RelacionTipo : BasicObject
    {
        private string fNombre;
        private RelacionTipo fRelacionTipoInverso;
        //private string fNombreInverso;

        public RelacionTipo(Session session) : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [PersistentAlias("Nombre + ' - (' + RelacionTipoInverso.Nombre + ')'")]
        public string Descripcion => (string) EvaluateAlias("Descripcion");

        [Size(50)]
        [System.ComponentModel.DisplayName(@"Relación")]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [RuleRequiredField]
        [System.ComponentModel.DisplayName(@"Relación Inversa")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        //[DefaultProperty("Nombre")]
        public RelacionTipo RelacionTipoInverso
        {
            get { return fRelacionTipoInverso; }
            set { SetPropertyValue("RelacionTipoInverso", ref fRelacionTipoInverso, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}