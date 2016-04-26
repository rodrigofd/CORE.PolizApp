using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.IdentificacionClase")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Clase de identificación")]
    public class IdentificacionClase : BasicObject
    {
        private string fCodigo;
        private string fNombre;

        public IdentificacionClase(Session session)
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

        [Association(@"IdentificacionesTiposReferencesIdentificacionesClases", typeof (IdentificacionTipo))]
        public XPCollection<IdentificacionTipo> IdentificacionesTipos => GetCollection<IdentificacionTipo>("IdentificacionesTipos");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}