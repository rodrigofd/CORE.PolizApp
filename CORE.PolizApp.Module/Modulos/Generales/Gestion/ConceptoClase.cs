using System.ComponentModel;
using CORE.ES.Module.Modulos.Escribania;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Gestion
{
    /*
    public enum ConceptoClase
    {
    No Gravado = 1,
    Gravado = 2,
    Impuesto = 3
    }
    */

    [Persistent(@"gestion.ConceptoClase")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Conceptos Clases")]
    public class ConceptoClase : BasicObject
    {
        private string fNombre;

        public ConceptoClase(Session session) : base(session)
        {
        }

        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [Browsable(false)]
        [Aggregated]
        [Association(@"ConceptosReferencesConceptosClases", typeof (Concepto))]
        public XPCollection<Concepto> Conceptos
        {
            get { return GetCollection<Concepto>("Conceptos"); }
        }

        /*[Browsable(false)]
        [Aggregated]
        [Association(@"escribania_ProvComprobanteItemReferencesConceptosClases", typeof(escribania_ProvComprobanteItem))]
        public XPCollection<escribania_ProvComprobanteItem> escribania_ProvComprobanteItems
        {
            get { return GetCollection<escribania_ProvComprobanteItem>("escribania_ProvComprobanteItems"); }
        }
        */

        /*
        [Browsable(false)]
        [Aggregated]
        [Association(@"escribania_ClieComprobanteItemReferencesConceptosClases", typeof(escribania_ClieComprobanteItem))]
        public XPCollection<escribania_ClieComprobanteItem> escribania_ClieComprobanteItems
        {
            get { return GetCollection<escribania_ClieComprobanteItem>("escribania_ClieComprobanteItems"); }
        }

        [Browsable(false)]
        [Aggregated]
        [Association(@"escribania_ClieComprobanteProformaItemReferencesConceptosClases",
            typeof (escribania_ClieComprobanteProformaItem))]
        public XPCollection<escribania_ClieComprobanteProformaItem> escribania_ClieComprobanteProformaItems
        {
            get
            {
                return GetCollection<escribania_ClieComprobanteProformaItem>("escribania_ClieComprobanteProformaItems");
            }
        }
        */
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }
    }
}