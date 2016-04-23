using System.ComponentModel;
using CORE.ES.Module.Modulos.Escribania;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Gestion
{
    [Persistent(@"gestion.CondicionDePago")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName("Condición de pago")]
    public class CondicionDePago : BasicObject
    {
        private bool fActivo;
        private string fCodigo;
        private string fNombre;

        public CondicionDePago(Session session) : base(session)
        {
        }

        [Size(20)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(50)]
        [Index(1)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        public bool Activo
        {
            get { return fActivo; }
            set { SetPropertyValue("Activo", ref fActivo, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}