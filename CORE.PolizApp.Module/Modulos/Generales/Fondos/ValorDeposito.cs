using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Fondos
{
    [NonPersistent]
    [System.ComponentModel.DisplayName(@"Boleta de Depósito")]
    [DefaultClassOptions]
public class ValorDeposito : BasicObject
    {
        //[VisibleInDetailView(false)]
        private Cuenta _fCuentaADepositar;
        //[Association(@"fondos_ValorReferencesfondos_Cuenta")]

        private int _fNumero;

        public ValorDeposito(Session session) : base(session)
        {
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        public Cuenta CuentaADepositar
        {
            get { return _fCuentaADepositar; }
            set { SetPropertyValue("CuentaADepositar", ref _fCuentaADepositar, value); }
        }

        [RuleRequiredField]
        [System.ComponentModel.DisplayName(@"Número")]
        public int Numero
        {
            get { return _fNumero; }
            set { SetPropertyValue<int>("Numero", ref _fNumero, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}