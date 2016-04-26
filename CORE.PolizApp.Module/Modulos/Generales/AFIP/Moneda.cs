using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.AFIP
{
    [Persistent(@"afip.Moneda")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Monedas AFIP")]
    public class afip_Moneda : BasicObject
    {
        private string fCodigo;
        private string fNombre;

        public afip_Moneda(Session session)
            : base(session)
        {
        }

        [Size(10)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(255)]
        [Index(1)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}