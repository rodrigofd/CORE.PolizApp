using System;
using System.ComponentModel;
using CORE.ES.Module.Modulos.Escribania;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Fondos
{
    [Persistent(@"fondos.Moneda")]
    //[DefaultClassOptions]
    [DefaultProperty("MonedaID")]
    [System.ComponentModel.DisplayName(@"Moneda")]
    public class fondos_Moneda : BasicObject
    {
        private string fCodigo;
        private string fFraccional;
        private int fFraccionalRelacion;
        private string fMoneda;
        private string fMonedaEng;
        private string fSimbolo;

        public fondos_Moneda(Session session) : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [System.ComponentModel.DisplayName(@"Moneda")]
        //[PersistentAlias("concat(EscribanoRegistro.EscribanoRegistroID, '-', ToStr(Numero), '-', ToStr(escribania_Protocolo.MIN(Folio)), ' (', Trim(SubString(ToStr(Fecha), 0, 10)), ') ')")]
        [PersistentAlias("Simbolo")]
        public string MonedaID
        {
            get { return Convert.ToString(EvaluateAlias("MonedaID")); }
        }

        [Size(50)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(70)]
        [Index(1)]
        public string Nombre
        {
            get { return fMoneda; }
            set { SetPropertyValue("Nombre", ref fMoneda, value); }
        }

        [Size(4)]
        [System.ComponentModel.DisplayName(@"Símbolo")]
        public string Simbolo
        {
            get { return fSimbolo; }
            set { SetPropertyValue("Simbolo", ref fSimbolo, value); }
        }

        [Size(70)]
        [System.ComponentModel.DisplayName(@"Nombre (inglés)")]
        public string MonedaEng
        {
            get { return fMonedaEng; }
            set { SetPropertyValue("MonedaEng", ref fMonedaEng, value); }
        }

        [Size(15)]
        [System.ComponentModel.DisplayName(@"Fraccional")]
        public string Fraccional
        {
            get { return fFraccional; }
            set { SetPropertyValue("Fraccional", ref fFraccional, value); }
        }

        [System.ComponentModel.DisplayName(@"Relación fraccional")]
        public int FraccionalRelacion
        {
            get { return fFraccionalRelacion; }
            set { SetPropertyValue<int>("FraccionalRelacion", ref fFraccionalRelacion, value); }
        }

        [Association(@"fondos_CuentaReferencesfondos_Moneda", typeof (fondos_Cuenta))]
        public XPCollection<fondos_Cuenta> fondos_Cuenta
        {
            get { return GetCollection<fondos_Cuenta>("fondos_Cuenta"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}