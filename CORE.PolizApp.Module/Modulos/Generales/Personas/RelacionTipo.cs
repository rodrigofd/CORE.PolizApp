using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

//using CORE.General.Modulos.Sistema;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.RelacionTipo")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Tipo de relación")]
    public class personas_RelacionTipo : BasicObject
    {
        private string fNombre;
        private personas_RelacionTipo fRelacionTipoInverso;
        //private string fNombreInverso;

        public personas_RelacionTipo(Session session) : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [PersistentAlias("Nombre + ' - (' + RelacionTipoInverso.Nombre + ')'")]
        public string Descripcion
        {
            get { return (string) EvaluateAlias("Descripcion"); }
        }

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
        public personas_RelacionTipo RelacionTipoInverso
        {
            get { return fRelacionTipoInverso; }
            set { SetPropertyValue("RelacionTipoInverso", ref fRelacionTipoInverso, value); }
        }

/*
        [Association(@"RelacionesTiposGruposReferencesRelacionesTipos", typeof(RelacionTipoGrupo))]
        [System.ComponentModel.DisplayName(@"Relaciones Tipos (Grupos)")]
        public XPCollection<RelacionTipoGrupo> RelacionTipo
        {
            get { return GetCollection<RelacionTipoGrupo>("RelacionTipo"); }
        }
*/

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}