using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace CORE.PolizApp.Fondos
{
    [NonPersistent]
    [System.ComponentModel.DisplayName(@"Boleta de Dep�sito")]
    public class ValorDeposito : BasicObject
    {
        //[VisibleInDetailView(false)]
        private Cuenta fCuentaADepositar;
        //[Association(@"fondos_ValorReferencesfondos_Cuenta")]

        private int fNumero;

        public ValorDeposito(Session session) : base(session)
        {
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        public Cuenta CuentaADepositar
        {
            get { return fCuentaADepositar; }
            set { SetPropertyValue("CuentaADepositar", ref fCuentaADepositar, value); }
        }

        [RuleRequiredField]
        [System.ComponentModel.DisplayName(@"N�mero")]
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