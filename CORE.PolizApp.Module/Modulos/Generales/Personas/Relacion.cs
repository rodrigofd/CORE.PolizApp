using System;
using System.Drawing;
using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

//using CORE.PolizApp.Sistema;

namespace CORE.PolizApp.Personas
{
    [ImageName("group_link")]
    [Persistent(@"personas.Relacion")]
    [System.ComponentModel.DisplayName("Relación")]
    //[Appearance("CriteriaRelacionDelete", "Padre < 0 ", AppearanceItemType = "Action", Enabled = false, TargetItems = "Delete")]
    [Appearance("CriteriaRelacionBold", "Padre < 0 ", AppearanceItemType = "ViewItem", FontStyle = FontStyle.Bold, TargetItems = "PersonaVinculadoID")]
    [RuleCriteria("RuleCriteriaNotNulls", DefaultContexts.Save, "Not (PersonaVinculado is null AND Notas is null)", "Persona Vinculada o Notas debe Informarse.", SkipNullOrEmptyValues = false)]
    public class Relacion : BasicObject
    {
        private DateTime fDesde;
        private DateTime fHasta;
        private string fNotas;
        private Persona fPadre;
        private Persona fPersonaVinculado;
        private Persona fPersonaVinculante;
        private RelacionTipo fRelacionTipo;

        public Relacion(Session session) : base(session)
        {
        }

        //[VisibleInListView(false)]
        //[PersistentAlias("Persona.OID")]
        //public Persona oid
        //{
        //    get { return ( Persona ) EvaluateAlias("oid"); }
        //}

        [RuleRequiredField]
        [Association(@"RelacionesReferencesPersonas-Vinculante")]
        [System.ComponentModel.DisplayName("Persona vinculante")]
        //[Appearance("PersonaVinculanteRule", AppearanceItemType = "ViewItem", TargetItems = "PersonaVinculante", Criteria = "PersonaVinculante = oid", Context = "DetailView", Enabled = false)]
        public Persona PersonaVinculante
        {
            get { return fPersonaVinculante; }
            set
            {
                SetPropertyValue("PersonaVinculante", ref fPersonaVinculante, value);
                if (!IsLoading && value != null)
                {
                    //PersonaVinculante = (Persona)value.Oid;
                    Padre = value;
                    PersonaVinculante = value;
                }
            }
        }

        [RuleRequiredField]
        [System.ComponentModel.DisplayName(@"Tipo de relación")] 
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public RelacionTipo RelacionTipo
        {
            get { return fRelacionTipo; }
            set { SetPropertyValue("RelacionTipo", ref fRelacionTipo, value); }
        }

        //[RuleRequiredField]
        [Association(@"RelacionesReferencesPersonas-Vinculado")]
        [System.ComponentModel.DisplayName("Persona vinculada")]
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

        [NonPersistent]
        public Persona Padre
        {
            get { return fPadre; }
            set { SetPropertyValue("Padre", ref fPadre, value); }
        }

        [VisibleInDetailView(false)]
        [System.ComponentModel.DisplayName(@"'Es' (Relación)")]
        [PersistentAlias("Iif(Padre == PersonaVinculado, RelacionTipo, RelacionTipo.RelacionTipoInverso)")]
        public RelacionTipo RelacionID
        {
            get { return (RelacionTipo) (EvaluateAlias("RelacionID")); }
        }

        [VisibleInDetailView(false)]
        [System.ComponentModel.DisplayName(@"'De' (Persona)")]
        //[PersistentAlias("Iif(Padre > 0, PersonaVinculado, PersonaVinculante)")]
        [PersistentAlias("Iif(Padre == PersonaVinculado, PersonaVinculante, Padre)")]
        public Persona PersonaVinculadoID
        {
            get { return (Persona) (EvaluateAlias("PersonaVinculadoID")); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            //Reload();
        }
    }
}