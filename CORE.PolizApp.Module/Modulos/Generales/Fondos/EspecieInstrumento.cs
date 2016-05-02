using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.EspecieInstrumento")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Instrumento de pago")]
    [DefaultClassOptions]
public class EspecieInstrumento : BasicObject
    {
        private EspecieInstrumentoClase _fClase;
        private string _fCodigo;
        private string _fEspecieInstrumento;

        public EspecieInstrumento(Session session)
            : base(session)
        {
        }

        [Size(10)]
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
            get { return _fEspecieInstrumento; }
            set { SetPropertyValue("Nombre", ref _fEspecieInstrumento, value); }
        }

        [RuleRequiredField]
        public EspecieInstrumentoClase Clase
        {
            get { return _fClase; }
            set { SetPropertyValue("Clase", ref _fClase, value); }
        }

        [Association(@"EspeciesReferencesEspeciesInstrumentos", typeof (Especie))]
        public XPCollection<Especie> Especies => GetCollection<Especie>("Especies");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}