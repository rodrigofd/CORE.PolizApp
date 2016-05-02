using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.DocumentoItemTipo")]
    public class DocumentoItemTipo : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;

        public DocumentoItemTipo(Session session) : base(session)
        {
        }

        [Size(1)]
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

        [Association(@"DocumentoItemReferencesDocumentoItemTipo")]
        public XPCollection<DocumentoItem> DocumentoItems => GetCollection<DocumentoItem>("DocumentoItems");
    }
}