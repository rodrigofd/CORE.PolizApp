using System;
using System.Collections;
using CORE.PolizApp.Fondos;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Xpo.DB;

namespace CORE.PolizApp.Controllers.Fondos
{
    public class ValorDepositoController : ViewController
    {
        private DetailView _popupDetailView;

        public ValorDepositoController()
        {
            //InitializeComponent();
            //RegisterActions(components);
            var showPopupAction = new PopupWindowShowAction(
                this,
                "ValorDepositoController",
                PredefinedCategory.View
                )
            {
                Caption = "Deposito",
                TargetViewId = "fondos_Valor_ListView_ADepositar",
                ActionMeaning = ActionMeaning.Unknown
            };

            showPopupAction.CustomizePopupWindowParams += popupWindowShowAction_CustomizePopupWindowParams;
            showPopupAction.Execute += popupWindowShowAction_Execute;
        }

        private void popupWindowShowAction_CustomizePopupWindowParams(object sender,
            CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objSpace = e.Application.CreateObjectSpace();
            e.View = e.Application.CreateDetailView(objSpace, "fondos_ValorDeposito_DetailView", false);
            var detailView = (DetailView) e.View;
            detailView.CurrentObject = e.View.ObjectSpace.CreateObject<ValorDeposito>();
            _popupDetailView = detailView;
        }

        private void popupWindowShowAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            // sample code when OK button is pressed

            var popupDetailWinObj = (ValorDeposito) _popupDetailView.CurrentObject;
            //var xos = View.ObjectSpace.GetObject(escribania_LibroRequerimiento)Oid);

            //var LibroRequerimiento = PopupDetailWinObj..GetParentObject(escribania_LibroRequerimiento_escribania_LibroRequerimientoActa_ListView)..LibroRequerimiento.Oid;
            //var LibroRequerimiento = PopupDetailWinObj.LibroRequerimiento.Oid;
            //var serie = PopupDetailWinObj.Serie;
            //var numero = Convert.ToInt32(PopupDetailWinObj.Numero);

            //var os = (XPObjectSpace)ObjectSpace;
            //determinar nombre de usuario
            //var usuario = SecuritySystem.CurrentUser as DevExpress.ExpressApp.Security.Strategy.SecuritySystemUser;

            //for (var i = numero; i < numero + 200; i++)
            //{
            // os.Session.ExecuteScalar(string.Format("INSERT INTO escribania.LibroRequerimientoActa (LibroRequerimiento, Serie, Numero, Acta) VALUES ({0}, UPPER('{1}'), {2}, '{3}')", LibroRequerimiento, serie, i, i - numero + 1));        
            //}

            View.ObjectSpace.Refresh();

/////////////
            IList valoresSeleccionados = View.SelectedObjects;

            if (valoresSeleccionados.Count < 1) return;

            int BoletaDepositoNumero = popupDetailWinObj.Numero;
            int CuentaADepositar = popupDetailWinObj.CuentaADepositar.Oid;

            var os = (XPObjectSpace) ObjectSpace;

            foreach (Valor i in valoresSeleccionados)
            {
                try
                {
                    //Actualizar
                    SelectedData sd = os.Session.ExecuteSproc("fondos.spValorADepositar", i.Oid, CuentaADepositar,
                        BoletaDepositoNumero);
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }

            View.ObjectSpace.Refresh();
            //os.Refresh();
        }
    }
}