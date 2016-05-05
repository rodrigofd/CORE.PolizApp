using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.DocumentoClaseTipo")]
    [DefaultProperty("Codigo")]

    public class DocumentoClaseTipo : BasicObject
    {
        private string _fCodigo;
        private DocumentoClase _fDocumentoClase;
        private string _fNombre;
        private int _fssnOperacion;

        public DocumentoClaseTipo(Session session) : base(session)
        {
        }

        [Association(@"DocumentoClaseTipoReferencesDocumentoClase")]
        public DocumentoClase DocumentoClase
        {
            get { return _fDocumentoClase; }
            set { SetPropertyValue("DocumentoClase", ref _fDocumentoClase, value); }
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

        [Persistent("ssn_Operacion")]
        public int SSNOperacion
        {
            get { return _fssnOperacion; }
            set { SetPropertyValue<int>("SSNOperacion", ref _fssnOperacion, value); }
        }
        /*
        [Association(@"DocumentoReferencesDocumentoClaseTipo")]
        public XPCollection<Documento> Documentos => GetCollection<Documento>("Documentos");
        */
    }
}