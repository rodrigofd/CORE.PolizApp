using System.ComponentModel;
using CORE.General.Modulos.Gestion;
using CORE.General.Modulos.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Impuestos
{
    [Persistent(@"impuestos.ImpuestoTipo")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Impuesto Tipo")]
    public class impuestos_ImpuestoTipo : BasicObject
    {
        private impuestos_Impuesto fImpuesto;
        private string fNombre;
        private decimal fValor;

        public impuestos_ImpuestoTipo(Session session)
            : base(session)
        {
        }

        [Association(@"ImpuestoTipoReferencesImpuestos")]
        public impuestos_Impuesto Impuesto
        {
            get { return fImpuesto; }
            set { SetPropertyValue("Impuesto", ref fImpuesto, value); }
        }

        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Valor
        {
            get { return fValor; }
            set { SetPropertyValue("Valor", ref fValor, value); }
        }

        private int fOrden;
        public int Orden
        {
            get { return fOrden; }
            set { SetPropertyValue<int>("Orden", ref fOrden, value); }
        }


        [Browsable(false)]
        [Association(@"ConceptosReferencesimpuestos_ImpuestoTipo", typeof (Concepto))]
        public XPCollection<Concepto> Conceptos
        {
            get { return GetCollection<Concepto>("Conceptos"); }
        }

        /*
        [Association(@"escribania_ClieComprobanteItemReferencesimpuestos_Alicuota", typeof(escribania_ClieComprobanteItem))]
        public XPCollection<escribania_ClieComprobanteItem> ClieComprobanteItem
        {
            get { return GetCollection<escribania_ClieComprobanteItem>("ClieComprobanteItem"); }
        }
        [Browsable(false)]
        [Aggregated]
        [Association(@"escribania_ClieComprobanteProformaItemReferencesimpuestos_Alicuota")]
        public XPCollection<escribania_ClieComprobanteProformaItem> EscribaniaClieComprobanteProformaItem
        {
            get { return GetCollection<escribania_ClieComprobanteProformaItem>("EscribaniaClieComprobanteProformaItem"); }
        }
        */

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}