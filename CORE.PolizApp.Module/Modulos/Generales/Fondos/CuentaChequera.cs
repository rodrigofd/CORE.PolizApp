using CORE.PolizApp.Sistema;
using DevExpress.Xpo;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.CuentaChequera")]
    [System.ComponentModel.DisplayName(@"Chequeras")]
    public class CuentaChequera : BasicObject
    {
        private Cuenta fCuenta;
        private int fNumeroDesde;
        private int fNumeroHasta;
        private string fSerie;

        public CuentaChequera(Session session) : base(session)
        {
        }

        [Association(@"fondos_CuentaChequeraReferencesfondos_Cuenta")]
        public Cuenta Cuenta
        {
            get { return fCuenta; }
            set { SetPropertyValue("Cuenta", ref fCuenta, value); }
        }

        [Size(3)]
        public string Serie
        {
            get { return fSerie; }
            set { SetPropertyValue("Serie", ref fSerie, value); }
        }

        public int NumeroDesde
        {
            get { return fNumeroDesde; }
            set { SetPropertyValue<int>("NumeroDesde", ref fNumeroDesde, value); }
        }

        public int NumeroHasta
        {
            get { return fNumeroHasta; }
            set { SetPropertyValue<int>("NumeroHasta", ref fNumeroHasta, value); }
        }

        /*
        int fUltimoNumero;
        public int UltimoNumero
        {
            get { return fUltimoNumero; }
            set { SetPropertyValue<int>("UltimoNumero", ref fUltimoNumero, value); }
        }
        */

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}