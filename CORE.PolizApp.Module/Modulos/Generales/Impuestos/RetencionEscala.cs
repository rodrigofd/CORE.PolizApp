using CORE.General.Modulos.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Impuestos
{
    [Persistent(@"impuestos.RetencionEscala")]
    //[DefaultClassOptions]
    [System.ComponentModel.DisplayName(@"Escala de retenciones")]
    public class impuestos_RetencionEscala : BasicObject
    {
        private decimal fImporte;
        private decimal fImporteMaximo;
        private decimal fImporteMinimo;
        private impuestos_Impuesto fImpuesto;
        private decimal fMontoExcedente;
        private decimal fPorcentajeExcedente;

        public impuestos_RetencionEscala(Session session)
            : base(session)
        {
        }

        [Association(@"RetencionesEscalaReferencesImpuestos")]
        public impuestos_Impuesto Impuesto
        {
            get { return fImpuesto; }
            set { SetPropertyValue("Impuesto", ref fImpuesto, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal ImporteMinimo
        {
            get { return fImporteMinimo; }
            set { SetPropertyValue<decimal>("ImporteMinimo", ref fImporteMinimo, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal ImporteMaximo
        {
            get { return fImporteMaximo; }
            set { SetPropertyValue<decimal>("ImporteMaximo", ref fImporteMaximo, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal Importe
        {
            get { return fImporte; }
            set { SetPropertyValue<decimal>("Importe", ref fImporte, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal PorcentajeExcedente
        {
            get { return fPorcentajeExcedente; }
            set { SetPropertyValue<decimal>("PorcentajeExcedente", ref fPorcentajeExcedente, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal MontoExcedente
        {
            get { return fMontoExcedente; }
            set { SetPropertyValue<decimal>("MontoExcedente", ref fMontoExcedente, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}