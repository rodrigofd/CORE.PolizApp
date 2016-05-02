using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    //TODO: arreglar
    [DefaultClassOptions]
    [Persistent(@"polizapp.Identificadores")]
    public class Identificadores : XPLiteObject
    {
        private int _fEmpresa;

        public Identificadores(Session session) : base(session)
        {
        }

        [Key]
        public int Empresa
        {
            get { return _fEmpresa; }
            set { SetPropertyValue<int>("Empresa", ref _fEmpresa, value); }
        }
    }
}