using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Fondos
{
    [NonPersistent]
    [System.ComponentModel.DisplayName(@"Boleta de Depósito")]
    public class fondos_ValorDeposito : BasicObject
    {
        //[VisibleInDetailView(false)]
        private fondos_Cuenta fCuentaADepositar;
        //[Association(@"fondos_ValorReferencesfondos_Cuenta")]

        private int fNumero;

        public fondos_ValorDeposito(Session session) : base(session)
        {
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        public fondos_Cuenta CuentaADepositar
        {
            get { return fCuentaADepositar; }
            set { SetPropertyValue("CuentaADepositar", ref fCuentaADepositar, value); }
        }

        [RuleRequiredField]
        [System.ComponentModel.DisplayName(@"Número")]
        public int Numero
        {
            get { return fNumero; }
            set { SetPropertyValue<int>("Numero", ref fNumero, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}