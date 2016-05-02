using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.VehiculoMarca")]
    public class VehiculoMarca : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;

        public VehiculoMarca(Session session) : base(session)
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

        [Association(@"DocumentoItemReferencesVehiculoMarca")]
        public XPCollection<DocumentoItem> DocumentoItems => GetCollection<DocumentoItem>("DocumentoItems");

        [Association(@"VehiculoModeloReferencesVehiculoMarca")]
        public XPCollection<VehiculoModelo> Modelos => GetCollection<VehiculoModelo>("Modelos");
    }
}