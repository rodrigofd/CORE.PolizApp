using System;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.VehiculoPrecio")]
    public class VehiculoPrecio : BasicObject
    {
        private int _fAño;
        private string _fDescripcion;
        private bool _fEs0Km;
        private decimal _fPrecio;
        private VehiculoModelo _fVehiculoModelo;
        private DateTime _fVigencia;

        public VehiculoPrecio(Session session) : base(session)
        {
        }

        [Association(@"VehiculoPrecioReferencesVehiculoModelo")]
        public VehiculoModelo VehiculoModelo
        {
            get { return _fVehiculoModelo; }
            set { SetPropertyValue("VehiculoModelo", ref _fVehiculoModelo, value); }
        }

        public int Año
        {
            get { return _fAño; }
            set { SetPropertyValue<int>("Año", ref _fAño, value); }
        }

        [Persistent(@"0Km")]
        public bool Es0Km
        {
            get { return _fEs0Km; }
            set { SetPropertyValue("P_0Km", ref _fEs0Km, value); }
        }

        public decimal Precio
        {
            get { return _fPrecio; }
            set { SetPropertyValue<decimal>("Precio", ref _fPrecio, value); }
        }

        [Size(8)]
        public string Descripcion
        {
            get { return _fDescripcion; }
            set { SetPropertyValue("Descripcion", ref _fDescripcion, value); }
        }

        public DateTime Vigencia
        {
            get { return _fVigencia; }
            set { SetPropertyValue<DateTime>("Vigencia", ref _fVigencia, value); }
        }
    }
}