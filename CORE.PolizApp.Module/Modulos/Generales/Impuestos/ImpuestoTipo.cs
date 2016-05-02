using System.ComponentModel;
using CORE.PolizApp.Gestion;
using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Impuestos
{
    [Persistent(@"impuestos.ImpuestoTipo")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Impuesto Tipo")]
    [DefaultClassOptions]
public class ImpuestoTipo : BasicObject
    {
        private Impuesto _fImpuesto;
        private string _fNombre;

        private int _fOrden;
        private decimal _fValor;

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
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Valor
        {
            get { return _fValor; }
            set { SetPropertyValue("Valor", ref _fValor, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
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