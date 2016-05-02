using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo.DB;
using System.Windows.Forms;

namespace CORE.ES.Module.Modulos.Escribania.Controllers
{
    // For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
    public partial class FditMigrarController : ViewController
    {
        public FditMigrarController()
        {
            InitializeComponent();
            RegisterActions(components);
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void FDIT_MigrarAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var os = (XPObjectSpace) ObjectSpace;

            SelectedData sd = os.Session.ExecuteSproc("fdit.spMigrador_FM");

            MessageBox.Show("Fin Migración", "Resultado");
        }
    }
}