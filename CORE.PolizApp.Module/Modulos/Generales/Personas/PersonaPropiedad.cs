using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.PersonaPropiedad")]
    [DefaultProperty("PersonaPropiedadID")]
    [System.ComponentModel.DisplayName(@"Propiedad de la persona")]
    public class PersonaPropiedad : BasicObject
    {
        private DateTime fDesde;
        private DateTime fHasta;
        private string fNotas;
        private Persona fPersona;
        private Propiedad fPropiedad;
        private PropiedadValor fPropiedadValor;
        private string fValor;

        public PersonaPropiedad(Session session) : base(session)
        {
        }

        //TODO: que es esto?
        [VisibleInDetailView(false)]
        [PersistentAlias("ToStr(IsNull(PropiedadValor.Valor, Valor))")]
        //[PersistentAlias("concat('(', ToStr(Registro.RegistroID), '-', ToStr(Escribano.EscribanoID), ')')")]
        [System.ComponentModel.DisplayName(@"Propiedad")]
        public string PersonaPropiedadID
        {
            get { return Convert.ToString(EvaluateAlias("PersonaPropiedadID")); }
        }

        [Association(@"PersonasPropiedadesReferencesPersonas")]
        public Persona Persona
        {
            get { return fPersona; }
            set { SetPropertyValue("Persona", ref fPersona, value); }
        }

        [System.ComponentModel.DisplayName(@"Propiedad")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [ImmediatePostData]
        public Propiedad Propiedad
        {
            get { return fPropiedad; }
            set { SetPropertyValue("Propiedad", ref fPropiedad, value); }
        }

        [VisibleInListView(false)]
        [DataSourceProperty("Propiedad.Valores")]
        [System.ComponentModel.DisplayName(@"Valor (predefinido)")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [ImmediatePostData]
        public PropiedadValor PropiedadValor
        {
            get { return fPropiedadValor; }
            set { SetPropertyValue("PropiedadValor", ref fPropiedadValor, value); }
        }

        [VisibleInListView(false)]
        //[Appearance( "valor_predefinido", Criteria = "Not IsNull(PropiedadValor)", Visibility = ViewItemVisibility.Hide )]
        [System.ComponentModel.DisplayName("Valor (otro)")]
        [Size(SizeAttribute.Unlimited)]
        public string Valor
        {
            get { return fValor; }
            set { SetPropertyValue("Valor", ref fValor, value); }
        }

        //[VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [PersistentAlias("IIF(ISNULL(Valor), PropiedadValor, Valor)")]
        [System.ComponentModel.DisplayName(@"Valor")]
        public string ValorDefinido => Convert.ToString(EvaluateAlias("ValorDefinido"));

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