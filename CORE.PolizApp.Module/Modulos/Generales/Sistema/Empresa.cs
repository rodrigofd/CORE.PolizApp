using System;
using System.ComponentModel;
using System.Drawing;
using CORE.PolizApp.Personas;
using CORE.PolizApp.Regionales;
using CORE.PolizApp.Seguridad;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace CORE.PolizApp.Sistema
{
    [DefaultProperty("Descripcion")]
    [Persistent(@"sistema.Empresa")]
    [System.ComponentModel.DisplayName(@"Empresa")]
    public class Empresa : BasicObject
    {
        private PersonaImpuesto _fAfipCondicionIVA;
        private Identificacion _fAfipCuit;
        private Direccion _fAfipDomicilio;
        private Identificacion _fAfipIibb;
        private DateTime _fAfipInicioActividad;
        private string _fColorFondo;
        private PaisIdioma _fCulturaPredeterminada;
        private Idioma _fIdiomaPredeterminado;
        private DateTime _fLicenciaDesde;
        private DateTime _fLicenciaHasta;
        private int _fMaxAccesosErroneos;
        private Persona _fPersona;
        private string _fPieInformesGral;
        private TipoLicencia _fTipoLicencia;

        public Empresa(Session session)
            : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [PersistentAlias("Persona.NombreCompleto")]
        public string Descripcion => Convert.ToString(EvaluateAlias("Descripcion"));
        
        public Persona Persona
        {
            get { return _fPersona; }
            set { SetPropertyValue("Persona", ref _fPersona, value); }
        }

        public TipoLicencia TipoLicencia
        {
            get { return _fTipoLicencia; }
            set { SetPropertyValue("TipoLicencia", ref _fTipoLicencia, value); }
        }

        public DateTime LicenciaDesde
        {
            get { return _fLicenciaDesde; }
            set { SetPropertyValue<DateTime>("Inicio", ref _fLicenciaDesde, value); }
        }

        public DateTime LicenciaHasta
        {
            get { return _fLicenciaHasta; }
            set { SetPropertyValue<DateTime>("Fin", ref _fLicenciaHasta, value); }
        }

        public int MaxAccesosErroneos
        {
            get { return _fMaxAccesosErroneos; }
            set { SetPropertyValue<int>("MaxAccesosErroneos", ref _fMaxAccesosErroneos, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string PieInformesGral
        {
            get { return _fPieInformesGral; }
            set { SetPropertyValue("PieInformesGral", ref _fPieInformesGral, value); }
        }

        [Delayed(true)]
        [ValueConverter(typeof (ImageValueConverter))]
        [System.ComponentModel.DisplayName(@"Imagen Logo")]
        public Image ImagenLogo
        {
            get { return GetDelayedPropertyValue<Image>("ImagenLogo"); }
            set { SetDelayedPropertyValue("ImagenLogo", value); }
        }

        public Idioma IdiomaPredeterminado
        {
            get { return _fIdiomaPredeterminado; }
            set { SetPropertyValue("IdiomaPredeterminado", ref _fIdiomaPredeterminado, value); }
        }

        public PaisIdioma CulturaPredeterminada
        {
            get { return _fCulturaPredeterminada; }
            set { SetPropertyValue("CulturaPredeterminada", ref _fCulturaPredeterminada, value); }
        }

        public string ColorFondo
        {
            get { return _fColorFondo; }
            set { SetPropertyValue("ColorFondo", ref _fColorFondo, value); }
        }

        [DataSourceProperty("Persona.Identificaciones")]
        [DataSourceCriteria("[Tipo.Clase.Oid] = 1 Or [Tipo.Clase.Oid] = 6")] // Clase DOC o FISCAL
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public Identificacion AfipCuit
        {
            get { return _fAfipCuit; }
            set { SetPropertyValue("AfipCUIT", ref _fAfipCuit, value); }
        }

        [DataSourceProperty("Persona.DatosImpositivos")]
        public PersonaImpuesto AfipCondicionIVA
        {
            get { return _fAfipCondicionIVA; }
            set { SetPropertyValue("AfipCondicionIVA", ref _fAfipCondicionIVA, value); }
        }

        [DataSourceProperty("Persona.Direcciones")]
        public Direccion AfipDomicilio
        {
            get { return _fAfipDomicilio; }
            set { SetPropertyValue("AfipDomicilio", ref _fAfipDomicilio, value); }
        }

        public DateTime AfipInicioActividad
        {
            get { return _fAfipInicioActividad; }
            set { SetPropertyValue<DateTime>("AfipInicioActividad", ref _fAfipInicioActividad, value); }
        }

        [DataSourceProperty("Persona.Identificaciones")]
        public Identificacion AfipIibb
        {
            get { return _fAfipIibb; }
            set { SetPropertyValue("AfipIIBB", ref _fAfipIibb, value); }
        }

        [Association(@"seguridad.UsuarioEmpresa", typeof (Usuario), UseAssociationNameAsIntermediateTableName = true)]
        public XPCollection<Usuario> Usuarios => GetCollection<Usuario>("Usuarios");

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            TipoLicencia = TipoLicencia.Trial;
        }

        protected override void OnSaved()
        {
            base.OnSaved();
        }
    }
}