using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.RelacionTipo")]
    [DefaultProperty("Descripcion")]
    [System.ComponentModel.DisplayName(@"Tipo de relación")]
    public class RelacionTipo : BasicObject
    {
        private string _fNombre;
        private string _fNombreInverso;

        public RelacionTipo(Session session) : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [PersistentAlias("Nombre + ' - (' + NombreInverso + ')'")]
        public string Descripcion => (string)EvaluateAlias("Descripcion");

        [Size(50)]
        [System.ComponentModel.DisplayName(@"Relación")]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Size(50)]
        [System.ComponentModel.DisplayName("Nombre (inverso)")]
        public string NombreInverso
        {
            get { return _fNombreInverso; }
            set { SetPropertyValue("NombreInverso", ref _fNombreInverso, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}