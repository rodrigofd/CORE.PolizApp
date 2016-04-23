using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.IdentificacionClase")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Clase de identificación")]
    public class personas_IdentificacionClase : BasicObject
    {
        private string fCodigo;
        private string fNombre;

        public personas_IdentificacionClase(Session session)
            : base(session)
        {
        }

        [Size(10)]
        [System.ComponentModel.DisplayName(@"Código")]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(50)]
        [Index(1)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [Association(@"IdentificacionesTiposReferencesIdentificacionesClases", typeof (personas_IdentificacionTipo))]
        public XPCollection<personas_IdentificacionTipo> IdentificacionesTipos
        {
            get { return GetCollection<personas_IdentificacionTipo>("IdentificacionesTipos"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}