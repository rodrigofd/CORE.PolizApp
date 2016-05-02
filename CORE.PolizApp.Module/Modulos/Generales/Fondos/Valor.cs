using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.Valor")]
    [System.ComponentModel.DisplayName(@"Valores")]
    [DefaultClassOptions]
public class Valor : BasicObject
    {
        private DateTime _fAnulado;
        private string _fAnuladoMotivo;
        private int _fBoletaDeposito;
        private int _fBoletaDepositoNumero;
        private decimal _fCambio;
        private Banco _fChBanco;
        private bool _fChDevuelto;
        private DateTime _fChFecha;
        private DateTime _fChFechaDep;
        private long _fChNumero;
        private bool _fChRechazado;
        private string _fChSerie;
        private string _fChSucursal;
        private string _fConcepto;
        private Valor _fContrapartida;
        private Cuenta _fCuenta;
        private Especie _fEspecie;
        private DateTime _fFechaAcreditado;
        private DateTime _fFechaAlta;
        private decimal _fImporte;

        public Valor(Session session) : base(session)
        {
        }
        
        [Association(@"fondos_ValorReferencesfondos_Cuenta")]
        public Cuenta Cuenta
        {
            get { return _fCuenta; }
            set { SetPropertyValue("Cuenta", ref _fCuenta, value); }
        }

        public DateTime FechaAlta
        {
            get { return _fFechaAlta; }
            set { SetPropertyValue<DateTime>("FechaAlta", ref _fFechaAlta, value); }
        }

        public DateTime FechaAcreditado
        {
            get { return _fFechaAcreditado; }
            set { SetPropertyValue<DateTime>("FechaAcreditado", ref _fFechaAcreditado, value); }
        }

        [Indexed(Name = @"iEspecie_fondos_Valor_DD7B7E6B")]
        [Association(@"fondos_ValorReferencesfondos_Especie")]
        //[ImmediatePostData]
        public Especie Especie
        {
            get { return _fEspecie; }
            set { SetPropertyValue("Especie", ref _fEspecie, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Importe
        {
            get { return _fImporte; }
            set { SetPropertyValue<decimal>("Importe", ref _fImporte, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n4}"), ModelDefault("EditMask", "n4")]
        //[Appearance("fCambio", "Especie.Instrumento.Clase == 'Cheque'", BackColor = "Red")]
        public decimal Cambio
        {
            get { return _fCambio; }
            set { SetPropertyValue<decimal>("Cambio", ref _fCambio, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Concepto
        {
            get { return _fConcepto; }
            set { SetPropertyValue("Concepto", ref _fConcepto, value); }
        }

        [Association(@"fondos_ValorReferencesfondos_Banco")]
        // [Appearance("fChBanco", "Especie.Instrumento.Clase == 'Cheque'", Visibility = ViewItemVisibility.Hide)]
        public Banco ChBanco
        {
            get { return _fChBanco; }
            set { SetPropertyValue("ChBanco", ref _fChBanco, value); }
        }

        [Size(20)]
        public string ChSucursal
        {
            get { return _fChSucursal; }
            set { SetPropertyValue("ChSucursal", ref _fChSucursal, value); }
        }

        [Size(3)]
        public string ChSerie
        {
            get { return _fChSerie; }
            set { SetPropertyValue("ChSerie", ref _fChSerie, value); }
        }

        public long ChNumero
        {
            get { return _fChNumero; }
            set { SetPropertyValue("ChNumero", ref _fChNumero, value); }
        }

        public DateTime ChFecha
        {
            get { return _fChFecha; }
            set { SetPropertyValue<DateTime>("ChFecha", ref _fChFecha, value); }
        }

        public DateTime ChFechaDep
        {
            get { return _fChFechaDep; }
            set { SetPropertyValue<DateTime>("ChFechaDep", ref _fChFechaDep, value); }
        }

        public bool ChRechazado
        {
            get { return _fChRechazado; }
            set { SetPropertyValue("ChRechazado", ref _fChRechazado, value); }
        }

        public bool ChDevuelto
        {
            get { return _fChDevuelto; }
            set { SetPropertyValue("ChDevuelto", ref _fChDevuelto, value); }
        }

        public int BoletaDeposito
        {
            get { return _fBoletaDeposito; }
            set { SetPropertyValue<int>("BoletaDeposito", ref _fBoletaDeposito, value); }
        }

        public int BoletaDepositoNumero
        {
            get { return _fBoletaDepositoNumero; }
            set { SetPropertyValue<int>("BoletaDepositoNumero", ref _fBoletaDepositoNumero, value); }
        }

        public DateTime Anulado
        {
            get { return _fAnulado; }
            set { SetPropertyValue<DateTime>("Anulado", ref _fAnulado, value); }
        }

        [Size(200)]
        public string AnuladoMotivo
        {
            get { return _fAnuladoMotivo; }
            set { SetPropertyValue("AnuladoMotivo", ref _fAnuladoMotivo, value); }
        }

        [Association(@"fondos_ValorReferencesfondos_Valor")]
        public Valor Contrapartida
        {
            get { return _fContrapartida; }
            set { SetPropertyValue("Contrapartida", ref _fContrapartida, value); }
        }

        /*
        int fUltimoMovimiento;
        [Indexed(Name = @"iUltimoMovimiento_fondos_Valor_ABB5311A")]
        public int UltimoMovimiento
        {
            get { return fUltimoMovimiento; }
            set { SetPropertyValue<int>("UltimoMovimiento", ref fUltimoMovimiento, value); }
        }
        int fEmpresa;
        [Indexed(Name = @"iEmpresa_fondos_Valor_7D6C7204")]
        public int Empresa
        {
            get { return fEmpresa; }
            set { SetPropertyValue<int>("Empresa", ref fEmpresa, value); }
        }
        int fid_mov;
        public int id_mov
        {
            get { return fid_mov; }
            set { SetPropertyValue<int>("id_mov", ref fid_mov, value); }
        }
        */

        [Aggregated, Browsable(false)]
        [Association(@"fondos_ValorReferencesfondos_Valor", typeof (Valor))]
        public XPCollection<Valor> FondosValorCollection
        {
            get { return GetCollection<Valor>("fondos_ValorCollection"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            //Empresa = Session.FindObject<Empresa>(new BinaryOperator("Persona.Oid", 1));
            Especie = Session.FindObject<Especie>(new BinaryOperator("Oid", 1));
            //Especie = Especie;
            Cambio = 1;
            FechaAlta = DateTime.Today;
        }
    }
}