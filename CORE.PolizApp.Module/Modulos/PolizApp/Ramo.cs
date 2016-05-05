using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.Ramo")]
    [DefaultProperty("Codigo")]

    public class Ramo : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;
        private RamoClase _fRamoClase;
        private int _fssnRamo;

        public Ramo(Session session) : base(session)
        {
        }

        [Association(@"RamoReferencesRamoClase")]
        public RamoClase RamoClase
        {
            get { return _fRamoClase; }
            set { SetPropertyValue("RamoClase", ref _fRamoClase, value); }
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

        public int SSNRamo
        {
            get { return _fssnRamo; }
            set { SetPropertyValue<int>("SSNRamo", ref _fssnRamo, value); }
        }
        /*
        [Association(@"CoberturaReferencesRamo")]
        public XPCollection<Cobertura> Coberturas => GetCollection<Cobertura>("Coberturas");

        [Association(@"DocumentoReferencesRamo")]
        public XPCollection<Documento> Documentos => GetCollection<Documento>("Documentos");

        [Association(@"IntermediarioComisionReferencesRamo")]
        public XPCollection<IntermediarioComision> IntermediarioComisiones => GetCollection<IntermediarioComision>("IntermediarioComisiones");

        [Association(@"RefacturacionItemReferencesRamo")]
        public XPCollection<RefacturacionItem> RefacturacionItems => GetCollection<RefacturacionItem>("RefacturacionItems");

        [Association(@"RendicionItemImportadoReferencesRamo")]
        public XPCollection<RendicionItemImportado> RendicionItemImportados => GetCollection<RendicionItemImportado>("RendicionItemImportados");
        */
        [Association(@"RamoTipoReferencesRamo")]
        public XPCollection<RamoTipo> RamoTipos => GetCollection<RamoTipo>("RamoTipos");

    }
}