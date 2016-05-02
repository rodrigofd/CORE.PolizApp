using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Impuestos
{
    [Persistent(@"impuestos.Regimen")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Regímenes de impuestos")]
    [DefaultClassOptions]
public class Regimen : BasicObject
    {
        private decimal _fAlicuotaInscripto;
        private decimal _fAlicuotaNoInscripto;
        private string _fCodigo;
        private Impuesto _fImpuesto;
        private decimal _fMinimoNoImponible;
        private string _fNombre;

        public Regimen(Session session)
            : base(session)
        {
        }

        [Association(@"RegimenesReferencesImpuestos")]
        public Impuesto Impuesto
        {
            get { return _fImpuesto; }
            set { SetPropertyValue("Impuesto", ref _fImpuesto, value); }
        }

        [Size(50)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Index(1)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal AlicuotaInscripto
        {
            get { return _fAlicuotaInscripto; }
            set { SetPropertyValue<decimal>("AlicuotaInscripto", ref _fAlicuotaInscripto, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal AlicuotaNoInscripto
        {
            get { return _fAlicuotaNoInscripto; }
            set { SetPropertyValue<decimal>("AlicuotaNoInscripto", ref _fAlicuotaNoInscripto, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal MinimoNoImponible
        {
            get { return _fMinimoNoImponible; }
            set { SetPropertyValue<decimal>("MinimoNoImponible", ref _fMinimoNoImponible, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}