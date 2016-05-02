using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Localidad")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Localidad")]
    [DefaultClassOptions]
public class Localidad : BasicObject
    {
        private string _fCodigo;
        private string _fCodigoPostal;

        private string _fLocalidad;
        private Provincia _fProvincia;

        public Localidad(Session session) : base(session)
        {
        }

        [Association(@"LocalidadesReferencesProvincias")]
        public Provincia Provincia
        {
            get { return _fProvincia; }
            set { SetPropertyValue("Provincia", ref _fProvincia, value); }
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
        [System.ComponentModel.DisplayName(@"Localidad")]
        public string Nombre
        {
            get { return _fLocalidad; }
            set { SetPropertyValue("Nombre", ref _fLocalidad, value); }
        }

        [Size(20)]
        public string CodigoPostal
        {
            get { return _fCodigoPostal; }
            set { SetPropertyValue("CodigoPostal", ref _fCodigoPostal, value); }
        }

        [Association(@"CiudadesReferencesLocalidades", typeof (Ciudad))]
        public XPCollection<Ciudad> Ciudades => GetCollection<Ciudad>("Ciudades");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}