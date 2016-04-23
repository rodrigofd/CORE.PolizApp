using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Fondos
{
    public enum EspecieInstrumentoClase
    {
        Billete = 1,
        Cheque = 2,
        TarjetaCredito = 3,
        TarjetaDebito = 4,
        Retenciones = 5,
        Indice = 6,
        Titulo = 10,
        Documento = 11
    }

    [Persistent(@"fondos.EspecieInstrumento")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Instrumento de pago")]
    public class fondos_EspecieInstrumento : BasicObject
    {
        private EspecieInstrumentoClase fClase;
        private string fCodigo;
        private string fEspecieInstrumento;

        public fondos_EspecieInstrumento(Session session)
            : base(session)
        {
        }

        [Size(10)]
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
            get { return fEspecieInstrumento; }
            set { SetPropertyValue("Nombre", ref fEspecieInstrumento, value); }
        }

        [RuleRequiredField]
        public EspecieInstrumentoClase Clase
        {
            get { return fClase; }
            set { SetPropertyValue("Clase", ref fClase, value); }
        }

        [Association(@"EspeciesReferencesEspeciesInstrumentos", typeof (fondos_Especie))]
        public XPCollection<fondos_Especie> Especies
        {
            get { return GetCollection<fondos_Especie>("Especies"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}