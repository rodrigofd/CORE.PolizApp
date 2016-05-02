using System;
using CORE.PolizApp.Impuestos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace CORE.PolizApp.Personas
{
    [ImageName("bank--pencil")]
    [Persistent(@"personas.PersonaImpuesto")]
    [System.ComponentModel.DisplayName("Datos impositivos")]
    [DefaultProperty("Categoria")]
    [DefaultClassOptions]
public class PersonaImpuesto : BasicObject
    {
        private Categoria _fCategoria;
        private DateTime _fDesde;
        private DateTime _fHasta;
        private Impuesto _f;
        private string _fNotas;
        private bool _fPercepcion;
        private Persona _fPersona;
        private Regimen _fRegimen;
        private bool _fRetencion;

        public PersonaImpuesto(Session session)
            : base(session)
        {
        }

        [Association(@"PersonasImpuestosReferencesPersonas")]
        public Persona Persona
        {
            get { return _fPersona; }
            set { SetPropertyValue("Persona", ref _fPersona, value); }
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
        [System.ComponentModel.DisplayName(@"Categoría de impuesto")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public Categoria Categoria
        {
            get { return _fCategoria; }
            set
            {
                SetPropertyValue("Categoria", ref _fCategoria, value);
                //Impuesto = Categoria.Impuesto;
            }
        }

        [ImmediatePostData]
        [DataSourceProperty("Impuesto.Regimenes")]
        [System.ComponentModel.DisplayName(@"Regimen del impuesto")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public Regimen Regimen
        {
            get { return _fRegimen; }
            set { SetPropertyValue("Regimen", ref _fRegimen, value); }
        }

        [System.ComponentModel.DisplayName(@"Agente de retención")]
        public bool AgenteRetencion
        {
            get { return _fRetencion; }
            set { SetPropertyValue("Retencion", ref _fRetencion, value); }
        }

        [System.ComponentModel.DisplayName("Agente de percepción")]
        public bool AgentePercepcion
        {
            get { return _fPercepcion; }
            set { SetPropertyValue("Percepcion", ref _fPercepcion, value); }
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