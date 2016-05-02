using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using CORE.PolizApp.Sistema;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Controllers.Sistema
{
    public class VinculosController : ViewController<ListView>
    {
        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private IContainer components;

        protected SingleChoiceAction NuevoVinculoAction;

        public VinculosController()
        {
            InitializeComponent();
            RegisterActions(components);

            TargetObjectType = typeof (Vinculo);
            TargetViewType = ViewType.ListView;
            TargetViewNesting = Nesting.Nested;
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            NuevoVinculoAction.Items.Clear();
            foreach (ITypeInfo type in XafTypesInfo.Instance.PersistentTypes.OrderBy(info => info.Name))
            {
                if (type.FindAttribute<DefaultClassOptionsAttribute>() == null) continue;

                string desc = type.Name;
                var displayNameAttr = type.FindAttribute<DisplayNameAttribute>();
                if (displayNameAttr != null) desc = displayNameAttr.DisplayName;

                NuevoVinculoAction.Items.Add(new ChoiceActionItem(desc, type.Type));
            }

            UpdateActionState();
        }

        protected virtual void UpdateActionState()
        {
            var newObjectViewController = Frame.GetController<NewObjectViewController>();
            NuevoVinculoAction.Active["SecurityAllowNewByPermissions"] =
                newObjectViewController.NewObjectAction.Active["SecurityAllowNewByPermissions"];
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        private void nuevoVinculoAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var objectType = (Type) e.SelectedChoiceActionItem.Data;
            e.ShowViewParameters.CreatedView = Application.CreateListView(ObjectSpace, objectType, false);

            e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
            e.ShowViewParameters.Context = TemplateContext.LookupWindow;

            var dc = Application.CreateController<DialogController>();
            dc.SaveOnAccept = false;
            dc.WindowTemplateChanged += dialogController_WindowTemplateChanged;
            dc.Accepting += DialogController_Accepting;
            e.ShowViewParameters.Controllers.Add(dc);
        }

        protected virtual void dialogController_WindowTemplateChanged(object sender, EventArgs e)
        {
            Window window = ((WindowController) sender).Window;
            IWindowTemplate template = window.Template;

            if (template == null) return;

            ((ILookupPopupFrameTemplate) template).IsSearchEnabled = true;
        }

        private void DialogController_Accepting(object sender, DialogControllerAcceptingEventArgs e)
        {
            IList selectedObjects = e.AcceptActionArgs.SelectedObjects;
            var originante = (BasicObject) ((PropertyCollectionSource) View.CollectionSource).MasterObject;

            foreach (BasicObject selectedObject in selectedObjects)
            {
                var nuevoVinculo = ObjectSpace.CreateObject<Vinculo>();
                nuevoVinculo.Originante = originante;
                nuevoVinculo.Destinatario = selectedObject;

                View.CollectionSource.Add(nuevoVinculo);
            }
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
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
            this.NuevoVinculoAction = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // nuevoVinculoAction
            // 
            this.NuevoVinculoAction.Caption = "Vincular con";
            this.NuevoVinculoAction.Category = "RecordEdit";
            this.NuevoVinculoAction.ConfirmationMessage = null;
            this.NuevoVinculoAction.Id = "nuevoVinculoAction";
            this.NuevoVinculoAction.ImageName = "MenuBar_Link";
            this.NuevoVinculoAction.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.NuevoVinculoAction.Shortcut = null;
            this.NuevoVinculoAction.Tag = null;
            this.NuevoVinculoAction.TargetObjectsCriteria = null;
            this.NuevoVinculoAction.TargetViewId = null;
            this.NuevoVinculoAction.ToolTip = null;
            this.NuevoVinculoAction.TypeOfView = null;
            this.NuevoVinculoAction.Execute +=
                new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.nuevoVinculoAction_Execute);
        }

        #endregion
    }
}