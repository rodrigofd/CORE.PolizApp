using CORE.PolizApp.Personas;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.Aseguradora")]
    [DefaultProperty("Persona")]

    public class Aseguradora : BasicObject
    {
        private string _fCodigo;
        private Persona _fPersona;
        private int _fsmartixId;
        private int _fssnAseguradora;

        public Aseguradora(Session session) : base(session)
        {
        }

        public Persona Persona
        {
            get { return _fPersona; }
            set { SetPropertyValue("Persona", ref _fPersona, value); }
        }

        [Size(50)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        public int SsnAseguradora
        {
            get { return _fssnAseguradora; }
            set { SetPropertyValue<int>("ssnAseguradora", ref _fssnAseguradora, value); }
        }

        public int SmartixId
        {
            get { return _fsmartixId; }
            set { SetPropertyValue<int>("smartix_Id", ref _fsmartixId, value); }
        }

        [Association(@"AseguradoraProductorReferencesAseguradora")]
        public XPCollection<AseguradoraProductor> Productores => GetCollection<AseguradoraProductor>("Productores");

        //[Association(@"DocumentoReferencesAseguradora")] 
        //public XPCollection<Documento> Documentos => GetCollection<Documento>("Documentos");

        [Association(@"IntermediarioComisionReferencesAseguradora")]
        public XPCollection<IntermediarioComision> IntermediarioComisiones => GetCollection<IntermediarioComision>("IntermediarioComisiones");

        [Association(@"LiquidacionReferencesAseguradora")]
        public XPCollection<Liquidacion> Liquidaciones => GetCollection<Liquidacion>("Liquidaciones");

        [Association(@"NegocioReferencesAseguradora")]
        public XPCollection<Negocio> Negocios => GetCollection<Negocio>("Negocios");

        [Association(@"RefacturacionReferencesAseguradora")]
        public XPCollection<Refacturacion> Refacturaciones => GetCollection<Refacturacion>("Refacturaciones");

        [Association(@"RendicionReferencesAseguradora")]
        public XPCollection<Rendicion> Rendiciones => GetCollection<Rendicion>("Rendiciones");

        [Association(@"RendicionArtReferencesAseguradora")]
        public XPCollection<RendicionART> RendicionesART => GetCollection<RendicionART>("RendicionesART");

        [Association(@"RendicionVoReferencesAseguradora")]
        public XPCollection<RendicionVO> RendicionesVO => GetCollection<RendicionVO>("RendicionesVO");
    }
}