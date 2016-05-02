using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Ciudad")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Ciudad")]
    [DefaultClassOptions]
public class Ciudad : BasicObject
    {
        private string _fCodigo;
        private string _fGeoLatitud;
        private string _fGeoLongitud;
        private Localidad _fLocalidad;
        private string _fNombre;

        private Pais _fPais;
        private int _fPoblacion;
        private Provincia _fProvincia;

        public Ciudad(Session session) : base(session)
        {
        }

        [Association(@"CiudadesReferencesPaises")]
        public Pais Pais
        {
            get { return _fPais; }
            set { SetPropertyValue("Pais", ref _fPais, value); }
        }

        [Association(@"CiudadesReferencesProvincias")]
        public Provincia Provincia
        {
            get { return _fProvincia; }
            set { SetPropertyValue("Provincia", ref _fProvincia, value); }
        }

        [Association(@"CiudadesReferencesLocalidades")]
        public Localidad Localidad
        {
            get { return _fLocalidad; }
            set { SetPropertyValue("Localidad", ref _fLocalidad, value); }
        }

        [Size(20)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(200)]
        [Index(1)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Size(50)]
        public string GeoLatitud
        {
            get { return _fGeoLatitud; }
            set { SetPropertyValue("GeoLatitud", ref _fGeoLatitud, value); }
        }

        [Size(50)]
        public string GeoLongitud
        {
            get { return _fGeoLongitud; }
            set { SetPropertyValue("GeoLongitud", ref _fGeoLongitud, value); }
        }

        public int Poblacion
        {
            get { return _fPoblacion; }
            set { SetPropertyValue<int>("Poblacion", ref _fPoblacion, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}