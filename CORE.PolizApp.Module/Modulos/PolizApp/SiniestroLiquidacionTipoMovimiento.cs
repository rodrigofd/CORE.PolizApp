﻿using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.SiniestroLiquidacionTipoMovimiento")]
    public class SiniestroLiquidacionTipoMovimiento : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;
        private int _fOrden;

        public SiniestroLiquidacionTipoMovimiento(Session session) : base(session)
        {
        }

        [Size(10)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(50)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }

        [Association(@"SiniestroLiquidacionReferencesSiniestroLiquidacionTipoMovimiento")]
        public XPCollection<SiniestroLiquidacion> Liquidaciones => GetCollection<SiniestroLiquidacion>("Liquidaciones");
    }
}