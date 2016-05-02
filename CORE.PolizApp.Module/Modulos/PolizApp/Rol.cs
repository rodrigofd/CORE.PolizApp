using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.Rol")]
    public class Rol : BasicObject
    {
        private string _fCodigo;
        private bool _fDePoliza;
        private string _fNombre;

        public Rol(Session session) : base(session)
        {
        }

        [Size(10)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(50)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        public bool DePoliza
        {
            get { return _fDePoliza; }
            set { SetPropertyValue("DePoliza", ref _fDePoliza, value); }
        }

        [Association(@"DocumentoIntervinienteReferencesRol")]
        public XPCollection<DocumentoInterviniente> DocumentoIntervinientes => GetCollection<DocumentoInterviniente>("DocumentoIntervinientes");
    }
}