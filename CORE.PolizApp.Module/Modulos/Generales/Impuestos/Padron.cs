using System;
using System.ComponentModel;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Impuestos
{
    [Persistent(@"impuestos.Padron")]
    //[DefaultClassOptions]
    [DefaultProperty("IdentificacionNro")]
    [System.ComponentModel.DisplayName(@"Padrón por impuesto")]
    [DefaultClassOptions]
public class Padron : XPLiteObject
    {
        private Impuesto _fImpuesto;
        private decimal _fAlicuotaPercepcion;
        private decimal _fAlicuotaRetencion;
        private DateTime _fFechaPublicacion;
        private DateTime _fFechaVigDesde;
        private DateTime _fFechaVigHasta;
        private int _fGrupoPercepcion;
        private int _fGrupoRetencion;
        private long _fIdentificacionNro;
        private char _fMarcaCbioAlicuota;
        private char _fMarcaSujeto;
        private long _fOid;
        private string _fTipoContribuyente;

        public Padron(Session session)
            : base(session)
        {
        }

        [Key(true)]
        public long Oid
        {
            get { return _fOid; }
            set { SetPropertyValue("Oid", ref _fOid, value); }
        }

        [Association(@"PadronReferencesImpuestos")]
        public Impuesto Impuesto
        {
            get { return _fImpuesto; }
            set { SetPropertyValue("Impuesto", ref _fImpuesto, value); }
        }

        public long IdentificacionNro
        {
            get { return _fIdentificacionNro; }
            set { SetPropertyValue("IdentificacionNro", ref _fIdentificacionNro, value); }
        }

        public DateTime FechaPublicacion
        {
            get { return _fFechaPublicacion; }
            set { SetPropertyValue<DateTime>("FechaPublicacion", ref _fFechaPublicacion, value); }
        }

        public DateTime FechaVigDesde
        {
            get { return _fFechaVigDesde; }
            set { SetPropertyValue<DateTime>("FechaVigDesde", ref _fFechaVigDesde, value); }
        }

        public DateTime FechaVigHasta
        {
            get { return _fFechaVigHasta; }
            set { SetPropertyValue<DateTime>("FechaVigHasta", ref _fFechaVigHasta, value); }
        }

        [Size(1)]
        public string TipoContribuyente
        {
            get { return _fTipoContribuyente; }
            set { SetPropertyValue("TipoContribuyente", ref _fTipoContribuyente, value); }
        }

        public char MarcaSujeto
        {
            get { return _fMarcaSujeto; }
            set { SetPropertyValue("MarcaSujeto", ref _fMarcaSujeto, value); }
        }

        public char MarcaCbioAlicuota
        {
            get { return _fMarcaCbioAlicuota; }
            set { SetPropertyValue("MarcaCbioAlicuota", ref _fMarcaCbioAlicuota, value); }
        }

        public decimal AlicuotaPercepcion
        {
            get { return _fAlicuotaPercepcion; }
            set { SetPropertyValue<decimal>("AlicuotaPercepcion", ref _fAlicuotaPercepcion, value); }
        }

        public decimal AlicuotaRetencion
        {
            get { return _fAlicuotaRetencion; }
            set { SetPropertyValue<decimal>("AlicuotaRetencion", ref _fAlicuotaRetencion, value); }
        }

        public int GrupoPercepcion
        {
            get { return _fGrupoPercepcion; }
            set { SetPropertyValue<int>("GrupoPercepcion", ref _fGrupoPercepcion, value); }
        }

        public int GrupoRetencion
        {
            get { return _fGrupoRetencion; }
            set { SetPropertyValue<int>("GrupoRetencion", ref _fGrupoRetencion, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}