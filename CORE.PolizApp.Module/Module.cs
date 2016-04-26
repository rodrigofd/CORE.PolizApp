using System;
using System.Collections.Generic;
using CORE.PolizApp.Seguridad;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using Updater = CORE.PolizApp.DatabaseUpdate.Updater;

namespace CORE.PolizApp.Module
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class Module : ModuleBase
    {
        public Module()
        {
            InitializeComponent();
            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new Updater(objectSpace, versionFromDB);
            return new[] {updater};
        }

        public override void Setup(XafApplication application)
        {
            base.Setup(application);

            application.CreateCustomLogonWindowObjectSpace += 
                (sender, args) => { args.ObjectSpace = ((CoreLogonParameters)args.LogonParameters).ObjectSpace = application.CreateObjectSpace(); };

        }

        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);

            foreach (var type in XafTypesInfo.Instance.PersistentTypes)
                ModelNodesGeneratorSettings.SetIdPrefix(type.Type, type.FullName);
        }
    }
}