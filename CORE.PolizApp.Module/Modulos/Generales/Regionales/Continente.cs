using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Regionales
{
    [Persistent(@"regionales.Continente")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Continente")]
    public class regionales_Continente : BasicObject
    {
        private string fCodigo;
        private string fNombre;

        public regionales_Continente(Session session) : base(session)
        {
        }

        [Size(2)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(20)]
        [Index(1)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        [Association(@"PaisesReferencesContinentes", typeof (regionales_Pais))]
        public XPCollection<regionales_Pais> Paises
        {
            get { return GetCollection<regionales_Pais>("Paises"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}