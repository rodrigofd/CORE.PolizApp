namespace CORE.ES.Module.Modulos.Escribania.Controllers
{
    partial class FDIT_MigrarController 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null; 

        /// <summary> 
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FDIT_Migrar = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // FDIT_Migrar
            // 
            this.FDIT_Migrar.Caption = "Migrar";
            this.FDIT_Migrar.Category = "Tools";
            this.FDIT_Migrar.ConfirmationMessage = "Confirma la Migración ?";
            this.FDIT_Migrar.Id = "5158d8c3-ef17-4ad0-91dd-822c0344acd";
            this.FDIT_Migrar.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.FDIT_Migrar.ToolTip = "Migración";
            this.FDIT_Migrar.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.FDIT_MigrarAction_Execute);
            // 
            // FDIT_MigrarController
            // 
            this.Actions.Add(this.FDIT_Migrar);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction FDIT_Migrar;
    }
}
