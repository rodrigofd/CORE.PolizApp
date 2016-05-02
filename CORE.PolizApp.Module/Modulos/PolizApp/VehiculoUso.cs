using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.VehiculoUso")]
    public class VehiculoUso : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;
        private string _fsmartixId;

        public VehiculoUso(Session session) : base(session)
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

        [Size(10)]
        public string SmartixId
        {
            get { return _fsmartixId; }
            set { SetPropertyValue("smartix_Id", ref _fsmartixId, value); }
        }

        [Association(@"DocumentoItemReferencesVehiculoUso")]
        public XPCollection<DocumentoItem> DocumentoItems => GetCollection<DocumentoItem>("DocumentoItems");
    }
}