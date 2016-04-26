using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo;

namespace CORE.General.Modulos.AFIP
{
    [Persistent(@"afip.CodigoDestinacion")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"CodigosDestinacion")]
    public class afip_CodigoDestinacion : BasicObject
    {
        private int fCodigo;
        private string fCodigoDestinacion;
        private DateTime fFechaDesde;
        private DateTime fFechaHasta;

        public afip_CodigoDestinacion(Session session)
            : base(session)
        {
        }

        [Size(10)]
        public int Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue<int>("Codigo", ref fCodigo, value); }
        }

        [Size(300)]
        public string Nombre
        {
            get { return fCodigoDestinacion; }
            set { SetPropertyValue("Nombre", ref fCodigoDestinacion, value); }
        }

        public DateTime FechaDesde
        {
            get { return fFechaDesde; }
            set { SetPropertyValue<DateTime>("FechaDesde", ref fFechaDesde, value); }
        }

        public DateTime FechaHasta
        {
            get { return fFechaHasta; }
            set { SetPropertyValue<DateTime>("FechaHasta", ref fFechaHasta, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}