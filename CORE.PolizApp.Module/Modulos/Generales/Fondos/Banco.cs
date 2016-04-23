using System;
using System.ComponentModel;
using CORE.PolizApp.Personas;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Fondos
{
    [Persistent(@"fondos.Banco")]
    [DefaultProperty("BancoID")]
    [System.ComponentModel.DisplayName(@"Bancos")]
    public class fondos_Banco : BasicObject
    {
        private string fCodigo;
        private int fOrden;
        private Persona fPersona;

        public fondos_Banco(Session session) : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [System.ComponentModel.DisplayName(@"Banco")]
        //[PersistentAlias("concat(EscribanoRegistro.EscribanoRegistroID, '-', ToStr(Numero), '-', ToStr(escribania_Protocolo.MIN(Folio)), ' (', Trim(SubString(ToStr(Fecha), 0, 10)), ') ')")]
        [PersistentAlias("Codigo")]
        public string BancoID
        {
            get { return Convert.ToString(EvaluateAlias("BancoID")); }
        }

        [Indexed(Name = @"iPersona_fondos_Banco_3C6DE2CE")]
        [Association(@"BancoReferencesPersonas")]
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

        [Association(@"fondos_CuentaReferencesfondos_Banco", typeof (fondos_Cuenta))]
        public XPCollection<fondos_Cuenta> fondos_Cuenta
        {
            get { return GetCollection<fondos_Cuenta>("fondos_Cuenta"); }
        }

        [Association(@"fondos_ValorReferencesfondos_Banco", typeof (fondos_Valor))]
        public XPCollection<fondos_Valor> fondos_Valor
        {
            get { return GetCollection<fondos_Valor>("fondos_Valor"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}