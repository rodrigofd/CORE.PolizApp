using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.General.Modulos.AFIP
{
    [Persistent(@"afip.CaeMotivo")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"CaeMotivos")]
    [DefaultClassOptions]
public class AfipCaeMotivo : BasicObject
    {
        private string _fCaeMotivo;
        private int _fCodigo;

        public AfipCaeMotivo(Session session)
            : base(session)
        {
        }

        [Size(10)]
        public int Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue<int>("Codigo", ref _fCodigo, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Nombre
        {
            get { return _fCaeMotivo; }
            set { SetPropertyValue("Nombre", ref _fCaeMotivo, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}