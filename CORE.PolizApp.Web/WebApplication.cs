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
    public class FmAspNetApplication : WebApplication
    {
        private AuditTrailModule _auditTrailModule;
        private AuthenticationStandard _authenticationStandard1;
        private ChartAspNetModule _chartAspNetModule;
        private ChartModule _chartModule;
        private CloneObjectModule _cloneObjectModule;
        private ConditionalAppearanceModule _conditionalAppearanceModule;
        private FileAttachmentsAspNetModule _fileAttachmentsAspNetModule;
        private HtmlPropertyEditorAspNetModule _htmlPropertyEditorAspNetModule;
        private SystemModule _module1;
        private SystemAspNetModule _module2;
        private Module.Module _module3;
        private WebModule _module4;
        private BusinessClassLibraryCustomizationModule _objectsModule;
        private PivotChartAspNetModule _pivotChartAspNetModule;
        private PivotChartModuleBase _pivotChartModuleBase;
        private PivotGridAspNetModule _pivotGridAspNetModule;
        private PivotGridModule _pivotGridModule;
        private ReportsAspNetModuleV2 _reportsAspNetModuleV2;
        private ReportsModuleV2 _reportsModuleV2;
        private SecurityModule _securityModule1;
        private SecurityStrategyComplex _securityStrategyComplex1;
        private ValidationAspNetModule _validationAspNetModule;
        private ValidationModule _validationModule;
        private ViewVariantsModule _viewVariantsModule;

        public FmAspNetApplication()
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
            _module1 = new SystemModule();
            _module2 = new SystemAspNetModule();
            _module3 = new Module.Module();
            _module4 = new WebModule();
            _securityModule1 = new SecurityModule();
            _securityStrategyComplex1 = new SecurityStrategyComplex();
            _authenticationStandard1 = new AuthenticationStandard();
            _auditTrailModule = new AuditTrailModule();
            _objectsModule = new BusinessClassLibraryCustomizationModule();
            _chartModule = new ChartModule();
            _chartAspNetModule = new ChartAspNetModule();
            _cloneObjectModule = new CloneObjectModule();
            _conditionalAppearanceModule = new ConditionalAppearanceModule();
            _fileAttachmentsAspNetModule = new FileAttachmentsAspNetModule();
            _htmlPropertyEditorAspNetModule = new HtmlPropertyEditorAspNetModule();
            _pivotChartModuleBase = new PivotChartModuleBase();
            _pivotChartAspNetModule = new PivotChartAspNetModule();
            _pivotGridModule = new PivotGridModule();
            _pivotGridAspNetModule = new PivotGridAspNetModule();
            _reportsModuleV2 = new ReportsModuleV2();
            _reportsAspNetModuleV2 = new ReportsAspNetModuleV2();
            _validationModule = new ValidationModule();
            _validationAspNetModule = new ValidationAspNetModule();
            _viewVariantsModule = new ViewVariantsModule();
            ((ISupportInitialize) (this)).BeginInit();
            // 
            // securityStrategyComplex1
            // 
            _securityStrategyComplex1.Authentication = _authenticationStandard1;
            _securityStrategyComplex1.RoleType = typeof (SecuritySystemRole);
            _securityStrategyComplex1.UserType = typeof (SecuritySystemUser);
            // 
            // securityModule1
            // 
            _securityModule1.UserType = typeof (SecuritySystemUser);
            // 
            // authenticationStandard1
            // 
            _authenticationStandard1.LogonParametersType = typeof (AuthenticationStandardLogonParameters);
            //
            // auditTrailModule
            //
            _auditTrailModule.AuditDataItemPersistentType = typeof (AuditDataItemPersistent);
            //
            // pivotChartModuleBase
            //
            _pivotChartModuleBase.ShowAdditionalNavigation = true;
            //
            // reportsModuleV2
            //
            _reportsModuleV2.EnableInplaceReports = true;
            _reportsModuleV2.ReportDataType = typeof (ReportDataV2);
            _reportsModuleV2.ShowAdditionalNavigation = true;
            //
            // reportsAspNetModuleV2
            //
            _reportsAspNetModuleV2.ShowFormatSpecificExportActions = true;
            _reportsAspNetModuleV2.DefaultPreviewFormat = ReportOutputType.Pdf;
            _reportsAspNetModuleV2.ReportViewerType = ReportViewerTypes.HTML5;
            _reportsModuleV2.ReportStoreMode = ReportStoreModes.XML;
            //
            // viewVariantsModule
            //
            _viewVariantsModule.ShowAdditionalNavigation = true;
            // 
            // FMAspNetApplication
            // 
            ApplicationName = "CORE.PolizApp";
            LinkNewObjectToParentImmediately = false;
            CheckCompatibilityType = CheckCompatibilityType.DatabaseSchema;
            Modules.Add(_module1);
            Modules.Add(_module2);
            Modules.Add(_module3);
            Modules.Add(_module4);
            Modules.Add(_securityModule1);
            Security = _securityStrategyComplex1;
            Modules.Add(_auditTrailModule);
            Modules.Add(_objectsModule);
            Modules.Add(_chartModule);
            Modules.Add(_chartAspNetModule);
            Modules.Add(_cloneObjectModule);
            Modules.Add(_conditionalAppearanceModule);
            Modules.Add(_fileAttachmentsAspNetModule);
            Modules.Add(_htmlPropertyEditorAspNetModule);
            Modules.Add(_pivotChartModuleBase);
            Modules.Add(_pivotChartAspNetModule);
            Modules.Add(_pivotGridModule);
            Modules.Add(_pivotGridAspNetModule);
            Modules.Add(_reportsModuleV2);
            Modules.Add(_reportsAspNetModuleV2);
            Modules.Add(_validationModule);
            Modules.Add(_validationAspNetModule);
            Modules.Add(_viewVariantsModule);
            DatabaseVersionMismatch += FMAspNetApplication_DatabaseVersionMismatch;
            ((ISupportInitialize) (this)).EndInit();
        }
    }
}