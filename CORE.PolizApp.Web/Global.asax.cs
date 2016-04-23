using System;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security.Adapters;
using DevExpress.ExpressApp.Security.Xpo.Adapters;
using DevExpress.ExpressApp.Web;
using DevExpress.Web;

namespace CORE.PolizApp.Web
{
    public class Global : HttpApplication
    {
        public Global()
        {
            InitializeComponent();
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            IsGrantedAdapter.Enable(XPOSecurityAdapterHelper.GetXpoCachedRequestSecurityAdapters());
            ASPxWebControl.CallbackError += Application_Error;
#if EASYTEST
            DevExpress.ExpressApp.Web.TestScripts.TestScriptsManager.EasyTestEnabled = true;
#endif
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            WebApplication.SetInstance(Session, new FMAspNetApplication());
            WebApplication.Instance.SwitchToNewStyle();
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
            {
                WebApplication.Instance.ConnectionString =
                    ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
#if EASYTEST
            if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
                WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
            }
#endif
            if (Debugger.IsAttached &&
                WebApplication.Instance.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema)
            {
                WebApplication.Instance.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            }
            WebApplication.Instance.Setup();
            WebApplication.Instance.Start();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            ErrorHandling.Instance.ProcessApplicationError();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            WebApplication.LogOff(Session);
            WebApplication.DisposeInstance(Session);
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        #region Web Form Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }

        #endregion
    }
}