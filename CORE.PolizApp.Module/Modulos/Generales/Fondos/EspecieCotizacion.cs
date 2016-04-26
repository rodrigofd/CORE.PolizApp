using System;
using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.EspecieCotizacion")]
    [System.ComponentModel.DisplayName("Cotización de especie")]
    public class EspecieCotizacion : BasicObject
    {
        private decimal fComprador;
        private Especie fEspecieDestino;
        private Especie fEspecieOrigen;
        private DateTime fFecha;
        private decimal fPromedio;
        private decimal fVendedor;

        public EspecieCotizacion(Session session)
            : base(session)
        {
        }

        public DateTime Fecha
        {
            get { return fFecha; }
            set { SetPropertyValue<DateTime>("Fecha", ref fFecha, value); }
        }

        public Especie EspecieOrigen
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

        public Especie EspecieDestino
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