using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Continente")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Continente")]
    [DefaultClassOptions]
public class Continente : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;

        public Continente(Session session) : base(session)
        {
        }

        [Size(2)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(20)]
        [Index(1)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Association(@"PaisesReferencesContinentes", typeof (Pais))]
        public XPCollection<Pais> Paises => GetCollection<Pais>("Paises");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}