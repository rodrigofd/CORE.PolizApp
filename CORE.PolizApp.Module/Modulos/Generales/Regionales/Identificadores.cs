//using DevExpress.Xpo;
//using CORE.General.Modulos.Util;

using CORE.General.Modulos.Sistema;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Regionales
{
    [Persistent(@"regionales.Identificadores")]
    [System.ComponentModel.DisplayName(@"Preferencias regionales")]
    public class regionales_Identificadores : BasicObject //IdentificadoresBase<Identificadores>
    {
        private regionales_Idioma fIdiomaPredeterminado;
        private regionales_Pais fPaisPredeterminado;

        public regionales_Identificadores(Session session) : base(session)
        {
        }

        public regionales_Pais PaisPredeterminado
        {
            get { return fPaisPredeterminado; }
            set { SetPropertyValue("PaisPredeterminado", ref fPaisPredeterminado, value); }
        }

        public regionales_Idioma IdiomaPredeterminado
        {
            get { return fIdiomaPredeterminado; }
            set { SetPropertyValue("IdiomaPredeterminado", ref fIdiomaPredeterminado, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}