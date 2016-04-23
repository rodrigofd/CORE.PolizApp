using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

//using CORE.General.Modulos.Sistema;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.DireccionTipo")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Tipo de dirección")]
    public class DireccionTipo : BasicObject //, IObjetoPorGrupo
    {
        private string fCodigo;
        private string fDireccionTipo;

        public DireccionTipo(Session session)
            : base(session)
        {
        }

        [Size(10)]
        [System.ComponentModel.DisplayName(@"Código")]
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