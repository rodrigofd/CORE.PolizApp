using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.DocumentoTipo")]
    public class DocumentoTipo : BasicObject
    {
        private string _fclase;
        private string _fCodigo;
        private string _fNombre;
        private int _fssnOperacion;
        private string _fsubclase;

        public DocumentoTipo(Session session) : base(session)
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

        [Persistent(@"ssn_Operacion")]
        public int SsnOperacion
        {
            get { return _fssnOperacion; }
            set { SetPropertyValue<int>("SsnOperacion", ref _fssnOperacion, value); }
        }

        [Size(1)]
        public string Clase
        {
            get { return _fclase; }
            set { SetPropertyValue("clase", ref _fclase, value); }
        }

        [Size(1)]
        public string Subclase
        {
            get { return _fsubclase; }
            set { SetPropertyValue("subclase", ref _fsubclase, value); }
        }
    }
}