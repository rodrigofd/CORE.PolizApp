using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.General.Modulos.AFIP
{
    [Persistent(@"afip.CodigoDestinacion")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"CodigosDestinacion")]
    [DefaultClassOptions]
public class AfipCodigoDestinacion : BasicObject
    {
        private int _fCodigo;
        private string _fCodigoDestinacion;
        private DateTime _fFechaDesde;
        private DateTime _fFechaHasta;

        public AfipCodigoDestinacion(Session session)
            : base(session)
        {
        }

        [Size(10)]
        public int Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue<int>("Codigo", ref _fCodigo, value); }
        }

        [Size(300)]
        public string Nombre
        {
            get { return _fCodigoDestinacion; }
            set { SetPropertyValue("Nombre", ref _fCodigoDestinacion, value); }
        }

        public DateTime FechaDesde
        {
            get { return _fFechaDesde; }
            set { SetPropertyValue<DateTime>("FechaDesde", ref _fFechaDesde, value); }
        }

        public DateTime FechaHasta
        {
            get { return _fFechaHasta; }
            set { SetPropertyValue<DateTime>("FechaHasta", ref _fFechaHasta, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}