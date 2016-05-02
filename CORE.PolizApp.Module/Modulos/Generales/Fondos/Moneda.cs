using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.Moneda")]
    //[DefaultClassOptions]
    [System.ComponentModel.DisplayName(@"Moneda")]
    [DefaultClassOptions]
public class Moneda : BasicObject
    {
        private string _fCodigo;
        private string _fFraccional;
        private int _fFraccionalRelacion;
        private string _fMoneda;
        private string _fMonedaEng;
        private string _fSimbolo;

        public Moneda(Session session) : base(session)
        {
        }
        
        [Size(50)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(70)]
        [Index(1)]
        public string Nombre
        {
            get { return _fMoneda; }
            set { SetPropertyValue("Nombre", ref _fMoneda, value); }
        }

        [Size(4)]
        [System.ComponentModel.DisplayName(@"Símbolo")]
        public string Simbolo
        {
            get { return _fSimbolo; }
            set { SetPropertyValue("Simbolo", ref _fSimbolo, value); }
        }

        [Size(70)]
        [System.ComponentModel.DisplayName(@"Nombre (inglés)")]
        public string MonedaEng
        {
            get { return _fMonedaEng; }
            set { SetPropertyValue("MonedaEng", ref _fMonedaEng, value); }
        }

        [Size(15)]
        [System.ComponentModel.DisplayName(@"Fraccional")]
        public string Fraccional
        {
            get { return _fFraccional; }
            set { SetPropertyValue("Fraccional", ref _fFraccional, value); }
        }

        [System.ComponentModel.DisplayName(@"Relación fraccional")]
        public int FraccionalRelacion
        {
            get { return _fFraccionalRelacion; }
            set { SetPropertyValue<int>("FraccionalRelacion", ref _fFraccionalRelacion, value); }
        }

        [Association(@"fondos_CuentaReferencesfondos_Moneda", typeof (Cuenta))]
        public XPCollection<Cuenta> Cuentas => GetCollection<Cuenta>("Cuentas");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}