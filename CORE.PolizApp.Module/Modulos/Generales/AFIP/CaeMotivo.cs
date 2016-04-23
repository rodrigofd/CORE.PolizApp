using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Xpo;

namespace CORE.General.Modulos.AFIP
{
    [Persistent(@"afip.CaeMotivo")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"CaeMotivos")]
    public class afip_CaeMotivo : BasicObject
    {
        private string fCaeMotivo;
        private int fCodigo;

        public afip_CaeMotivo(Session session)
            : base(session)
        {
        }

        [Size(10)]
        public int Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue<int>("Codigo", ref fCodigo, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Nombre
        {
            get { return fCaeMotivo; }
            set { SetPropertyValue("Nombre", ref fCaeMotivo, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}