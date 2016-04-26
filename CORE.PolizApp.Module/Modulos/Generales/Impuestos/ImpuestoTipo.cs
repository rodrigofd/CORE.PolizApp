using System.ComponentModel;
using CORE.PolizApp.Gestion;
using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo;

namespace CORE.PolizApp.Impuestos
{
    [Persistent(@"impuestos.ImpuestoTipo")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Impuesto Tipo")]
    public class ImpuestoTipo : BasicObject
    {
        private Impuesto _fImpuesto;
        private string fNombre;

        private int fOrden;
        private decimal fValor;

        public ImpuestoTipo(Session session)
            : base(session)
        {
        }

        [Association(@"ImpuestoTipoReferencesImpuestos")]
        public Impuesto Impuesto
        {
            get { return _fImpuesto; }
            set { SetPropertyValue("Impuesto", ref _fImpuesto, value); }
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

        public int Orden
        {
            get { return fOrden; }
            set { SetPropertyValue<int>("Orden", ref fOrden, value); }
        }


        [Browsable(false)]
        [Association(@"ConceptosReferencesimpuestos_ImpuestoTipo", typeof (Concepto))]
        public XPCollection<Concepto> Conceptos => GetCollection<Concepto>("Conceptos");
        
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}