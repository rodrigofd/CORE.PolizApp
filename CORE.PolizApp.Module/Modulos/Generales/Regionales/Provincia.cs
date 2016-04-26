using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Provincia")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Provincia")]
    public class Provincia : BasicObject
    {
        private string fCodigo;
        private Pais fPais;
        private string fProvincia;

        public Provincia(Session session) : base(session)
        {
        }

        [Association(@"ProvinciasReferencesPaises")]
        public Pais Pais
        {
            get { return fPais; }
            set { SetPropertyValue("Pais", ref fPais, value); }
        }

        [Size(10)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(50)]
        [Index(1)]
        [System.ComponentModel.DisplayName(@"Provincia")]
        public string Nombre
        {
            get { return fProvincia; }
            set { SetPropertyValue("Nombre", ref fProvincia, value); }
        }

        [Association(@"CiudadesReferencesProvincias", typeof (Ciudad))]
        public XPCollection<Ciudad> Ciudades => GetCollection<Ciudad>("Ciudades");

        [Association(@"LocalidadesReferencesProvincias", typeof (Localidad))]
        public XPCollection<Localidad> Localidades => GetCollection<Localidad>("Localidades");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}