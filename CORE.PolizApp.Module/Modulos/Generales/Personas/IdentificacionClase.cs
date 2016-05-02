using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.IdentificacionClase")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Clase de identificación")]
    [DefaultClassOptions]
public class IdentificacionClase : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;

        public IdentificacionClase(Session session)
            : base(session)
        {
        }

        [Size(10)]
        [System.ComponentModel.DisplayName(@"Código")]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(50)]
        [Index(1)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Association(@"IdentificacionesTiposReferencesIdentificacionesClases", typeof (IdentificacionTipo))]
        public XPCollection<IdentificacionTipo> IdentificacionesTipos => GetCollection<IdentificacionTipo>("IdentificacionesTipos");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}