using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Provincia")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Provincia")]
    [DefaultClassOptions]
public class Provincia : BasicObject
    {
        private string _fCodigo;
        private Pais _fPais;
        private string _fProvincia;

        public Provincia(Session session) : base(session)
        {
        }

        [Association(@"ProvinciasReferencesPaises")]
        public Pais Pais
        {
            get { return _fPais; }
            set { SetPropertyValue("Pais", ref _fPais, value); }
        }

        [Size(10)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(50)]
        [Index(1)]
        [System.ComponentModel.DisplayName(@"Provincia")]
        public string Nombre
        {
            get { return _fProvincia; }
            set { SetPropertyValue("Nombre", ref _fProvincia, value); }
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