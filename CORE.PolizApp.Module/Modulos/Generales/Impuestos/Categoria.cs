using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Impuestos
{
    [Persistent(@"impuestos.Categoria")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Categorías")]
    [DefaultClassOptions]
public class Categoria : BasicObject
    {
        private string _fCodigo;
        //private int fCodigoAfip;
        //private int fIdCategoria; 
        private Impuesto _f;
        private string _fNombre;

        private int _fOrden;

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
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(200)]
        [Index(1)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}