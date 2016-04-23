using System;
using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Fondos
{
    [Persistent(@"fondos.CuentaChequera")]
    [DefaultProperty("ChequeraID")]
    [System.ComponentModel.DisplayName(@"Chequeras")]
    public class fondos_CuentaChequera : BasicObject
    {
        private fondos_Cuenta fCuenta;
        private int fNumeroDesde;
        private int fNumeroHasta;
        private string fSerie;

        public fondos_CuentaChequera(Session session) : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [System.ComponentModel.DisplayName(@"Chequera")]
        //[PersistentAlias("concat(EscribanoRegistro.EscribanoRegistroID, '-', ToStr(Numero), '-', ToStr(escribania_Protocolo.MIN(Folio)), ' (', Trim(SubString(ToStr(Fecha), 0, 10)), ') ')")]
        [PersistentAlias("Serie")]
        public string ChequeraID
        {
            get { return Convert.ToString(EvaluateAlias("ChequeraID")); }
        }

        [Association(@"fondos_CuentaChequeraReferencesfondos_Cuenta")]
        public fondos_Cuenta Cuenta
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