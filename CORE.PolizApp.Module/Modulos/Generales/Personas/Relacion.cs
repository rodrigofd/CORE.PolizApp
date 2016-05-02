using System;
using System.Drawing;
using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace CORE.PolizApp.Personas
{
    [ImageName("group_link")]
    [Persistent(@"personas.Relacion")]
    [System.ComponentModel.DisplayName("Relación")]
    public class Relacion : BasicObject
    {
        private DateTime _fDesde;
        private DateTime _fHasta;
        private string fNotas;
        private Persona _fPersonaVinculado;
        private Persona _fPersonaVinculante;
        private RelacionTipo _fRelacionTipo;

        public Relacion(Session session) : base(session)
        {
        }

        [RuleRequiredField]
        [Association(@"RelacionesReferencesPersonas-Vinculante")]
        [System.ComponentModel.DisplayName("Persona vinculante")]
        //[Appearance("PersonaVinculanteRule", AppearanceItemType = "ViewItem", TargetItems = "PersonaVinculante", Criteria = "PersonaVinculante = oid", Context = "DetailView", Enabled = false)]
        public Persona PersonaVinculante
        {
            get { return _fPersonaVinculante; }
            set { SetPropertyValue("PersonaVinculante", ref _fPersonaVinculante, value); }
        }

        [RuleRequiredField]
        [System.ComponentModel.DisplayName("Tipo de relación")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public RelacionTipo RelacionTipo
        {
            get { return _fRelacionTipo; }
            set { SetPropertyValue("RelacionTipo", ref _fRelacionTipo, value); }
        }

        [RuleRequiredField]
        [Association(@"RelacionesReferencesPersonas-Vinculado")]
        [System.ComponentModel.DisplayName("Persona vinculada")]
        //[Appearance("PersonaVinculanteRule", AppearanceItemType = "ViewItem", TargetItems = "PersonaVinculado", Criteria = "PersonaVinculante = oid", Context = "DetailView", Enabled = false)]
        public Persona PersonaVinculado
        {
            get { return _fPersonaVinculado; }
            set { SetPropertyValue("PersonaVinculado", ref _fPersonaVinculado, value); }
        }

        public DateTime Desde
        {
            get { return _fDesde; }
            set { SetPropertyValue<DateTime>("Desde", ref _fDesde, value); }
        }

        public DateTime Hasta
        {
            get { return _fHasta; }
            set { SetPropertyValue<DateTime>("Hasta", ref _fHasta, value); }
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