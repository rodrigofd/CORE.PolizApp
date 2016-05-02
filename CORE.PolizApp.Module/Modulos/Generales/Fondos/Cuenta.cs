using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.Cuenta")]
    [System.ComponentModel.DisplayName(@"Cuentas")]
    [DefaultClassOptions]
public class Cuenta : BasicObject
    {
        private Banco _fBanco;
        private CuentaClase _fClase;
        private string _fCodigo;
        private bool _fControlaChequera;
        private int _fCuentaContable;
        private bool _fDisponibilidad;
        private bool _fEmiteCheque;
        private Especie _fEspeciePredeterminada;
        private bool _fExigeApertura;
        private Moneda _fMoneda;
        private string _fNombre;
        private string _fNotas;
        private string _fNumeroCuenta;
        private int _fOrden;
        private string _fSucursal;

        public Cuenta(Session session) : base(session)
        {
        }
        
        public CuentaClase Clase
        {
            get { return _fClase; }
            set { SetPropertyValue("Clase", ref _fClase, value); }
        }

        [Size(20)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Association(@"fondos_CuentaReferencesfondos_Banco")]
        public Banco Banco
        {
            get { return _fBanco; }
            set { SetPropertyValue("Banco", ref _fBanco, value); }
        }

        [Size(10)]
        public string Sucursal
        {
            get { return _fSucursal; }
            set { SetPropertyValue("Sucursal", ref _fSucursal, value); }
        }

        [Size(20)]
        public string NumeroCuenta
        {
            get { return _fNumeroCuenta; }
            set { SetPropertyValue("NumeroCuenta", ref _fNumeroCuenta, value); }
        }

        [Indexed(Name = @"iMoneda_fondos_Cuenta_3A53ABF1")]
        [Association(@"fondos_CuentaReferencesfondos_Moneda")]
        public Moneda Moneda
        {
            get { return _fMoneda; }
            set { SetPropertyValue("Moneda", ref _fMoneda, value); }
        }

        [Indexed(Name = @"iEspeciePredeterminada_fondos_Cuenta_B372CC91")]
        [Association(@"fondos_CuentaReferencesfondos_Especie")]
        public Especie EspeciePredeterminada
        {
            get { return _fEspeciePredeterminada; }
            set { SetPropertyValue("EspeciePredeterminada", ref _fEspeciePredeterminada, value); }
        }

        public bool EmiteCheque
        {
            get { return _fEmiteCheque; }
            set { SetPropertyValue("EmiteCheque", ref _fEmiteCheque, value); }
        }

        public bool ControlaChequera
        {
            get { return _fControlaChequera; }
            set { SetPropertyValue("ControlaChequera", ref _fControlaChequera, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }

        public bool Disponibilidad
        {
            get { return _fDisponibilidad; }
            set { SetPropertyValue("Disponibilidad", ref _fDisponibilidad, value); }
        }

        public string Notas
        {
            get { return _fNotas; }
            set { SetPropertyValue("Notas", ref _fNotas, value); }
        }

        public bool ExigeApertura
        {
            get { return _fExigeApertura; }
            set { SetPropertyValue("ExigeApertura", ref _fExigeApertura, value); }
        }

        [Indexed(Name = @"iCuentaContable_fondos_Cuenta_06BE37F6")]
        public int CuentaContable
        {
            get { return _fCuentaContable; }
            set { SetPropertyValue<int>("CuentaContable", ref _fCuentaContable, value); }
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