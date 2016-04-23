namespace CORE.PolizApp.Module.Web {
    partial class WebModule {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            // 
            // WebModule
            // 
            this.RequiredModuleTypes.Add(typeof(CORE.PolizApp.Module.Module));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Chart.Web.ChartAspNetModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.FileAttachments.Web.FileAttachmentsAspNetModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.HtmlPropertyEditor.Web.HtmlPropertyEditorAspNetModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.PivotChart.Web.PivotChartAspNetModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.PivotGrid.Web.PivotGridAspNetModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule));
        }

        #endregion
    }
}