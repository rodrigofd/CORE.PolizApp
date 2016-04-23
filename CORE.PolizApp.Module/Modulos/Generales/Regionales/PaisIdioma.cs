using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Regionales
{
    [Persistent(@"regionales.PaisIdioma")]
    [DefaultProperty("Codigo")]
    [System.ComponentModel.DisplayName(@"Idioma del país")]
    public class regionales_PaisIdioma : BasicObject
    {
        private regionales_Idioma fIdioma;
        private int fOrden;
        private regionales_Pais fPais;

        public regionales_PaisIdioma(Session session) : base(session)
        {
        }

        [PersistentAlias("IIF(ISNULL(Idioma),'',Idioma.Codigo1) + '-' + IIF(ISNULL(Pais),'',Pais.Codigo)")]
        public string Codigo
        {
            get { return (string) EvaluateAlias("Codigo"); }
        }

        [Association(@"PaisesIdiomasReferencesPaises")]
        public regionales_Pais Pais
        {
            get { return fPais; }
            set { SetPropertyValue("Pais", ref fPais, value); }
        }

        public regionales_Idioma Idioma
        {
            get { return fIdioma; }
            set { SetPropertyValue("Idioma", ref fIdioma, value); }
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