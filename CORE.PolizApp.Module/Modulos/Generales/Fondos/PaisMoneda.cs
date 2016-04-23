using CORE.General.Modulos.Regionales;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Fondos
{
    [Persistent(@"fondos.PaisMoneda")]
    //[DefaultClassOptions]
    [System.ComponentModel.DisplayName(@"Moneda del país")]
    public class fondos_PaisMoneda : BasicObject
    {
        private fondos_Moneda fMoneda;
        private regionales_Pais fPais;

        public fondos_PaisMoneda(Session session)
            : base(session)
        {
        }

        public regionales_Pais Pais
        {
            get { return fPais; }
            set { SetPropertyValue("Pais", ref fPais, value); }
        }

        public fondos_Moneda Moneda
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