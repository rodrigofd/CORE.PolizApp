using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Impuestos
{
    [Persistent(@"impuestos.Regimen")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Regímenes de impuestos")]
    public class impuestos_Regimen : BasicObject
    {
        private decimal fAlicuotaInscripto;
        private decimal fAlicuotaNoInscripto;
        private string fCodigo;
        private impuestos_Impuesto fImpuesto;
        private decimal fMinimoNoImponible;
        private string fNombre;

        public impuestos_Regimen(Session session)
            : base(session)
        {
        }

        [Association(@"RegimenesReferencesImpuestos")]
        public impuestos_Impuesto Impuesto
        {
            get { return fImpuesto; }
            set { SetPropertyValue("Impuesto", ref fImpuesto, value); }
        }

        [Size(50)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Index(1)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal AlicuotaInscripto
        {
            get { return fAlicuotaInscripto; }
            set { SetPropertyValue<decimal>("AlicuotaInscripto", ref fAlicuotaInscripto, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal AlicuotaNoInscripto
        {
            get { return fAlicuotaNoInscripto; }
            set { SetPropertyValue<decimal>("AlicuotaNoInscripto", ref fAlicuotaNoInscripto, value); }
        }

        [ModelDefault("DisplayFormat", "n2")]
        public decimal MinimoNoImponible
        {
            get { return fMinimoNoImponible; }
            set { SetPropertyValue<decimal>("MinimoNoImponible", ref fMinimoNoImponible, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}