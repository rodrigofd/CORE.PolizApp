using System.ComponentModel;
using CORE.ES.Module.Modulos.Escribania;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Impuestos
{
    [Persistent(@"impuestos.Categoria")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Categorías")]
    public class impuestos_Categoria : BasicObject
    {
        private string fCodigo;
        //private int fCodigoAfip;
        //private int fIdCategoria; 
        private impuestos_Impuesto fImpuesto;
        private string fNombre;

        private int fOrden;

        public impuestos_Categoria(Session session)
            : base(session)
        {
        }

        [Association(@"CategoriasReferencesImpuestos")]
        public impuestos_Impuesto Impuesto
        {
            get { return fImpuesto; }
            set { SetPropertyValue("Impuesto", ref fImpuesto, value); }
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