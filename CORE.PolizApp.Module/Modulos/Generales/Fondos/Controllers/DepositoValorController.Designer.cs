using System;
using System.Security.Cryptography;
using CORE.General.Modulos.Fondos;
using DevExpress.ExpressApp.Xpo;
using System.Collections;

namespace CORE.ES.Module.Modulos.Fondos.Controllers
{
    partial class DepositoValorController
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
            this.parametrizedAction1 = new DevExpress.ExpressApp.Actions.ParametrizedAction(this.components);
            // 
            // parametrizedAction1
            // 
            this.parametrizedAction1.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept;
            this.parametrizedAction1.Caption = "Depositar";
            this.parametrizedAction1.Category = "Edit";
            this.parametrizedAction1.ConfirmationMessage = null;
            this.parametrizedAction1.Id = "37cbc666-0419-49fd-ae60-0aae67c4be4a";
            this.parametrizedAction1.ImageName = null;
            this.parametrizedAction1.NullValuePrompt = null;
            this.parametrizedAction1.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.parametrizedAction1.ShortCaption = null;
            this.parametrizedAction1.Shortcut = null;
            this.parametrizedAction1.Tag = null;
            this.parametrizedAction1.TargetObjectsCriteria = null;
            this.parametrizedAction1.TargetViewId = null;
            this.parametrizedAction1.ToolTip = "Ingresar Nro Boleta";
            this.parametrizedAction1.TypeOfView = null;
            this.parametrizedAction1.ValueType = typeof(System.Int32);
            this.parametrizedAction1.Execute += new DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventHandler(this.DepositoValor_Execute);
            // 
            // DepositoValorController
            // 
            this.TargetObjectType = typeof(FDIT.Core.Fondos.fondos_Valor);
            this.TargetViewId = "fondos_Valor_ListView_ADepositar";
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        private void DepositoValor_Execute(object sender, DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventArgs e)
        {
            var valoresSeleccionados = View.SelectedObjects;

            if (valoresSeleccionados.Count < 1) return;

            var os = (XPObjectSpace)ObjectSpace;
            var BoletaDepositoNumero = (int)e.ParameterCurrentValue;

            foreach (fondos_Valor i in valoresSeleccionados) 
            {
                try
                {
                    //Actualizar
                    var sd = os.Session.ExecuteSproc("fondos.spValorADepositar", i.Oid, BoletaDepositoNumero);
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }
            os.Refresh();

        }

        #endregion

        private DevExpress.ExpressApp.Actions.ParametrizedAction parametrizedAction1;
    }
}
