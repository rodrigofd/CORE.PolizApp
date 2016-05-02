using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.TasaRiesgoUM")]
    public class TasaRiesgoUm : BasicObject
    {
        private string _fCodigo;
        private decimal _fCoeficiente;
        private string _fNombre;

        public TasaRiesgoUm(Session session) : base(session)
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

        public decimal Coeficiente
        {
            get { return _fCoeficiente; }
            set { SetPropertyValue<decimal>("Coeficiente", ref _fCoeficiente, value); }
        }

        [Association(@"CoberturaReferencesTasaRiesgoUM")]
        public XPCollection<Cobertura> Coberturas => GetCollection<Cobertura>("Coberturas");

        [Association(@"DocumentoReferencesTasaRiesgoUM")]
        public XPCollection<Documento> Documentos => GetCollection<Documento>("Documentos");
    }
}