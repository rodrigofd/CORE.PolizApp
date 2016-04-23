using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Ciudad")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Ciudad")]
    public class regionales_Ciudad : BasicObject
    {
        private string fCodigo;
        private string fGeoLatitud;
        private string fGeoLongitud;
        private regionales_Localidad fLocalidad;
        private string fNombre;

        private regionales_Pais fPais;
        private int fPoblacion;
        private regionales_Provincia fProvincia;

        public regionales_Ciudad(Session session) : base(session)
        {
        }

        [Association(@"CiudadesReferencesPaises")]
        public regionales_Pais Pais
        {
            get { return fPais; }
            set { SetPropertyValue("Pais", ref fPais, value); }
        }

        [Association(@"CiudadesReferencesProvincias")]
        public regionales_Provincia Provincia
        {
            get { return fProvincia; }
            set { SetPropertyValue("Provincia", ref fProvincia, value); }
        }

        [Association(@"CiudadesReferencesLocalidades")]
        public regionales_Localidad Localidad
        {
            get { return fLocalidad; }
            set { SetPropertyValue("Localidad", ref fLocalidad, value); }
        }

        [Size(20)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(200)]
        [Index(1)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [Size(50)]
        public string GeoLatitud
        {
            get { return fGeoLatitud; }
            set { SetPropertyValue("GeoLatitud", ref fGeoLatitud, value); }
        }

        [Size(50)]
        public string GeoLongitud
        {
            get { return fGeoLongitud; }
            set { SetPropertyValue("GeoLongitud", ref fGeoLongitud, value); }
        }

        public int Poblacion
        {
            get { return fPoblacion; }
            set { SetPropertyValue<int>("Poblacion", ref fPoblacion, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}