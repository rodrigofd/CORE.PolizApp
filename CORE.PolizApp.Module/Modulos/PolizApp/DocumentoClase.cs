using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.DocumentoClase")]
    [DefaultProperty("Codigo")]
    public class DocumentoClase : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;

        public DocumentoClase(Session session) : base(session)
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
        /*
        [Association(@"DocumentoReferencesDocumentoClase")]
        public XPCollection<Documento> Documentos => GetCollection<Documento>("Documentos");
        */
        [Association(@"DocumentoClaseTipoReferencesDocumentoClase")]
        public XPCollection<DocumentoClaseTipo> DocumentoClaseTipos => GetCollection<DocumentoClaseTipo>("DocumentoClaseTipos");
    }
}