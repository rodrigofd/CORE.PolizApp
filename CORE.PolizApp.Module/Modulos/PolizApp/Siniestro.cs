using System;
using CORE.PolizApp.Fondos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.Siniestro")]
    public class Siniestro : BasicObject
    {
        private DateTime _fCerrado;
        private bool _fCoaseguro;
        private string _fDamnificados;
        private decimal _fDaño;
        private decimal _fDeducible;
        private string _fDeducibleNota;
        private string _fDetalle;
        private Documento _fDocumento;
        private DocumentoItem _fDocumentoItem;
        private Especie _fEspecie;
        private string _fEstadoNota;
        private DateTime _fFechaAseguradora;
        private DateTime _fFechaDenuncia;
        private DateTime _fFechaSiniestro;
        private int _fFolio;
        private string _fFolioAseguradora;
        private decimal _fGraciable;
        private DateTime _fInspeccionFecha;
        private string _fInspeccionNota;
        private string _fJurisdiccion;
        private string _fNota;
        private decimal _fReclamado;
        private string _fRiesgoAfectado;
        private SiniestroEstado _fSiniestroEstado;
        private SiniestroLiquidador _fSiniestroLiquidador;
        private SiniestroTipo _fSiniestroTipo;
        private SiniestroTipoPerdida _fSiniestroTipoPerdida;
        private bool _fTerceros;
        private string _fUbicacion;

        public Siniestro(Session session) : base(session)
        {
        }

        [Association(@"SiniestroReferencesDocumento")]
        public Documento Documento
        {
            get { return _fDocumento; }
            set { SetPropertyValue("Documento", ref _fDocumento, value); }
        }

        [Association(@"SiniestroReferencesDocumentoItem")]
        public DocumentoItem DocumentoItem
        {
            get { return _fDocumentoItem; }
            set { SetPropertyValue("DocumentoItem", ref _fDocumentoItem, value); }
        }

        public bool Coaseguro
        {
            get { return _fCoaseguro; }
            set { SetPropertyValue("Coaseguro", ref _fCoaseguro, value); }
        }

        public int Folio
        {
            get { return _fFolio; }
            set { SetPropertyValue<int>("Folio", ref _fFolio, value); }
        }

        public DateTime FechaSiniestro
        {
            get { return _fFechaSiniestro; }
            set { SetPropertyValue<DateTime>("FechaSiniestro", ref _fFechaSiniestro, value); }
        }

        public DateTime FechaDenuncia
        {
            get { return _fFechaDenuncia; }
            set { SetPropertyValue<DateTime>("FechaDenuncia", ref _fFechaDenuncia, value); }
        }

        public DateTime FechaAseguradora
        {
            get { return _fFechaAseguradora; }
            set { SetPropertyValue<DateTime>("FechaAseguradora", ref _fFechaAseguradora, value); }
        }

        [Size(20)]
        public string FolioAseguradora
        {
            get { return _fFolioAseguradora; }
            set { SetPropertyValue("FolioAseguradora", ref _fFolioAseguradora, value); }
        }

        [Association(@"SiniestroReferencesSiniestroLiquidador")]
        public SiniestroLiquidador SiniestroLiquidador
        {
            get { return _fSiniestroLiquidador; }
            set { SetPropertyValue("SiniestroLiquidador", ref _fSiniestroLiquidador, value); }
        }

        [Association(@"SiniestroReferencesSiniestroTipo")]
        public SiniestroTipo SiniestroTipo
        {
            get { return _fSiniestroTipo; }
            set { SetPropertyValue("SiniestroTipo", ref _fSiniestroTipo, value); }
        }

        [Association(@"SiniestroReferencesSiniestroTipoPerdida")]
        public SiniestroTipoPerdida SiniestroTipoPerdida
        {
            get { return _fSiniestroTipoPerdida; }
            set { SetPropertyValue("SiniestroTipoPerdida", ref _fSiniestroTipoPerdida, value); }
        }

        [Association(@"SiniestroReferencesSiniestroEstado")]
        public SiniestroEstado SiniestroEstado
        {
            get { return _fSiniestroEstado; }
            set { SetPropertyValue("SiniestroEstado", ref _fSiniestroEstado, value); }
        }

        public DateTime Cerrado
        {
            get { return _fCerrado; }
            set { SetPropertyValue<DateTime>("Cerrado", ref _fCerrado, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string EstadoNota
        {
            get { return _fEstadoNota; }
            set { SetPropertyValue("EstadoNota", ref _fEstadoNota, value); }
        }

        public bool Terceros
        {
            get { return _fTerceros; }
            set { SetPropertyValue("Terceros", ref _fTerceros, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Damnificados
        {
            get { return _fDamnificados; }
            set { SetPropertyValue("Damnificados", ref _fDamnificados, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string RiesgoAfectado
        {
            get { return _fRiesgoAfectado; }
            set { SetPropertyValue("RiesgoAfectado", ref _fRiesgoAfectado, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Ubicacion
        {
            get { return _fUbicacion; }
            set { SetPropertyValue("Ubicacion", ref _fUbicacion, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Jurisdiccion
        {
            get { return _fJurisdiccion; }
            set { SetPropertyValue("Jurisdiccion", ref _fJurisdiccion, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Detalle
        {
            get { return _fDetalle; }
            set { SetPropertyValue("Detalle", ref _fDetalle, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Nota
        {
            get { return _fNota; }
            set { SetPropertyValue("Nota", ref _fNota, value); }
        }

        public DateTime InspeccionFecha
        {
            get { return _fInspeccionFecha; }
            set { SetPropertyValue<DateTime>("InspeccionFecha", ref _fInspeccionFecha, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string InspeccionNota
        {
            get { return _fInspeccionNota; }
            set { SetPropertyValue("InspeccionNota", ref _fInspeccionNota, value); }
        }

        public Especie Especie
        {
            get { return _fEspecie; }
            set { SetPropertyValue("Especie", ref _fEspecie, value); }
        }

        public decimal Reclamado
        {
            get { return _fReclamado; }
            set { SetPropertyValue<decimal>("Reclamado", ref _fReclamado, value); }
        }

        public decimal Daño
        {
            get { return _fDaño; }
            set { SetPropertyValue<decimal>("Daño", ref _fDaño, value); }
        }

        public decimal Deducible
        {
            get { return _fDeducible; }
            set { SetPropertyValue<decimal>("Deducible", ref _fDeducible, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string DeducibleNota
        {
            get { return _fDeducibleNota; }
            set { SetPropertyValue("DeducibleNota", ref _fDeducibleNota, value); }
        }

        public decimal Graciable
        {
            get { return _fGraciable; }
            set { SetPropertyValue<decimal>("Graciable", ref _fGraciable, value); }
        }

        [Association(@"SiniestroLiquidacionReferencesSiniestro")]
        public XPCollection<SiniestroLiquidacion> Liquidaciones => GetCollection<SiniestroLiquidacion>("Liquidaciones");
    }
}