using CORE.PolizApp.Regionales;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.PaisMoneda")]
    //[DefaultClassOptions]
    [System.ComponentModel.DisplayName(@"Moneda del pa�s")]
    public class PaisMoneda : BasicObject
    {
        private Moneda fMoneda;
        private Pais fPais;

        public PaisMoneda(Session session)
            : base(session)
        {
        }

        public Pais Pais
        {
            get { return fPais; }
            set { SetPropertyValue("Pais", ref fPais, value); }
        }

        public Moneda Moneda
        {
            get { return fMoneda; }
            set { SetPropertyValue("Moneda", ref fMoneda, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}