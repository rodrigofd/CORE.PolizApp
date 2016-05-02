using System.ComponentModel;
using CORE.PolizApp.Personas;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.Banco")]
    [System.ComponentModel.DisplayName(@"Bancos")]
    [DefaultClassOptions]
public class Banco : BasicObject
    {
        private string _fCodigo;
        private int _fOrden;
        private Persona _fPersona;

        public Banco(Session session) : base(session)
        {
        }

        [Indexed(Name = @"iPersona_fondos_Banco_3C6DE2CE")]
        //[RuleRequiredField]
        [System.ComponentModel.DisplayName(@"Persona")]
        public Persona Persona
        {
            get { return _fPersona; }
            set { SetPropertyValue("Persona", ref _fPersona, value); }
        }

        [Size(50)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
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