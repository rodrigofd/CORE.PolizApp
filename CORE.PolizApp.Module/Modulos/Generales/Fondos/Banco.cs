using System.ComponentModel;
using CORE.PolizApp.Personas;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.Banco")]
    [System.ComponentModel.DisplayName(@"Bancos")]
    public class Banco : BasicObject
    {
        private string fCodigo;
        private int fOrden;
        private Persona fPersona;

        public Banco(Session session) : base(session)
        {
        }

        [Indexed(Name = @"iPersona_fondos_Banco_3C6DE2CE")]
        //[RuleRequiredField]
        [System.ComponentModel.DisplayName(@"Persona")]
        public Persona Persona
        {
            get { return fPersona; }
            set { SetPropertyValue("Persona", ref fPersona, value); }
        }

        [Size(50)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        public int Orden
        {
            get { return fOrden; }
            set { SetPropertyValue<int>("Orden", ref fOrden, value); }
        }

        [Association(@"fondos_CuentaReferencesfondos_Banco", typeof (Cuenta))]
        public XPCollection<Cuenta> Cuentas => GetCollection<Cuenta>("Cuentas");

        [Association(@"fondos_ValorReferencesfondos_Banco", typeof (Valor))]
        public XPCollection<Valor> Valores => GetCollection<Valor>("Valores");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}