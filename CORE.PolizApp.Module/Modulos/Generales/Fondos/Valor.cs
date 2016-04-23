using System;
using System.Collections.Generic;
using System.ComponentModel;
using CORE.ES.Module.Modulos.Escribania;
using CORE.General.Modulos.Sistema;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Fondos
{
    [Persistent(@"fondos.Valor")]
    [DefaultProperty("ValorID")]
    [System.ComponentModel.DisplayName(@"Valores")]
    public class fondos_Valor : BasicObject
    {
        private DateTime fAnulado;
        private string fAnuladoMotivo;
        private int fBoletaDeposito;
        private int fBoletaDepositoNumero;
        private decimal fCambio;
        private fondos_Banco fChBanco;
        private bool fChDevuelto;
        private DateTime fChFecha;
        private DateTime fChFechaDep;
        private long fChNumero;
        private bool fChRechazado;
        private string fChSerie;
        private string fChSucursal;
        private string fConcepto;
        private fondos_Valor fContrapartida;
        private fondos_Cuenta fCuenta;
        private fondos_Especie fEspecie;
        private DateTime fFechaAcreditado;
        private DateTime fFechaAlta;
        private decimal fImporte;

        public fondos_Valor(Session session) : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [System.ComponentModel.DisplayName(@"Valor")]
        //[PersistentAlias("concat(EscribanoRegistro.EscribanoRegistroID, '-', ToStr(Numero), '-', ToStr(escribania_Protocolo.MIN(Folio)), ' (', Trim(SubString(ToStr(Fecha), 0, 10)), ') ')")]
        [PersistentAlias("Cuenta.Nombre")]
        public string ValorID
        {
            get { return Convert.ToString(EvaluateAlias("ValorID")); }
        }

        [Association(@"fondos_ValorReferencesfondos_Cuenta")]
        public fondos_Cuenta Cuenta
        {
            get { return fCuenta; }
            set { SetPropertyValue("Cuenta", ref fCuenta, value); }
        }

        public DateTime FechaAlta
        {
            get { return fFechaAlta; }
            set { SetPropertyValue<DateTime>("FechaAlta", ref fFechaAlta, value); }
        }

        public DateTime FechaAcreditado
        {
            get { return fFechaAcreditado; }
            set { SetPropertyValue<DateTime>("FechaAcreditado", ref fFechaAcreditado, value); }
        }

        [Indexed(Name = @"iEspecie_fondos_Valor_DD7B7E6B")]
        [Association(@"fondos_ValorReferencesfondos_Especie")]
        //  [ImmediatePostData]
        public fondos_Especie Especie
        {
            get { return fEspecie; }
            set { SetPropertyValue("Especie", ref fEspecie, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Importe
        {
            get { return fImporte; }
            set { SetPropertyValue<decimal>("Importe", ref fImporte, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n4}"), ModelDefault("EditMask", "n4")]
        // [Appearance("fCambio", "Especie.Instrumento.Clase == 'Cheque'", BackColor = "Red")]
        public decimal Cambio
        {
            get { return fCambio; }
            set { SetPropertyValue<decimal>("Cambio", ref fCambio, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Concepto
        {
            get { return fConcepto; }
            set { SetPropertyValue("Concepto", ref fConcepto, value); }
        }

        [Association(@"fondos_ValorReferencesfondos_Banco")]
        // [Appearance("fChBanco", "Especie.Instrumento.Clase == 'Cheque'", Visibility = ViewItemVisibility.Hide)]
        public fondos_Banco ChBanco
        {
            get { return fChBanco; }
            set { SetPropertyValue("ChBanco", ref fChBanco, value); }
        }

        [Size(20)]
        public string ChSucursal
        {
            get { return fChSucursal; }
            set { SetPropertyValue("ChSucursal", ref fChSucursal, value); }
        }

        [Size(3)]
        public string ChSerie
        {
            get { return fChSerie; }
            set { SetPropertyValue("ChSerie", ref fChSerie, value); }
        }

        public long ChNumero
        {
            get { return fChNumero; }
            set { SetPropertyValue("ChNumero", ref fChNumero, value); }
        }

        public DateTime ChFecha
        {
            get { return fChFecha; }
            set { SetPropertyValue<DateTime>("ChFecha", ref fChFecha, value); }
        }

        public DateTime ChFechaDep
        {
            get { return fChFechaDep; }
            set { SetPropertyValue<DateTime>("ChFechaDep", ref fChFechaDep, value); }
        }

        public bool ChRechazado
        {
            get { return fChRechazado; }
            set { SetPropertyValue("ChRechazado", ref fChRechazado, value); }
        }

        public bool ChDevuelto
        {
            get { return fChDevuelto; }
            set { SetPropertyValue("ChDevuelto", ref fChDevuelto, value); }
        }

        public int BoletaDeposito
        {
            get { return fBoletaDeposito; }
            set { SetPropertyValue<int>("BoletaDeposito", ref fBoletaDeposito, value); }
        }

        public int BoletaDepositoNumero
        {
            get { return fBoletaDepositoNumero; }
            set { SetPropertyValue<int>("BoletaDepositoNumero", ref fBoletaDepositoNumero, value); }
        }

        public DateTime Anulado
        {
            get { return fAnulado; }
            set { SetPropertyValue<DateTime>("Anulado", ref fAnulado, value); }
        }

        [Size(200)]
        public string AnuladoMotivo
        {
            get { return fAnuladoMotivo; }
            set { SetPropertyValue("AnuladoMotivo", ref fAnuladoMotivo, value); }
        }

        [Association(@"fondos_ValorReferencesfondos_Valor")]
        public fondos_Valor Contrapartida
        {
            get { return fContrapartida; }
            set { SetPropertyValue("Contrapartida", ref fContrapartida, value); }
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
        [Association(@"fondos_ValorReferencesfondos_Valor", typeof (fondos_Valor))]
        public XPCollection<fondos_Valor> fondos_ValorCollection
        {
            get { return GetCollection<fondos_Valor>("fondos_ValorCollection"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            //Empresa = Session.FindObject<Empresa>(new BinaryOperator("Persona.Oid", 1));
            Especie = Session.FindObject<fondos_Especie>(new BinaryOperator("Oid", 1));
            //Especie = fondos_Especie;
            Cambio = 1;
            FechaAlta = DateTime.Today;
        }
    }
}