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
    //[DefaultClassOptions]
    [DefaultProperty("Descripcion")]
    [Persistent(@"sistema.Empresa")]
    [System.ComponentModel.DisplayName(@"Empresa")]
    public class Empresa : BasicObject
    {
        private PersonaImpuesto fAfipCondicionIVA;
        private Identificacion fAfipCUIT;
        private Direccion fAfipDomicilio;
        private Identificacion fAfipIIBB;
        private DateTime fAfipInicioActividad;
        private string fColorFondo;
        private PaisIdioma fCulturaPredeterminada;
        private Idioma fIdiomaPredeterminado;
        private DateTime fLicenciaDesde;
        private DateTime fLicenciaHasta;
        private int fMaxAccesosErroneos;
        private Persona fPersona;
        private string fPieInformesGral;
        private TipoLicencia fTipoLicencia;

        public Empresa(Session session)
            : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [PersistentAlias("Persona.NombreCompleto")]
        public string Descripcion => Convert.ToString(EvaluateAlias("Descripcion"));

        [Association(@"EmpresaReferencespersonas_Persona")]
        public Persona Persona
        {
            get { return fPersona; }
            set { SetPropertyValue("Persona", ref fPersona, value); }
        }

        public TipoLicencia TipoLicencia
        {
            get { return fTipoLicencia; }
            set { SetPropertyValue("TipoLicencia", ref fTipoLicencia, value); }
        }

        public DateTime LicenciaDesde
        {
            get { return fLicenciaDesde; }
            set { SetPropertyValue<DateTime>("Inicio", ref fLicenciaDesde, value); }
        }

        public DateTime LicenciaHasta
        {
            get { return fLicenciaHasta; }
            set { SetPropertyValue<DateTime>("Fin", ref fLicenciaHasta, value); }
        }

        public int MaxAccesosErroneos
        {
            get { return fMaxAccesosErroneos; }
            set { SetPropertyValue<int>("MaxAccesosErroneos", ref fMaxAccesosErroneos, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string PieInformesGral
        {
            get { return fPieInformesGral; }
            set { SetPropertyValue("PieInformesGral", ref fPieInformesGral, value); }
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
            get { return fIdiomaPredeterminado; }
            set { SetPropertyValue("IdiomaPredeterminado", ref fIdiomaPredeterminado, value); }
        }

        public PaisIdioma CulturaPredeterminada
        {
            get { return fCulturaPredeterminada; }
            set { SetPropertyValue("CulturaPredeterminada", ref fCulturaPredeterminada, value); }
        }

        public string ColorFondo
        {
            get { return fColorFondo; }
            set { SetPropertyValue("ColorFondo", ref fColorFondo, value); }
        }

        [DataSourceProperty("Persona.Identificaciones")]
        [DataSourceCriteria("[Tipo.Clase.Oid] = 1 Or [Tipo.Clase.Oid] = 6")] // Clase DOC o FISCAL
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public Identificacion AfipCUIT
        {
            get { return fAfipCUIT; }
            set { SetPropertyValue("AfipCUIT", ref fAfipCUIT, value); }
        }

        [DataSourceProperty("Persona.DatosImpositivos")]
        public PersonaImpuesto AfipCondicionIVA
        {
            get { return fAfipCondicionIVA; }
            set { SetPropertyValue("AfipCondicionIVA", ref fAfipCondicionIVA, value); }
        }

        [DataSourceProperty("Persona.Direcciones")]
        public Direccion AfipDomicilio
        {
            get { return fAfipDomicilio; }
            set { SetPropertyValue("AfipDomicilio", ref fAfipDomicilio, value); }
        }

        public DateTime AfipInicioActividad
        {
            get { return fAfipInicioActividad; }
            set { SetPropertyValue<DateTime>("AfipInicioActividad", ref fAfipInicioActividad, value); }
        }

        [DataSourceProperty("Persona.Identificaciones")]
        public Identificacion AfipIIBB
        {
            get { return fAfipIIBB; }
            set { SetPropertyValue("AfipIIBB", ref fAfipIIBB, value); }
        }
        
        [Association(@"seguridad.UsuarioEmpresa", typeof(Usuario), UseAssociationNameAsIntermediateTableName = true)]
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