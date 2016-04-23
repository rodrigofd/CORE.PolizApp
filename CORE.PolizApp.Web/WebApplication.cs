using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web;
using CORE.PolizApp.Module.Web;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.AuditTrail;
using DevExpress.ExpressApp.Chart;
using DevExpress.ExpressApp.Chart.Web;
using DevExpress.ExpressApp.CloneObject;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.FileAttachments.Web;
using DevExpress.ExpressApp.HtmlPropertyEditor.Web;
using DevExpress.ExpressApp.Objects;
using DevExpress.ExpressApp.PivotChart;
using DevExpress.ExpressApp.PivotChart.Web;
using DevExpress.ExpressApp.PivotGrid;
using DevExpress.ExpressApp.PivotGrid.Web;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.ReportsV2.Web;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Validation;
using DevExpress.ExpressApp.Validation.Web;
using DevExpress.ExpressApp.ViewVariantsModule;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace CORE.PolizApp.Web
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWebWebApplicationMembersTopicAll.aspx
    public class FMAspNetApplication : WebApplication
    {
        private AuditTrailModule auditTrailModule;
        private AuthenticationStandard authenticationStandard1;
        private ChartAspNetModule chartAspNetModule;
        private ChartModule chartModule;
        private CloneObjectModule cloneObjectModule;
        private ConditionalAppearanceModule conditionalAppearanceModule;
        private FileAttachmentsAspNetModule fileAttachmentsAspNetModule;
        private HtmlPropertyEditorAspNetModule htmlPropertyEditorAspNetModule;
        private SystemModule module1;
        private SystemAspNetModule module2;
        private PolizApp.Module.Module module3;
        private WebModule module4;
        private BusinessClassLibraryCustomizationModule objectsModule;
        private PivotChartAspNetModule pivotChartAspNetModule;
        private PivotChartModuleBase pivotChartModuleBase;
        private PivotGridAspNetModule pivotGridAspNetModule;
        private PivotGridModule pivotGridModule;
        private ReportsAspNetModuleV2 reportsAspNetModuleV2;
        private ReportsModuleV2 reportsModuleV2;
        private SecurityModule securityModule1;
        private SecurityStrategyComplex securityStrategyComplex1;
        private ValidationAspNetModule validationAspNetModule;
        private ValidationModule validationModule;
        private ViewVariantsModule viewVariantsModule;

        public FMAspNetApplication()
        {
            InitializeComponent();
        }

        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            CreateXPObjectSpaceProvider(args.ConnectionString, args);
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }

        private void CreateXPObjectSpaceProvider(string connectionString, CreateCustomObjectSpaceProviderEventArgs e)
        {
            HttpApplicationState application = (HttpContext.Current != null) ? HttpContext.Current.Application : null;
            IXpoDataStoreProvider dataStoreProvider = null;
            if (application != null && application["DataStoreProvider"] != null)
            {
                dataStoreProvider = application["DataStoreProvider"] as IXpoDataStoreProvider;
                e.ObjectSpaceProvider = new XPObjectSpaceProvider(dataStoreProvider, true);
            }
            else
            {
                if (!String.IsNullOrEmpty(connectionString))
                {
                    connectionString = XpoDefault.GetConnectionPoolString(connectionString);
                    dataStoreProvider = new ConnectionStringDataStoreProvider(connectionString, true);
                }
                else if (e.Connection != null)
                {
                    dataStoreProvider = new ConnectionDataStoreProvider(e.Connection);
                }
                if (application != null)
                {
                    application["DataStoreProvider"] = dataStoreProvider;
                }
                e.ObjectSpaceProvider = new XPObjectSpaceProvider(dataStoreProvider, true);
            }
        }

        private void FMAspNetApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e)
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
                string message =
                    "The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application.\r\n" +
                    "This error occurred  because the automatic database update was disabled when the application was started without debugging.\r\n" +
                    "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " +
                    "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " +
                    "or manually create a database using the 'DBUpdater' tool.\r\n" +
                    "Anyway, refer to the following help topics for more detailed information:\r\n" +
                    "'Update Application and Database Versions' at http://help.devexpress.com/#Xaf/CustomDocument2795\r\n" +
                    "'Database Security References' at http://help.devexpress.com/#Xaf/CustomDocument3237\r\n" +
                    "If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/";

                if (e.CompatibilityError != null && e.CompatibilityError.Exception != null)
                {
                    message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
                }
                throw new InvalidOperationException(message);
            }
