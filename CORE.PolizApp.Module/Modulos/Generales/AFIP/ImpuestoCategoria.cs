using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Xpo;

namespace CORE.General.Modulos.AFIP
{
    [Persistent(@"afip.ImpuestoCategoria")]
    //[DefaultClassOptions]
    [DefaultProperty("CategoriaDeIva")]
    [System.ComponentModel.DisplayName(@"Categorías de impuestos AFIP")]
    public class afip_ImpuestoCategoria : BasicObject
    {
        private string fCategoriaDeIva;
        private int fCodigo;

        public afip_ImpuestoCategoria(Session session)
            : base(session)
        {
        }

        public int Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue<int>("Codigo", ref fCodigo, value); }
        }

        [Size(200)]
        public string CategoriaDeIva
        {
            get { return fCategoriaDeIva; }
            set { SetPropertyValue("CategoriaDeIva", ref fCategoriaDeIva, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}