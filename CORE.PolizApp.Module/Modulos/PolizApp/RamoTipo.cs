using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.RamoTipo")]
    [DefaultProperty("Codigo")]

    public class RamoTipo : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;
        private Ramo _fRamo;

        public RamoTipo(Session session) : base(session)
        {
        }

        [Association(@"RamoTipoReferencesRamo")]
        public Ramo Ramo
        {
            get { return _fRamo; }
            set { SetPropertyValue("Ramo", ref _fRamo, value); }
        }

        [Size(50)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }
        /*
        [Association(@"DocumentoReferencesRamoTipo")]
        public XPCollection<Documento> Documentos => GetCollection<Documento>("Documentos");
        */
    }
}