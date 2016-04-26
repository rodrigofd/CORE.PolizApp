using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.DireccionTipo")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Tipo de direcci�n")]
    public class DireccionTipo : BasicObject
    {
        private string fCodigo;
        private string fDireccionTipo;

        public DireccionTipo(Session session)
            : base(session)
        {
        }

        [Size(10)]
        [System.ComponentModel.DisplayName(@"C�digo")]
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
            get { return fDireccionTipo; }
            set { SetPropertyValue("Nombre", ref fDireccionTipo, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}