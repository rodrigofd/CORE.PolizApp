using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.NegocioRamoPlan")]
    public class NegocioRamoPlan : BasicObject
    {
        private string _fBeneficios;
        private string _fCodigo;
        private string _fDeducible;
        private string _fDetalle;
        private NegocioRamo _fNegocioRamo;
        private string _fNombre;

        public NegocioRamoPlan(Session session) : base(session)
        {
        }

        [Association(@"NegocioRamoPlanReferencesNegocioRamo")]
        public NegocioRamo NegocioRamo
        {
            get { return _fNegocioRamo; }
            set { SetPropertyValue("NegocioRamo", ref _fNegocioRamo, value); }
        }

        [Size(50)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Detalle
        {
            get { return _fDetalle; }
            set { SetPropertyValue("Detalle", ref _fDetalle, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Deducible
        {
            get { return _fDeducible; }
            set { SetPropertyValue("Deducible", ref _fDeducible, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Beneficios
        {
            get { return _fBeneficios; }
            set { SetPropertyValue("Beneficios", ref _fBeneficios, value); }
        }

        [Association(@"CoberturaPlanReferencesNegocioRamoPlan")]
        public XPCollection<CoberturaPlan> CoberturaPlanes => GetCollection<CoberturaPlan>("CoberturaPlanes");
    }
}