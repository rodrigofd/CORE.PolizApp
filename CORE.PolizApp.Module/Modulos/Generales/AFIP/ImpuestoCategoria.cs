using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.General.Modulos.AFIP
{
    [Persistent(@"afip.ImpuestoCategoria")]
    //[DefaultClassOptions]
    [DefaultProperty("CategoriaDeIva")]
    [System.ComponentModel.DisplayName(@"Categorías de impuestos AFIP")]
    [DefaultClassOptions]
public class AfipImpuestoCategoria : BasicObject
    {
        private string _fCategoriaDeIva;
        private int _fCodigo;

        public AfipImpuestoCategoria(Session session)
            : base(session)
        {
        }

        public int Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue<int>("Codigo", ref _fCodigo, value); }
        }

        [Size(200)]
        public string CategoriaDeIva
        {
            get { return _fCategoriaDeIva; }
            set { SetPropertyValue("CategoriaDeIva", ref _fCategoriaDeIva, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}