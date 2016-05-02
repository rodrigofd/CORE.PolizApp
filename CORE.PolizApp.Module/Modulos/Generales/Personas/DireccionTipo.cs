using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.DireccionTipo")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Tipo de dirección")]
    [DefaultClassOptions]
public class DireccionTipo : BasicObject
    {
        private string _fCodigo;
        private string _fDireccionTipo;

        public DireccionTipo(Session session)
            : base(session)
        {
        }

        [Size(10)]
        [System.ComponentModel.DisplayName(@"Código")]
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
            get { return _fDireccionTipo; }
            set { SetPropertyValue("Nombre", ref _fDireccionTipo, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}