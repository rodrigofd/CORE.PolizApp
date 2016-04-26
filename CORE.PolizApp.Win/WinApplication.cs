using System;
using System.Diagnostics;
using System.Threading;
using CORE.PolizApp.Seguridad;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;

namespace CORE.PolizApp.Win
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWinWinApplicationMembersTopicAll.aspx
    public partial class WinApplication : DevExpress.ExpressApp.Win.WinApplication
    {
        public WinApplication()
        {
            InitializeComponent();
        }

        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(args.ConnectionString, args.Connection, false);
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }

        protected override IObjectSpace CreateLogonWindowObjectSpace(object logonParameters)
        {
            return ((CoreLogonParameters)logonParameters).ObjectSpace = CreateObjectSpace();
        }

        private void FMWindowsFormsApplication_CustomizeLanguagesList(object sender, CustomizeLanguagesListEventArgs e)
        {
            var userLanguageName = Thread.CurrentThread.CurrentUICulture.Name;
            if (userLanguageName != "en-US" && e.Languages.IndexOf(userLanguageName) == -1)
            {
                e.Languages.Add(userLanguageName);
            }
        }

        private void FMWindowsFormsApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e)
        {
#if EASYTEST
            e.Updater.Update();
            e.Handled = true;
#else
            if (Debugger.IsAttached)
            {
                e.Updater.Update();
                e.Handled = true;
            }
            else
            {
                throw new InvalidOperationException(
                    "The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application.\r\n" +
                    "This error occurred  because the automatic database update was disabled when the application was started without debugging.\r\n" +
                    "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " +
                    "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " +
                    "or manually create a database using the 'DBUpdater' tool.\r\n" +
                    "Anyway, refer to the 'Update Application and Database Versions' help topic at http://help.devexpress.com/#Xaf/CustomDocument2795 " +
                    "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/");
            }
#endif
        }
    }
}