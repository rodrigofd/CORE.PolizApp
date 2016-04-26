using System;
using CORE.PolizApp.Impuestos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CORE.PolizApp.Personas
{
    [ImageName("bank--pencil")]
    [Persistent(@"personas.PersonaImpuesto")]
    [System.ComponentModel.DisplayName("Datos impositivos")]
    [DefaultProperty("Categoria")]
    public class PersonaImpuesto : BasicObject
    {
        private Categoria fCategoria;
        private DateTime fDesde;
        private DateTime fHasta;
        private Impuesto _f;
        private string fNotas;
        private bool fPercepcion;
        private Persona fPersona;
        private Regimen fRegimen;
        private bool fRetencion;

        public PersonaImpuesto(Session session)
            : base(session)
        {
        }

        [Association(@"PersonasImpuestosReferencesPersonas")]
        public Persona Persona
        {
            get { return fPersona; }
            set { SetPropertyValue("Persona", ref fPersona, value); }
        }

        //TODO: en la grid aparece en null
//    [ NonPersistent ]
//    [ImmediatePostData]
//    public Impuesto Impuesto{ get; set; }

        [ImmediatePostData]
        public Impuesto Impuesto 
        {
            get { return _f; }
            set { SetPropertyValue("Impuesto", ref _f, value); }
        }

        [DataSourceProperty("Impuesto.Categorias")]
        [System.ComponentModel.DisplayName(@"Categor�a de impuesto")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public Categoria Categoria
        {
            get { return fCategoria; }
            set
            {
                SetPropertyValue("Categoria", ref fCategoria, value);
                //Impuesto = Categoria.Impuesto;
            }
        }

        [ImmediatePostData]
        [DataSourceProperty("Impuesto.Regimenes")]
        [System.ComponentModel.DisplayName(@"Regimen del impuesto")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public Regimen Regimen
        {
            get { return fRegimen; }
            set { SetPropertyValue("Regimen", ref fRegimen, value); }
        }

        [System.ComponentModel.DisplayName(@"Agente de retenci�n")]
        public bool AgenteRetencion
        {
            get { return fRetencion; }
            set { SetPropertyValue("Retencion", ref fRetencion, value); }
        }

        [System.ComponentModel.DisplayName("Agente de percepci�n")]
        public bool AgentePercepcion
        {
            get { return fPercepcion; }
            set { SetPropertyValue("Percepcion", ref fPercepcion, value); }
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