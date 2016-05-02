using System;
using CORE.PolizApp.Fondos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.SiniestroLiquidacion")]
    public class SiniestroLiquidacion : BasicObject
    {
        private Especie _fEspecie;
        private DateTime _fFecha;
        private int _fItem;
        private decimal _fLiquidado;
        private string _fNota;
        private Siniestro _fSiniestro;
        private SiniestroLiquidacionTipoMovimiento _tipoMovimiento;

        public SiniestroLiquidacion(Session session) : base(session)
        {
        }

        [Association(@"SiniestroLiquidacionReferencesSiniestro")]
        public Siniestro Siniestro
        {
            get { return _fSiniestro; }
            set { SetPropertyValue("Siniestro", ref _fSiniestro, value); }
        }

        public int Item
        {
            get { return _fItem; }
            set { SetPropertyValue<int>("Item", ref _fItem, value); }
        }

        public DateTime Fecha
        {
            get { return _fFecha; }
            set { SetPropertyValue<DateTime>("Fecha", ref _fFecha, value); }
        }

        [Association(@"SiniestroLiquidacionReferencesSiniestroLiquidacionTipoMovimiento")]
        [Persistent(@"SiniestroLiquidacionTipoMovimiento")]
        public SiniestroLiquidacionTipoMovimiento TipoMovimiento
        {
            get { return _tipoMovimiento; }
            set
            {
                SetPropertyValue("TipoMovimiento", ref _tipoMovimiento, value);
            }
        }

        public Especie Especie
        {
            get { return _fEspecie; }
            set { SetPropertyValue("Especie", ref _fEspecie, value); }
        }

        public decimal Liquidado
        {
            get { return _fLiquidado; }
            set { SetPropertyValue<decimal>("Liquidado", ref _fLiquidado, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Nota
        {
            get { return _fNota; }
            set { SetPropertyValue("Nota", ref _fNota, value); }
        }
    }
}