using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.Cuenta")]
    [System.ComponentModel.DisplayName(@"Cuentas")]
    public class Cuenta : BasicObject
    {
        private Banco fBanco;
        private CuentaClase fClase;
        private string fCodigo;
        private bool fControlaChequera;
        private int fCuentaContable;
        private bool fDisponibilidad;
        private bool fEmiteCheque;
        private Especie fEspeciePredeterminada;
        private bool fExigeApertura;
        private Moneda fMoneda;
        private string fNombre;
        private string fNotas;
        private string fNumeroCuenta;
        private int fOrden;
        private string fSucursal;

        public Cuenta(Session session) : base(session)
        {
        }
        
        public CuentaClase Clase
        {
            get { return fClase; }
            set { SetPropertyValue("Clase", ref fClase, value); }
        }

        [Size(20)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [Association(@"fondos_CuentaReferencesfondos_Banco")]
        public Banco Banco
        {
            get { return fBanco; }
            set { SetPropertyValue("Banco", ref fBanco, value); }
        }

        [Size(10)]
        public string Sucursal
        {
            get { return fSucursal; }
            set { SetPropertyValue("Sucursal", ref fSucursal, value); }
        }

        [Size(20)]
        public string NumeroCuenta
        {
            get { return fNumeroCuenta; }
            set { SetPropertyValue("NumeroCuenta", ref fNumeroCuenta, value); }
        }

        [Indexed(Name = @"iMoneda_fondos_Cuenta_3A53ABF1")]
        [Association(@"fondos_CuentaReferencesfondos_Moneda")]
        public Moneda Moneda
        {
            get { return fMoneda; }
            set { SetPropertyValue("Moneda", ref fMoneda, value); }
        }

        [Indexed(Name = @"iEspeciePredeterminada_fondos_Cuenta_B372CC91")]
        [Association(@"fondos_CuentaReferencesfondos_Especie")]
        public Especie EspeciePredeterminada
        {
            get { return fEspeciePredeterminada; }
            set { SetPropertyValue("EspeciePredeterminada", ref fEspeciePredeterminada, value); }
        }

        public bool EmiteCheque
        {
            get { return fEmiteCheque; }
            set { SetPropertyValue("EmiteCheque", ref fEmiteCheque, value); }
        }

        public bool ControlaChequera
        {
            get { return fControlaChequera; }
            set { SetPropertyValue("ControlaChequera", ref fControlaChequera, value); }
        }

        public int Orden
        {
            get { return fOrden; }
            set { SetPropertyValue<int>("Orden", ref fOrden, value); }
        }

        public bool Disponibilidad
        {
            get { return fDisponibilidad; }
            set { SetPropertyValue("Disponibilidad", ref fDisponibilidad, value); }
        }

        public string Notas
        {
            get { return fNotas; }
            set { SetPropertyValue("Notas", ref fNotas, value); }
        }

        public bool ExigeApertura
        {
            get { return fExigeApertura; }
            set { SetPropertyValue("ExigeApertura", ref fExigeApertura, value); }
        }

        [Indexed(Name = @"iCuentaContable_fondos_Cuenta_06BE37F6")]
        public int CuentaContable
        {
            get { return fCuentaContable; }
            set { SetPropertyValue<int>("CuentaContable", ref fCuentaContable, value); }
        }

        [Association(@"fondos_CuentaChequeraReferencesfondos_Cuenta", typeof (CuentaChequera))]
        public XPCollection<CuentaChequera> Chequeras => GetCollection<CuentaChequera>("Chequeras");

        [Association(@"fondos_ValorReferencesfondos_Cuenta", typeof (Valor))]
        public XPCollection<Valor> Valores => GetCollection<Valor>("Valores");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}