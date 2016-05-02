using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.PersonaPropiedad")]
    [DefaultProperty("PersonaPropiedadID")]
    [System.ComponentModel.DisplayName(@"Propiedad de la persona")]
    [DefaultClassOptions]
public class PersonaPropiedad : BasicObject
    {
        private DateTime _fDesde;
        private DateTime _fHasta;
        private string _fNotas;
        private Persona _fPersona;
        private Propiedad _fPropiedad;
        private PropiedadValor _fPropiedadValor;
        private string _fValor;

        public PersonaPropiedad(Session session) : base(session)
        {
        }

        //TODO: que es esto?
        [VisibleInDetailView(false)]
        [PersistentAlias("ToStr(IsNull(PropiedadValor.Valor, Valor))")]
        //[PersistentAlias("concat('(', ToStr(Registro.RegistroID), '-', ToStr(Escribano.EscribanoID), ')')")]
        [System.ComponentModel.DisplayName(@"Propiedad")]
        public string PersonaPropiedadId
        {
            get { return Convert.ToString(EvaluateAlias("PersonaPropiedadID")); }
        }

        [Association(@"PersonasPropiedadesReferencesPersonas")]
        public Persona Persona
        {
            get { return _fPersona; }
            set { SetPropertyValue("Persona", ref _fPersona, value); }
        }

        [System.ComponentModel.DisplayName(@"Propiedad")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [ImmediatePostData]
        public Propiedad Propiedad
        {
            get { return _fPropiedad; }
            set { SetPropertyValue("Propiedad", ref _fPropiedad, value); }
        }

        [VisibleInListView(false)]
        [DataSourceProperty("Propiedad.Valores")]
        [System.ComponentModel.DisplayName(@"Valor (predefinido)")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [ImmediatePostData]
        public PropiedadValor PropiedadValor
        {
            get { return _fPropiedadValor; }
            set { SetPropertyValue("PropiedadValor", ref _fPropiedadValor, value); }
        }

        [VisibleInListView(false)]
        //[Appearance( "valor_predefinido", Criteria = "Not IsNull(PropiedadValor)", Visibility = ViewItemVisibility.Hide )]
        [System.ComponentModel.DisplayName("Valor (otro)")]
        [Size(SizeAttribute.Unlimited)]
        public string Valor
        {
            get { return _fValor; }
            set { SetPropertyValue("Valor", ref _fValor, value); }
        }

        //[VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [PersistentAlias("IIF(ISNULL(Valor), PropiedadValor, Valor)")]
        [System.ComponentModel.DisplayName(@"Valor")]
        public string ValorDefinido => Convert.ToString(EvaluateAlias("ValorDefinido"));

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
            get { return _fNotas; }
            set { SetPropertyValue("Notas", ref _fNotas, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}