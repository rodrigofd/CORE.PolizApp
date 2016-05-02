using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.FacturaPeriodicidad")]
    public class FacturaPeriodicidad : BasicObject
    {
        private string _fCodigo;
        private int _fMeses;
        private string _fNombre;
        private int _forden;
        private int _fsmartixId;

        public FacturaPeriodicidad(Session session) : base(session)
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

        public int Meses
        {
            get { return _fMeses; }
            set { SetPropertyValue<int>("Meses", ref _fMeses, value); }
        }

        public int Orden
        {
            get { return _forden; }
            set { SetPropertyValue<int>("orden", ref _forden, value); }
        }

        [Persistent(@"smartix_Id")]
        public int SmartixId
        {
            get { return _fsmartixId; }
            set { SetPropertyValue<int>("SmartixId", ref _fsmartixId, value); }
        }

        [Association(@"DocumentoReferencesFacturaPeriodicidad")]
        public XPCollection<Documento> Documentos => GetCollection<Documento>("Documentos");
    }
}