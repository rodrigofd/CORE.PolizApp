using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Localidad")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Localidad")]
    public class Localidad : BasicObject
    {
        private string fCodigo;
        private string fCodigoPostal;

        private string fLocalidad;
        private Provincia fProvincia;

        public Localidad(Session session) : base(session)
        {
        }

        [Association(@"LocalidadesReferencesProvincias")]
        public Provincia Provincia
        {
            get { return fProvincia; }
            set { SetPropertyValue("Provincia", ref fProvincia, value); }
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
        [System.ComponentModel.DisplayName(@"Localidad")]
        public string Nombre
        {
            get { return fLocalidad; }
            set { SetPropertyValue("Nombre", ref fLocalidad, value); }
        }

        [Size(20)]
        public string CodigoPostal
        {
            get { return fCodigoPostal; }
            set { SetPropertyValue("CodigoPostal", ref fCodigoPostal, value); }
        }

        [Association(@"CiudadesReferencesLocalidades", typeof (Ciudad))]
        public XPCollection<Ciudad> Ciudades => GetCollection<Ciudad>("Ciudades");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}