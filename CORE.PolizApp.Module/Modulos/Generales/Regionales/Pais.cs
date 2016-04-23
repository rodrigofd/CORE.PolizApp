using System;
using System.ComponentModel;
using System.Drawing;
using CORE.General.Modulos.Impuestos;
using CORE.PolizApp.Personas;
using CORE.General.Modulos.Sistema;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace CORE.General.Modulos.Regionales
{
    public class FiltroPorPaisAttribute : Attribute
    {
        public bool Filtrar = true;

        public FiltroPorPaisAttribute()
        {
        }

        public FiltroPorPaisAttribute(bool filtrar)
        {
            Filtrar = filtrar;
        }
    }

    [Persistent(@"regionales.Pais")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"País")]
    public class regionales_Pais : BasicObject
    {
        private string fCapital;
        private string fCodigo;
        private string fCodigo3;
        private string fCodigoFips;
        private string fCodigoNum;
        private string fCodigoPstn;
        private string fCodigoTld;
        private regionales_Continente fContinente;
        private string fFormatoCodigoPostal;
        private string fGeoCodeAddr;
        private string fGeoLatitud;
        private string fGeoLongitud;
        private string fGeoNameid;
        private regionales_PaisIdioma fIdiomaNativo;
        private Image fImagenBandera;
        private Image fImagenBanderaChica;
        private string fPais;
        private string fPaisEng;
        private string fPaisesLimitrofes;
        private string fPatronCodigoPostal;
        private int fPoblacion;
        private decimal fSuperficie;
        private string fUrlBuscadorCodigoPostal;

        public regionales_Pais(Session session) : base(session)
        {
        }

        [ModelDefault("ImageSizeMode", "Normal")]
        [Index(0)]
        [VisibleInLookupListView(true)]
        [ValueConverter(typeof (ImageValueConverter))]
        public Image ImagenBanderaChica
        {
            get { return fImagenBanderaChica; }
            set { SetPropertyValue("ImagenBanderaChica", ref fImagenBanderaChica, value); }
        }

        [VisibleInListView(false)]
        [Index(1)]
        [Delayed(true)]
        [ValueConverter(typeof (ImageValueConverter))]
        [Size(SizeAttribute.Unlimited)]
        public Image ImagenBandera
        {
            get { return fImagenBandera; }
            set { SetPropertyValue("ImagenBandera", ref fImagenBandera, value); }
        }

        [Index(2)]
        [Size(2)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Index(3)]
        [System.ComponentModel.DisplayName(@"País")]
        public string Nombre
        {
            get { return fPais; }
            set { SetPropertyValue("Nombre", ref fPais, value); }
        }

        [Association(@"PaisesReferencesContinentes")]
        [Index(4)]
        public regionales_Continente Continente
        {
            get { return fContinente; }
            set { SetPropertyValue("Continente", ref fContinente, value); }
        }

        [Index(5)]
        public string Capital
        {
            get { return fCapital; }
            set { SetPropertyValue("Capital", ref fCapital, value); }
        }

        [Index(6)]
        public regionales_PaisIdioma IdiomaNativo
        {
            get { return fIdiomaNativo; }
            set { SetPropertyValue("IdiomaNativo", ref fIdiomaNativo, value); }
        }

        [Index(7)]
        [Size(15)]
        public string CodigoPstn
        {
            get { return fCodigoPstn; }
            set { SetPropertyValue("CodigoPstn", ref fCodigoPstn, value); }
        }

        [Index(8)]
        [Size(SizeAttribute.Unlimited)]
        public string UrlBuscadorCodigoPostal
        {
            get { return fUrlBuscadorCodigoPostal; }
            set { SetPropertyValue("UrlBuscadorCodigoPostal", ref fUrlBuscadorCodigoPostal, value); }
        }

        [VisibleInListView(false)]
        [Index(9)]
        [Size(60)]
        public string FormatoCodigoPostal
        {
            get { return fFormatoCodigoPostal; }
            set { SetPropertyValue("FormatoCodigoPostal", ref fFormatoCodigoPostal, value); }
        }

        [VisibleInListView(false)]
        [Index(10)]
        [Size(SizeAttribute.Unlimited)]
        public string PatronCodigoPostal
        {
            get { return fPatronCodigoPostal; }
            set { SetPropertyValue("PatronCodigoPostal", ref fPatronCodigoPostal, value); }
        }

        [VisibleInListView(false)]
        [Index(11)]
        public int Poblacion
        {
            get { return fPoblacion; }
            set { SetPropertyValue<int>("Poblacion", ref fPoblacion, value); }
        }

        [VisibleInListView(false)]
        [Index(12)]
        [ModelDefault("DisplayFormat", "{0:N0}"), ModelDefault("EditMask", "N0")]
        public decimal Superficie
        {
            get { return fSuperficie; }
            set { SetPropertyValue<decimal>("Superficie", ref fSuperficie, value); }
        }

        [VisibleInListView(false)]
        [Index(13)]
        [Size(50)]
        public string PaisesLimitrofes
        {
            get { return fPaisesLimitrofes; }
            set { SetPropertyValue("Limitrofes", ref fPaisesLimitrofes, value); }
        }

        [VisibleInListView(false)]
        [Index(14)]
        [Size(50)]
        public string GeoLatitud
        {
            get { return fGeoLatitud; }
            set { SetPropertyValue("GeoLatitud", ref fGeoLatitud, value); }
        }

        [VisibleInListView(false)]
        [Index(15)]
        [Size(50)]
        public string GeoLongitud
        {
            get { return fGeoLongitud; }
            set { SetPropertyValue("GeoLongitud", ref fGeoLongitud, value); }
        }

        [VisibleInListView(false)]
        [Index(16)]
        [Size(255)]
        public string GeoCodeAddr
        {
            get { return fGeoCodeAddr; }
            set { SetPropertyValue("GeoCodeAddr", ref fGeoCodeAddr, value); }
        }

        [VisibleInListView(false)]
        [Index(17)]
        [Size(10)]
        public string GeoNameid
        {
            get { return fGeoNameid; }
            set { SetPropertyValue("GeoNameid", ref fGeoNameid, value); }
        }

        [VisibleInListView(false)]
        [Index(18)]
        [Size(3)]
        public string Codigo3
        {
            get { return fCodigo3; }
            set { SetPropertyValue("Codigo3", ref fCodigo3, value); }
        }

        [VisibleInListView(false)]
        [Index(19)]
        [Size(3)]
        public string CodigoNum
        {
            get { return fCodigoNum; }
            set { SetPropertyValue("CodigoNum", ref fCodigoNum, value); }
        }

        [VisibleInListView(false)]
        [Index(20)]
        [Size(2)]
        public string CodigoFips
        {
            get { return fCodigoFips; }
            set { SetPropertyValue("CodigoFips", ref fCodigoFips, value); }
        }

        [VisibleInListView(false)]
        [Index(21)]
        [Size(2)]
        public string CodigoTld
        {
            get { return fCodigoTld; }
            set { SetPropertyValue("CodigoTld", ref fCodigoTld, value); }
        }

        [VisibleInListView(false)]
        [Index(22)]
        [Size(50)]
        public string PaisEng
        {
            get { return fPaisEng; }
            set { SetPropertyValue("PaisEng", ref fPaisEng, value); }
        }

        [Association(@"ProvinciasReferencesPaises", typeof (regionales_Provincia))]
        [Index(0)]
        public XPCollection<regionales_Provincia> Provincias
        {
            get { return GetCollection<regionales_Provincia>("Provincias"); }
        }

        [Association(@"CiudadesReferencesPaises", typeof (regionales_Ciudad))]
        [Index(1)]
        public XPCollection<regionales_Ciudad> Ciudades
        {
            get { return GetCollection<regionales_Ciudad>("Ciudades"); }
        }

        [Association(@"PaisesIdiomasReferencesPaises", typeof (regionales_PaisIdioma))]
        [Index(2)]
        public XPCollection<regionales_PaisIdioma> IdiomasAsociados
        {
            get { return GetCollection<regionales_PaisIdioma>("IdiomasAsociados"); }
        }

        [Association(@"IdentificacionesTiposReferencesPaises", typeof (personas_IdentificacionTipo))]
        [Index(3)]
        public XPCollection<personas_IdentificacionTipo> IdentificacionesTiposAsociados
        {
            get { return GetCollection<personas_IdentificacionTipo>("IdentificacionesTiposAsociados"); }
        }

        [Association(@"ImpuestosReferencesPaises", typeof (impuestos_Impuesto))]
        [Index(4)]
        public XPCollection<impuestos_Impuesto> ImpuestosAsociados
        {
            get { return GetCollection<impuestos_Impuesto>("ImpuestosAsociados"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}