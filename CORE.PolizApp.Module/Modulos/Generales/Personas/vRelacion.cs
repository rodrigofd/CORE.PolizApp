using System;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

//using CORE.General.Modulos.Sistema;

namespace CORE.PolizApp.Personas
{
    [ImageName("group_link")]
    [Persistent(@"personas.vRelacion")]
    [System.ComponentModel.DisplayName("Relación")]
    public class personas_vRelacion : BasicObject
    {
        private DateTime fDesde;
        private DateTime fHasta;
        private string fNotas;
        private Persona fPersonaVinculado;
        private Persona fPersonaVinculante;
        private personas_RelacionTipo fRelacionTipo;

        public personas_vRelacion(Session session) : base(session)
        {
        }

        //[VisibleInListView(false)]
        //[PersistentAlias("Persona.OID")]
        //public Persona oid
        //{
        //    get { return ( Persona ) EvaluateAlias("oid"); }
        //}

        [RuleRequiredField]
        [Association(@"vRelacionesReferencesPersonas-Vinculante")]
        [System.ComponentModel.DisplayName("Persona vinculante")]
        //[Appearance("PersonaVinculanteRule", AppearanceItemType = "ViewItem", TargetItems = "PersonaVinculante", Criteria = "PersonaVinculante = oid", Context = "DetailView", Enabled = false)]
        public Persona PersonaVinculante
        {
            get { return fPersonaVinculante; }
            set { SetPropertyValue("PersonaVinculante", ref fPersonaVinculante, value); }
        }

        [RuleRequiredField]
        [System.ComponentModel.DisplayName(@"'Es' (Relación)")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public personas_RelacionTipo RelacionTipo
        {
            get { return fRelacionTipo; }
            set { SetPropertyValue("RelacionTipo", ref fRelacionTipo, value); }
        }

        [RuleRequiredField]
        //[Association( @"RelacionesReferencesPersonas-Vinculado" )]
        [System.ComponentModel.DisplayName("'De' (Persona)")]
        //[Appearance("PersonaVinculanteRule", AppearanceItemType = "ViewItem", TargetItems = "PersonaVinculado", Criteria = "PersonaVinculante = oid", Context = "DetailView", Enabled = false)]
        public Persona PersonaVinculado
        {
            get { return fPersonaVinculado; }
            set { SetPropertyValue("PersonaVinculado", ref fPersonaVinculado, value); }
        }

        public DateTime Desde
        {
            get { return fDesde; }
            set { SetPropertyValue<DateTime>("Desde", ref fDesde, value); }
        }

        public DateTime Hasta
        {
            get { return fHasta; }
            set { SetPropertyValue<DateTime>("Hasta", ref fHasta, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Notas
        {
            get { return fNotas; }
            set { SetPropertyValue("Notas", ref fNotas, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}