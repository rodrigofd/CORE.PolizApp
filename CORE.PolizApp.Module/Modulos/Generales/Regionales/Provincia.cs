using System.ComponentModel;
using CORE.ES.Module.Modulos.Escribania;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Regionales
{
    [Persistent(@"regionales.Provincia")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Provincia")]
    public class regionales_Provincia : BasicObject
    {
        private string fCodigo;
        private regionales_Pais fPais;
        private string fProvincia;

        public regionales_Provincia(Session session) : base(session)
        {
        }

        [Association(@"ProvinciasReferencesPaises")]
        public regionales_Pais Pais
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

        [Association(@"CiudadesReferencesProvincias", typeof (regionales_Ciudad))]
        public XPCollection<regionales_Ciudad> Ciudades
        {
            get { return GetCollection<regionales_Ciudad>("Ciudades"); }
        }

        [Association(@"LocalidadesReferencesProvincias", typeof (regionales_Localidad))]
        public XPCollection<regionales_Localidad> Localidades
        {
            get { return GetCollection<regionales_Localidad>("Localidades"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}