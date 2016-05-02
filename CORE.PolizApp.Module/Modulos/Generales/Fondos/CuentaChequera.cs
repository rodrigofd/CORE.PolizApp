using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.CuentaChequera")]
    [System.ComponentModel.DisplayName(@"Chequeras")]
    [DefaultClassOptions]
public class CuentaChequera : BasicObject
    {
        private Cuenta _fCuenta;
        private int _fNumeroDesde;
        private int _fNumeroHasta;
        private string _fSerie;

        public CuentaChequera(Session session) : base(session)
        {
        }

        [Association(@"fondos_CuentaChequeraReferencesfondos_Cuenta")]
        public Cuenta Cuenta
        {
            get { return _fCuenta; }
            set { SetPropertyValue("Cuenta", ref _fCuenta, value); }
        }

        [Size(3)]
        public string Serie
        {
            get { return _fSerie; }
            set { SetPropertyValue("Serie", ref _fSerie, value); }
        }

        public int NumeroDesde
        {
            get { return _fNumeroDesde; }
            set { SetPropertyValue<int>("NumeroDesde", ref _fNumeroDesde, value); }
        }

        public int NumeroHasta
        {
            get { return _fNumeroHasta; }
            set { SetPropertyValue<int>("NumeroHasta", ref _fNumeroHasta, value); }
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