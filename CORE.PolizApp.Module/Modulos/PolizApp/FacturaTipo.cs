using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.FacturaTipo")]
    public class FacturaTipo : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;
        private int _fSigno;

        public FacturaTipo(Session session) : base(session)
        {
        }

        [Size(50)]
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

        public int Signo
        {
            get { return _fSigno; }
            set { SetPropertyValue<int>("Signo", ref _fSigno, value); }
        }

        [Association(@"DocumentoReferencesFacturaTipo")]
        public XPCollection<Documento> Documentos => GetCollection<Documento>("Documentos");
    }
}