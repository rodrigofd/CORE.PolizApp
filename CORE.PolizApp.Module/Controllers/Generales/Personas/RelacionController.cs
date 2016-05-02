using System;
using System.ComponentModel;
using CORE.PolizApp.Personas;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;

namespace CORE.PolizApp.Controllers.Personas
{
    /// <summary>
    ///     Controlador para la funcion de RELACIONAR una persona a otras, mediante un popup
    /// </summary>
    public class RelacionController : ViewController<ListView>
    {
        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private IContainer components;

        protected SimpleAction NuevaRelacionAction;

        public RelacionController()
        {
            InitializeComponent();
            RegisterActions(components);

            TargetObjectType = typeof(Relacion);
            TargetViewType = ViewType.ListView;
            TargetViewNesting = Nesting.Nested;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            UpdateActionState();
        }

        protected virtual void UpdateActionState()
        {
            var newObjectViewController = Frame.GetController<NewObjectViewController>();
            NuevaRelacionAction.Active["SecurityAllowNewByPermissions"] = newObjectViewController.NewObjectAction.Active["SecurityAllowNewByPermissions"];
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        private void nuevaRelacionAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            e.ShowViewParameters.CreatedView = Application.CreateListView(ObjectSpace, typeof(Persona), false);
            e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
            e.ShowViewParameters.Context = TemplateContext.LookupWindow;

            var dialogController = Application.CreateController<DialogController>();
            dialogController.SaveOnAccept = false;
            dialogController.WindowTemplateChanged += dialogController_WindowTemplateChanged;
            dialogController.Accepting += dialogController_Accepting;
            e.ShowViewParameters.Controllers.Add(dialogController);
        }

        protected virtual void dialogController_WindowTemplateChanged(object sender, EventArgs e)
        {
            var window = ((WindowController)sender).Window;
            var template = window.Template;

            var lookup = template as ILookupPopupFrameTemplate;
            if (lookup == null) return;

            lookup.IsSearchEnabled = true;
        }

        private void dialogController_Accepting(object sender, DialogControllerAcceptingEventArgs e)
        {
            var selectedPersonas = e.AcceptActionArgs.SelectedObjects;
            var originante = this.GetMasterObject<Persona>();

            foreach (Persona selectedPersona in selectedPersonas)
            {
                var nuevoVinculo = ObjectSpace.CreateObject<Relacion>();
                nuevoVinculo.PersonaVinculante = originante;
                nuevoVinculo.PersonaVinculado = selectedPersona;
                nuevoVinculo.RelacionTipo = null;

                View.CollectionSource.Add(nuevoVinculo);
            }
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                components?.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.NuevaRelacionAction = new SimpleAction(this.components);
            // 
            // nuevoVinculoAction
            // 
            this.NuevaRelacionAction.Caption = "Relacionar";
            this.NuevaRelacionAction.Category = "RecordEdit";
            this.NuevaRelacionAction.ConfirmationMessage = null;
            this.NuevaRelacionAction.Id = "nuevaRelacionAction";
            this.NuevaRelacionAction.ImageName = "MenuBar_Link";
            this.NuevaRelacionAction.Shortcut = null;
            this.NuevaRelacionAction.Tag = null;
            this.NuevaRelacionAction.TargetObjectsCriteria = null;
            this.NuevaRelacionAction.TargetViewId = null;
            this.NuevaRelacionAction.ToolTip = null;
            this.NuevaRelacionAction.TypeOfView = null;
            this.NuevaRelacionAction.Execute += new SimpleActionExecuteEventHandler(this.nuevaRelacionAction_Execute);
        }

        #endregion
    }
}