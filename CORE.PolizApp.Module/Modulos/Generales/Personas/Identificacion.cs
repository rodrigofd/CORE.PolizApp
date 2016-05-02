using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Personas
{
    [ImageName("cards_bind_address")]
    [Persistent(@"personas.Identificacion")]
    [DefaultProperty("Descripcion")]
    [System.ComponentModel.DisplayName(@"Identificación")]
    [DefaultClassOptions]
    public class Identificacion : BasicObject
    {
        private DateTime _fDesde;
        private DateTime _fHasta;
        private string _fNotas;
        private Persona _fPersona;
        private IdentificacionTipo _fTipo;
        private string _fValor;

        public Identificacion(Session session)
            : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [PersistentAlias("concat(Tipo.Codigo, ' - ' , Valor)")]
        public string Descripcion => Convert.ToString(EvaluateAlias("Descripcion"));

        [Association(@"IdentificacionesReferencesPersonas")]
        public Persona Persona
        {
            get { return _fPersona; }
            set { SetPropertyValue("Persona", ref _fPersona, value); }
        }

        [System.ComponentModel.DisplayName(@"Tipo")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public IdentificacionTipo Tipo
        {
            get { return _fTipo; }
            set { SetPropertyValue("Tipo", ref _fTipo, value); }
        }

        [Size(200)]
        [System.ComponentModel.DisplayName(@"Identificación")]
        public string Valor
        {
            get { return _fValor; }
            set { SetPropertyValue("Valor", ref _fValor, value); }
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
            get { return _fNotas; }
            set { SetPropertyValue("Notas", ref _fNotas, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}