#endif
        }

        private void InitializeComponent()
        {
            module1 = new SystemModule();
            module2 = new SystemAspNetModule();
            module3 = new PolizApp.Module.Module();
            module4 = new WebModule();
            securityModule1 = new SecurityModule();
            securityStrategyComplex1 = new SecurityStrategyComplex();
            authenticationStandard1 = new AuthenticationStandard();
            auditTrailModule = new AuditTrailModule();
            objectsModule = new BusinessClassLibraryCustomizationModule();
            chartModule = new ChartModule();
            chartAspNetModule = new ChartAspNetModule();
            cloneObjectModule = new CloneObjectModule();
            conditionalAppearanceModule = new ConditionalAppearanceModule();
            fileAttachmentsAspNetModule = new FileAttachmentsAspNetModule();
            htmlPropertyEditorAspNetModule = new HtmlPropertyEditorAspNetModule();
            pivotChartModuleBase = new PivotChartModuleBase();
            pivotChartAspNetModule = new PivotChartAspNetModule();
            pivotGridModule = new PivotGridModule();
            pivotGridAspNetModule = new PivotGridAspNetModule();
            reportsModuleV2 = new ReportsModuleV2();
            reportsAspNetModuleV2 = new ReportsAspNetModuleV2();
            validationModule = new ValidationModule();
            validationAspNetModule = new ValidationAspNetModule();
            viewVariantsModule = new ViewVariantsModule();
            ((ISupportInitialize) (this)).BeginInit();
            // 
            // securityStrategyComplex1
            // 
            securityStrategyComplex1.Authentication = authenticationStandard1;
            securityStrategyComplex1.RoleType = typeof (SecuritySystemRole);
            securityStrategyComplex1.UserType = typeof (SecuritySystemUser);
            // 
            // securityModule1
            // 
            securityModule1.UserType = typeof (SecuritySystemUser);
            // 
            // authenticationStandard1
            // 
            authenticationStandard1.LogonParametersType = typeof (AuthenticationStandardLogonParameters);
            //
            // auditTrailModule
            //
            auditTrailModule.AuditDataItemPersistentType = typeof (AuditDataItemPersistent);
            //
            // pivotChartModuleBase
            //
            pivotChartModuleBase.ShowAdditionalNavigation = true;
            //
            // reportsModuleV2
            //
            reportsModuleV2.EnableInplaceReports = true;
            reportsModuleV2.ReportDataType = typeof (ReportDataV2);
            reportsModuleV2.ShowAdditionalNavigation = true;
            //
            // reportsAspNetModuleV2
            //
            reportsAspNetModuleV2.ShowFormatSpecificExportActions = true;
            reportsAspNetModuleV2.DefaultPreviewFormat = ReportOutputType.Pdf;
            reportsAspNetModuleV2.ReportViewerType = ReportViewerTypes.HTML5;
            reportsModuleV2.ReportStoreMode = ReportStoreModes.XML;
            //
            // viewVariantsModule
            //
            viewVariantsModule.ShowAdditionalNavigation = true;
            // 
            // FMAspNetApplication
            // 
            ApplicationName = "CORE.PolizApp";
            LinkNewObjectToParentImmediately = false;
            CheckCompatibilityType = CheckCompatibilityType.DatabaseSchema;
            Modules.Add(module1);
            Modules.Add(module2);
            Modules.Add(module3);
            Modules.Add(module4);
            Modules.Add(securityModule1);
            Security = securityStrategyComplex1;
            Modules.Add(auditTrailModule);
            Modules.Add(objectsModule);
            Modules.Add(chartModule);
            Modules.Add(chartAspNetModule);
            Modules.Add(cloneObjectModule);
            Modules.Add(conditionalAppearanceModule);
            Modules.Add(fileAttachmentsAspNetModule);
            Modules.Add(htmlPropertyEditorAspNetModule);
            Modules.Add(pivotChartModuleBase);
            Modules.Add(pivotChartAspNetModule);
            Modules.Add(pivotGridModule);
            Modules.Add(pivotGridAspNetModule);
            Modules.Add(reportsModuleV2);
            Modules.Add(reportsAspNetModuleV2);
            Modules.Add(validationModule);
            Modules.Add(validationAspNetModule);
            Modules.Add(viewVariantsModule);
            DatabaseVersionMismatch += FMAspNetApplication_DatabaseVersionMismatch;
            ((ISupportInitialize) (this)).EndInit();
        }
    }
}