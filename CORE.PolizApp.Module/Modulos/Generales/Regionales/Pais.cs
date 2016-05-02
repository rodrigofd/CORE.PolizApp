using System.ComponentModel;
using System.Drawing;
using CORE.PolizApp.Impuestos;
using CORE.PolizApp.Personas;
using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using DevExpress.Xpo.Metadata;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Pais")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"País")]
    [DefaultClassOptions]
public class Pais : BasicObject
    {
        private string _fCapital;
        private string _fCodigo;
        private string _fCodigo3;
        private string _fCodigoFips;
        private string _fCodigoNum;
        private string _fCodigoPstn;
        private string _fCodigoTld;
        private Continente _fContinente;
        private string _fFormatoCodigoPostal;
        private string _fGeoCodeAddr;
        private string _fGeoLatitud;
        private string _fGeoLongitud;
        private string _fGeoNameid;
        private PaisIdioma _fIdiomaNativo;
        private Image _fImagenBandera;
        private Image _fImagenBanderaChica;
        private string _fPais;
        private string _fPaisEng;
        private string _fPaisesLimitrofes;
        private string _fPatronCodigoPostal;
        private int _fPoblacion;
        private decimal _fSuperficie;
        private string _fUrlBuscadorCodigoPostal;

        public Pais(Session session) : base(session)
        {
        }

        [ModelDefault("ImageSizeMode", "Normal")]
        [Index(0)]
        [VisibleInLookupListView(true)]
        [ValueConverter(typeof (ImageValueConverter))]
        public Image ImagenBanderaChica
        {
            get { return _fImagenBanderaChica; }
            set { SetPropertyValue("ImagenBanderaChica", ref _fImagenBanderaChica, value); }
        }

        [VisibleInListView(false)]
        [Index(1)]
        [Delayed(true)]
        [ValueConverter(typeof (ImageValueConverter))]
        [Size(SizeAttribute.Unlimited)]
        public Image ImagenBandera
        {
            get { return _fImagenBandera; }
            set { SetPropertyValue("ImagenBandera", ref _fImagenBandera, value); }
        }

        [Index(2)]
        [Size(2)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Index(3)]
        [System.ComponentModel.DisplayName(@"País")]
        public string Nombre
        {
            get { return _fPais; }
            set { SetPropertyValue("Nombre", ref _fPais, value); }
        }

        [Association(@"PaisesReferencesContinentes")]
        [Index(4)]
        public Continente Continente
        {
            get { return _fContinente; }
            set { SetPropertyValue("Continente", ref _fContinente, value); }
        }

        [Index(5)]
        public string Capital
        {
            get { return _fCapital; }
            set { SetPropertyValue("Capital", ref _fCapital, value); }
        }

        [Index(6)]
        public PaisIdioma IdiomaNativo
        {
            get { return _fIdiomaNativo; }
            set { SetPropertyValue("IdiomaNativo", ref _fIdiomaNativo, value); }
        }

        [Index(7)]
        [Size(15)]
        public string CodigoPstn
        {
            get { return _fCodigoPstn; }
            set { SetPropertyValue("CodigoPstn", ref _fCodigoPstn, value); }
        }

        [Index(8)]
        [Size(SizeAttribute.Unlimited)]
        public string UrlBuscadorCodigoPostal
        {
            get { return _fUrlBuscadorCodigoPostal; }
            set { SetPropertyValue("UrlBuscadorCodigoPostal", ref _fUrlBuscadorCodigoPostal, value); }
        }

        [VisibleInListView(false)]
        [Index(9)]
        [Size(60)]
        public string FormatoCodigoPostal
        {
            get { return _fFormatoCodigoPostal; }
            set { SetPropertyValue("FormatoCodigoPostal", ref _fFormatoCodigoPostal, value); }
        }

        [VisibleInListView(false)]
        [Index(10)]
        [Size(SizeAttribute.Unlimited)]
        public string PatronCodigoPostal
        {
            get { return _fPatronCodigoPostal; }
            set { SetPropertyValue("PatronCodigoPostal", ref _fPatronCodigoPostal, value); }
        }

        [VisibleInListView(false)]
        [Index(11)]
        public int Poblacion
        {
            get { return _fPoblacion; }
            set { SetPropertyValue<int>("Poblacion", ref _fPoblacion, value); }
        }

        [VisibleInListView(false)]
        [Index(12)]
        [ModelDefault("DisplayFormat", "{0:N0}"), ModelDefault("EditMask", "N0")]
        public decimal Superficie
        {
            get { return _fSuperficie; }
            set { SetPropertyValue<decimal>("Superficie", ref _fSuperficie, value); }
        }

        [VisibleInListView(false)]
        [Index(13)]
        [Size(50)]
        public string PaisesLimitrofes
        {
            get { return _fPaisesLimitrofes; }
            set { SetPropertyValue("Limitrofes", ref _fPaisesLimitrofes, value); }
        }

        [VisibleInListView(false)]
        [Index(14)]
        [Size(50)]
        public string GeoLatitud
        {
            get { return _fGeoLatitud; }
            set { SetPropertyValue("GeoLatitud", ref _fGeoLatitud, value); }
        }

        [VisibleInListView(false)]
        [Index(15)]
        [Size(50)]
        public string GeoLongitud
        {
            get { return _fGeoLongitud; }
            set { SetPropertyValue("GeoLongitud", ref _fGeoLongitud, value); }
        }

        [VisibleInListView(false)]
        [Index(16)]
        [Size(255)]
        public string GeoCodeAddr
        {
            get { return _fGeoCodeAddr; }
            set { SetPropertyValue("GeoCodeAddr", ref _fGeoCodeAddr, value); }
        }

        [VisibleInListView(false)]
        [Index(17)]
        [Size(10)]
        public string GeoNameid
        {
            get { return _fGeoNameid; }
            set { SetPropertyValue("GeoNameid", ref _fGeoNameid, value); }
        }

        [VisibleInListView(false)]
        [Index(18)]
        [Size(3)]
        public string Codigo3
        {
            get { return _fCodigo3; }
            set { SetPropertyValue("Codigo3", ref _fCodigo3, value); }
        }

        [VisibleInListView(false)]
        [Index(19)]
        [Size(3)]
        public string CodigoNum
        {
            get { return _fCodigoNum; }
            set { SetPropertyValue("CodigoNum", ref _fCodigoNum, value); }
        }

        [VisibleInListView(false)]
        [Index(20)]
        [Size(2)]
        public string CodigoFips
        {
            get { return _fCodigoFips; }
            set { SetPropertyValue("CodigoFips", ref _fCodigoFips, value); }
        }

        [VisibleInListView(false)]
        [Index(21)]
        [Size(2)]
        public string CodigoTld
        {
            get { return _fCodigoTld; }
            set { SetPropertyValue("CodigoTld", ref _fCodigoTld, value); }
        }

        [VisibleInListView(false)]
        [Index(22)]
        [Size(50)]
        public string PaisEng
        {
            get { return _fPaisEng; }
            set { SetPropertyValue("PaisEng", ref _fPaisEng, value); }
        }

        [Association(@"ProvinciasReferencesPaises", typeof (Provincia))]
        [Index(0)]
        public XPCollection<Provincia> Provincias => GetCollection<Provincia>("Provincias");

        [Association(@"CiudadesReferencesPaises", typeof (Ciudad))]
        [Index(1)]
        public XPCollection<Ciudad> Ciudades => GetCollection<Ciudad>("Ciudades");

        [Association(@"PaisesIdiomasReferencesPaises", typeof (PaisIdioma))]
        [Index(2)]
        public XPCollection<PaisIdioma> IdiomasAsociados => GetCollection<PaisIdioma>("IdiomasAsociados");

        [Association(@"IdentificacionesTiposReferencesPaises", typeof (IdentificacionTipo))]
        [Index(3)]
        public XPCollection<IdentificacionTipo> IdentificacionesTiposAsociados => GetCollection<IdentificacionTipo>("IdentificacionesTiposAsociados");

        [Association(@"ImpuestosReferencesPaises", typeof (Impuesto))]
        [Index(4)]
        public XPCollection<Impuesto> ImpuestosAsociados => GetCollection<Impuesto>("ImpuestosAsociados");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}