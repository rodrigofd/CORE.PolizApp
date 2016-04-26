using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Impuestos
{
    [Persistent(@"impuestos.Categoria")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Categorías")]
    public class Categoria : BasicObject
    {
        private string fCodigo;
        //private int fCodigoAfip;
        //private int fIdCategoria; 
        private Impuesto _f;
        private string fNombre;

        private int fOrden;

        public Categoria(Session session)
            : base(session)
        {
        }

        [Association(@"CategoriasReferencesImpuestos")]
        public Impuesto Impuesto
        {
            get { return _f; }
            set { SetPropertyValue("Impuesto", ref _f, value); }
        }

        [Size(10)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(200)]
        [Index(1)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        public int Orden
        {
            get { return fOrden; }
            set { SetPropertyValue<int>("Orden", ref fOrden, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}