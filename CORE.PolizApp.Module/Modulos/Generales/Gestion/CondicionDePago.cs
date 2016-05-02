using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Gestion
{
    [Persistent(@"gestion.CondicionDePago")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Condición de pago")]
    [DefaultClassOptions]
public class CondicionDePago : BasicObject
    {
        private bool _fActivo;
        private string _fCodigo;
        private string _fNombre;

        public CondicionDePago(Session session) : base(session)
        {
        }

        [Size(20)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(50)]
        [Index(1)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        public bool Activo
        {
            get { return _fActivo; }
            set { SetPropertyValue("Activo", ref _fActivo, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}