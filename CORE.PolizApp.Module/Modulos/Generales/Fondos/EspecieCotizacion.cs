using System;
using CORE.General.Modulos.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo;

//using CORE.General.Modulos.Sistema;

namespace CORE.General.Modulos.Fondos
{
    [Persistent(@"fondos.EspecieCotizacion")]
    [System.ComponentModel.DisplayName("Cotización de especie")]
    public class fondos_EspecieCotizacion : BasicObject
    {
        private decimal fComprador;
        private fondos_Especie fEspecieDestino;
        private fondos_Especie fEspecieOrigen;
        private DateTime fFecha;
        private decimal fPromedio;
        private decimal fVendedor;

        public fondos_EspecieCotizacion(Session session)
            : base(session)
        {
        }

        public DateTime Fecha
        {
            get { return fFecha; }
            set { SetPropertyValue<DateTime>("Fecha", ref fFecha, value); }
        }

        public fondos_Especie EspecieOrigen
        {
            get { return fEspecieOrigen; }
            set { SetPropertyValue("EspecieOrigen", ref fEspecieOrigen, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Comprador
        {
            get { return fComprador; }
            set { SetPropertyValue<decimal>("Comprador", ref fComprador, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Vendedor
        {
            get { return fVendedor; }
            set { SetPropertyValue<decimal>("Vendedor", ref fVendedor, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Promedio
        {
            get { return fPromedio; }
            set { SetPropertyValue<decimal>("Promedio", ref fPromedio, value); }
        }

        public fondos_Especie EspecieDestino
        {
            get { return fEspecieDestino; }
            set { SetPropertyValue("EspecieDestino", ref fEspecieDestino, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}