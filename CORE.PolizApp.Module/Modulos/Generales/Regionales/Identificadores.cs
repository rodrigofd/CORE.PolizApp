using CORE.PolizApp.Sistema;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Identificadores")]
    [System.ComponentModel.DisplayName(@"Preferencias regionales")]
    [DefaultClassOptions]
public class Identificadores : IdentificadoresBase<Identificadores>
    {
        private Idioma _idiomaPredeterminado;
        private Pais _paisPredeterminado;

        public Identificadores(Session session) : base(session)
        {
        }

        public Pais PaisPredeterminado
        {
            get { return _paisPredeterminado; }
            set { SetPropertyValue("PaisPredeterminado", ref _paisPredeterminado, value); }
        }

        public Idioma IdiomaPredeterminado
        {
            get { return _idiomaPredeterminado; }
            set { SetPropertyValue("IdiomaPredeterminado", ref _idiomaPredeterminado, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}