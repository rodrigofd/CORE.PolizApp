using System;
using System.Collections.Generic;
using System.ComponentModel;
using CORE.PolizApp.Regionales;
using CORE.PolizApp.Sistema;
using CORE.PolizApp.Regionales;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.Direccion")]
    [DefaultProperty("DireccionCompleta")]
    [ImageName("postage-stamp-at-sign")]
    [System.ComponentModel.DisplayName(@"Dirección")]
    [DefaultClassOptions]
public class Direccion : BasicObject //, IObjetoPorGrupo
    {
        private string _fCalle;
        private Ciudad _fCiudad;
        private string _fCiudadOtra;
        private string _fCodigo;
        private string _fCodigoPostal;
        private string _fDepto;
        private DateTime _fDesde;
        private string _fDireccionCompleta;
        private DireccionTipo _fDireccionTipo;
        private string _fEdificio;
        private string _fEntreCalles;
        private string _fFax;
        private string _fGeoCodeAddr;
        private string _fGeoLatitud;
        private string _fGeoLongitud;
        private DateTime _fHasta;

        //private Grupo fGrupo;
        private Localidad _fLocalidad;
        private string _fLocalidadOtra;
        private string _fNotas;
        private string _fNumero;
        private Pais _fPais;
        private string _fPaisOtro;
        private Persona _fPersona;
        private string _fPiso;
        private Provincia _fProvincia;
        private string _fProvinciaOtra;
        private string _fTelefono;

        public Direccion(Session session) : base(session)
        {
        }

        [Association(@"DireccionesReferencesPersonas")]
        public Persona Persona
        {
            get { return _fPersona; }
            set { SetPropertyValue("Persona", ref _fPersona, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        public DireccionTipo DireccionTipo
        {
            get { return _fDireccionTipo; }
            set { SetPropertyValue("DireccionTipo", ref _fDireccionTipo, value); }
        }

        [Size(50)]
        //[Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"Calle")]
        public string Calle
        {
            get { return _fCalle; }
            set { SetPropertyValue("Calle", ref _fCalle, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"Entre calles")]
        public string EntreCalles
        {
            get { return _fEntreCalles; }
            set { SetPropertyValue("EntreCalles", ref _fEntreCalles, value); }
        }

        [Size(20)]
        [System.ComponentModel.DisplayName(@"Número")]
        public string Numero
        {
            get { return _fNumero; }
            set { SetPropertyValue("Numero", ref _fNumero, value); }
        }

        [Size(20)]
        [System.ComponentModel.DisplayName(@"Edificio")]
        public string Edificio
        {
            get { return _fEdificio; }
            set { SetPropertyValue("Edificio", ref _fEdificio, value); }
        }

        [Size(20)]
        [System.ComponentModel.DisplayName(@"Piso")]
        public string Piso
        {
            get { return _fPiso; }
            set { SetPropertyValue("Piso", ref _fPiso, value); }
        }

        [Size(20)]
        [System.ComponentModel.DisplayName(@"Depto.")]
        public string Depto
        {
            get { return _fDepto; }
            set { SetPropertyValue("Depto", ref _fDepto, value); }
        }

        [Size(20)]
        [System.ComponentModel.DisplayName(@"Código Postal")]
        public string CodigoPostal
        {
            get { return _fCodigoPostal; }
            set { SetPropertyValue("CodigoPostal", ref _fCodigoPostal, value); }
        }

        //[ImmediatePostData]
        [DataSourceProperty("Localidad.Ciudades")]
        [System.ComponentModel.DisplayName(@"Ciudad")]
        public Ciudad Ciudad
        {
            get { return _fCiudad; }
            set { SetPropertyValue("Ciudad", ref _fCiudad, value); }
        }

        [Appearance("manual_ciudad", Criteria = "Not IsNull(Ciudad)", Visibility = ViewItemVisibility.Hide)]
        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"Ingrese ciudad")]
        public string CiudadOtra
        {
            get { return _fCiudadOtra; }
            set { SetPropertyValue("CiudadOtra", ref _fCiudadOtra, value); }
        }

        //[ImmediatePostData]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Provincia.Localidades")]
        [System.ComponentModel.DisplayName(@"Localidad")]
        public Localidad Localidad
        {
            get { return _fLocalidad; }
            set { SetPropertyValue("Localidad", ref _fLocalidad, value); }
        }

        [Appearance("manual_localidad", Criteria = "Not IsNull(Localidad)", Visibility = ViewItemVisibility.Hide)]
        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"Ingrese localidad")]
        public string LocalidadOtra
        {
            get { return _fLocalidadOtra; }
            set { SetPropertyValue("LocalidadOtra", ref _fLocalidadOtra, value); }
        }

        //[ImmediatePostData]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Pais.Provincias")]
        [System.ComponentModel.DisplayName(@"Provincia")]
        public Provincia Provincia
        {
            get { return _fProvincia; }
            set { SetPropertyValue("Provincia", ref _fProvincia, value); }
        }

        [Appearance("manual_provincia", Criteria = "Not IsNull(Provincia)", Visibility = ViewItemVisibility.Hide)]
        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"Ingrese provincia")]
        public string ProvinciaOtra
        {
            get { return _fProvinciaOtra; }
            set { SetPropertyValue("ProvinciaOtra", ref _fProvinciaOtra, value); }
        }

        //[ImmediatePostData]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"País")]
        public Pais Pais
        {
            get { return _fPais; }
            set { SetPropertyValue("Pais", ref _fPais, value); }
        }

        [Appearance("manual_pais", Criteria = "Not IsNull(Pais)", Visibility = ViewItemVisibility.Hide)]
        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"Ingrese país")]
        public string PaisOtro
        {
            get { return _fPaisOtro; }
            set { SetPropertyValue("PaisOtro", ref _fPaisOtro, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"Teléfono")]
        public string Telefono
        {
            get { return _fTelefono; }
            set { SetPropertyValue("Telefono", ref _fTelefono, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"Fax")]
        public string Fax
        {
            get { return _fFax; }
            set { SetPropertyValue("Fax", ref _fFax, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"Notas")]
        public string Notas
        {
            get { return _fNotas; }
            set { SetPropertyValue("Notas", ref _fNotas, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [Browsable(false)]
        [System.ComponentModel.DisplayName(@"Geo. latitud")]
        public string GeoLatitud
        {
            get { return _fGeoLatitud; }
            set { SetPropertyValue("GeoLatitud", ref _fGeoLatitud, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [Browsable(false)]
        [System.ComponentModel.DisplayName(@"Geo. longitud")]
        public string GeoLongitud
        {
            get { return _fGeoLongitud; }
            set { SetPropertyValue("GeoLongitud", ref _fGeoLongitud, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [Browsable(false)]
        [System.ComponentModel.DisplayName(@"Geo. Cod.")]
        public string GeoCodeAddr
        {
            get { return _fGeoCodeAddr; }
            set { SetPropertyValue("GeoCodeAddr", ref _fGeoCodeAddr, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        //[Browsable( false )]
        [VisibleInDetailView(false)]
        [System.ComponentModel.DisplayName(@"Dirección completa")]
        public string DireccionCompleta
        {
            get { return _fDireccionCompleta; }
            set { SetPropertyValue("DireccionCompleta", ref _fDireccionCompleta, value); }
        }

        public DateTime Desde
        {
            get { return _fDesde; }
            set { SetPropertyValue<DateTime>("Desde", ref _fDesde, value); }
        }

        public DateTime Hasta
        {
            get { return _fHasta; }
            set { SetPropertyValue<DateTime>("Hasta", ref _fHasta, value); }
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            if (CanRaiseOnChanged && propertyName != "DireccionCompleta")
                CalcularDireccionCompleta();
        }

        private void CalcularDireccionCompleta()
        {
            string ciudad = (!string.IsNullOrWhiteSpace(CiudadOtra) ? CiudadOtra : (Ciudad != null ? Ciudad.Nombre : ""));
            string localidad = (!string.IsNullOrWhiteSpace(LocalidadOtra)
                ? LocalidadOtra
                : (Localidad != null ? Localidad.Nombre : ""));
            string provincia = (!string.IsNullOrWhiteSpace(ProvinciaOtra)
                ? ProvinciaOtra
                : (Provincia != null ? Provincia.Nombre : ""));
            string pais = (!string.IsNullOrWhiteSpace(PaisOtro) ? PaisOtro : (Pais != null ? Pais.Nombre : ""));

            if (Calle == null) Calle = "";

            string ret = Calle.Replace(Environment.NewLine, " ");
            if (!string.IsNullOrWhiteSpace(Numero)) ret += " " + Numero;
            if (!string.IsNullOrWhiteSpace(Piso)) ret += " Piso " + Piso;
            if (!string.IsNullOrWhiteSpace(Depto)) ret += " Depto. " + Depto;
            if (!string.IsNullOrWhiteSpace(CodigoPostal)) ret += " (" + CodigoPostal + ")";

            var ubicaciones = new List<string>();

            if (!string.IsNullOrWhiteSpace(ciudad)) ubicaciones.Add(ciudad);
            if (!string.IsNullOrWhiteSpace(localidad) && localidad != ciudad) ubicaciones.Add(localidad);
            if (!string.IsNullOrWhiteSpace(provincia) && provincia != localidad) ubicaciones.Add(provincia);
            if (!string.IsNullOrWhiteSpace(pais)) ubicaciones.Add(pais);

            ret += (ubicaciones.Count > 0 ? " " : "") + string.Join(", ", ubicaciones);

            DireccionCompleta = ret;
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            //Pais = Regionales.Identificadores.GetInstance(Session).PaisPredeterminado;
        }
    }
}