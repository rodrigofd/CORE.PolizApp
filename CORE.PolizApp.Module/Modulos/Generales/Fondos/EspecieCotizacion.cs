using System;
using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.EspecieCotizacion")]
    [System.ComponentModel.DisplayName("Cotización de especie")]
    [DefaultClassOptions]
public class EspecieCotizacion : BasicObject
    {
        private decimal _fComprador;
        private Especie _fEspecieDestino;
        private Especie _fEspecieOrigen;
        private DateTime _fFecha;
        private decimal _fPromedio;
        private decimal _fVendedor;

        public EspecieCotizacion(Session session)
            : base(session)
        {
        }

        public DateTime Fecha
        {
            get { return _fFecha; }
            set { SetPropertyValue<DateTime>("Fecha", ref _fFecha, value); }
        }

        public Especie EspecieOrigen
        {
            get { return _fEspecieOrigen; }
            set { SetPropertyValue("EspecieOrigen", ref _fEspecieOrigen, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Comprador
        {
            get { return _fComprador; }
            set { SetPropertyValue<decimal>("Comprador", ref _fComprador, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Vendedor
        {
            get { return _fVendedor; }
            set { SetPropertyValue<decimal>("Vendedor", ref _fVendedor, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal Promedio
        {
            get { return _fPromedio; }
            set { SetPropertyValue<decimal>("Promedio", ref _fPromedio, value); }
        }

        public Especie EspecieDestino
        {
            get { return _fEspecieDestino; }
            set { SetPropertyValue("EspecieDestino", ref _fEspecieDestino, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}