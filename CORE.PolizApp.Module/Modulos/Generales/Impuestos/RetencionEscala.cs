using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Impuestos
{
    [Persistent(@"impuestos.RetencionEscala")]
    //[DefaultClassOptions]
    [System.ComponentModel.DisplayName(@"Escala de retenciones")]
    [DefaultClassOptions]
public class RetencionEscala : BasicObject
    {
        private Impuesto _fImpuesto;
        private decimal _fImporte;
        private decimal _fImporteMaximo;
        private decimal _fImporteMinimo;
        private decimal _fMontoExcedente;
        private decimal _fPorcentajeExcedente;

        public RetencionEscala(Session session)
            : base(session)
        {
        }

        [Association(@"RetencionesEscalaReferencesImpuestos")]
        public Impuesto Impuesto
        {
            get { return _fImpuesto; }
            set { SetPropertyValue("Impuesto", ref _fImpuesto, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal ImporteMinimo
        {
            get { return _fImporteMinimo; }
            set { SetPropertyValue<decimal>("ImporteMinimo", ref _fImporteMinimo, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal ImporteMaximo
        {
            get { return _fImporteMaximo; }
            set { SetPropertyValue<decimal>("ImporteMaximo", ref _fImporteMaximo, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal Importe
        {
            get { return _fImporte; }
            set { SetPropertyValue<decimal>("Importe", ref _fImporte, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal PorcentajeExcedente
        {
            get { return _fPorcentajeExcedente; }
            set { SetPropertyValue<decimal>("PorcentajeExcedente", ref _fPorcentajeExcedente, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal MontoExcedente
        {
            get { return _fMontoExcedente; }
            set { SetPropertyValue<decimal>("MontoExcedente", ref _fMontoExcedente, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}