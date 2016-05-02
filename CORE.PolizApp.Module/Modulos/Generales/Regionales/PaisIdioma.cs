using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.PaisIdioma")]
    [DefaultProperty("Codigo")]
    [System.ComponentModel.DisplayName(@"Idioma del país")]
    [DefaultClassOptions]
public class PaisIdioma : BasicObject
    {
        private Idioma _fIdioma;
        private int _fOrden;
        private Pais _fPais;

        public PaisIdioma(Session session) : base(session)
        {
        }

        [PersistentAlias("IIF(ISNULL(Idioma),'',Idioma.Codigo1) + '-' + IIF(ISNULL(Pais),'',Pais.Codigo)")]
        public string Codigo => (string) EvaluateAlias("Codigo");

        [Association(@"PaisesIdiomasReferencesPaises")]
        public Pais Pais
        {
            get { return _fPais; }
            set { SetPropertyValue("Pais", ref _fPais, value); }
        }

        public Idioma Idioma
        {
            get { return _fIdioma; }
            set { SetPropertyValue("Idioma", ref _fIdioma, value); }
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