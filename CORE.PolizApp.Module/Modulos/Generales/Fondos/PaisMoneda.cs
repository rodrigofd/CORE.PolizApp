using CORE.PolizApp.Regionales;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.PaisMoneda")]
    //[DefaultClassOptions]
    [System.ComponentModel.DisplayName(@"Moneda del país")]
    [DefaultClassOptions]
public class PaisMoneda : BasicObject
    {
        private Moneda _fMoneda;
        private Pais _fPais;

        public PaisMoneda(Session session)
            : base(session)
        {
        }

        public Pais Pais
        {
            get { return _fPais; }
            set { SetPropertyValue("Pais", ref _fPais, value); }
        }

        public Moneda Moneda
        {
            get { return _fMoneda; }
            set { SetPropertyValue("Moneda", ref _fMoneda, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}