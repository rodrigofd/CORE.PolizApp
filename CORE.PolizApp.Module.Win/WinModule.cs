﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl;

namespace CORE.PolizApp.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class WinModule : ModuleBase
    {
        public WinModule()
        {
            InitializeComponent();
        }

        private void Application_CreateCustomModelDifferenceStore(object sender,
            CreateCustomModelDifferenceStoreEventArgs e)
        {
#if !DEBUG
    //e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), true, "Win");
    //e.Handled = true;
		#endif
        }

        private void Application_CreateCustomUserModelDifferenceStore(object sender,
            CreateCustomModelDifferenceStoreEventArgs e)
        {
            e.Store = new ModelDifferenceDbStore((XafApplication) sender, typeof (ModelDifference), false, "Win");
            e.Handled = true;
        }

        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            return ModuleUpdater.EmptyModuleUpdaters;
        }

        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            application.CreateCustomModelDifferenceStore += Application_CreateCustomModelDifferenceStore;
            application.CreateCustomUserModelDifferenceStore += Application_CreateCustomUserModelDifferenceStore;
            // Manage various aspects of the application UI and behavior at the module level.
        }
    }
}