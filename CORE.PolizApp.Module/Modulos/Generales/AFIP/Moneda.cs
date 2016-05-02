using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.General.Modulos.AFIP
{
    [Persistent(@"afip.Moneda")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Monedas AFIP")]
    [DefaultClassOptions]
public class AfipMoneda : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;

        public AfipMoneda(Session session)
            : base(session)
        {
        }

        [Size(10)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(255)]
        [Index(1)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}