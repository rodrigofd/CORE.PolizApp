using System;
using CORE.PolizApp.Seguridad;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl;

namespace CORE.PolizApp.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
        }

        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();

            var administrativeRole = ObjectSpace.FindObject<Rol>(new BinaryOperator("Name", "Administradores"));
            if (administrativeRole == null)
            {
                administrativeRole = ObjectSpace.CreateObject<Rol>();
                administrativeRole.Name = "Administradores";
                administrativeRole.IsAdministrative = true;
            }

            const string adminName = "admin";

            var administratorUser = ObjectSpace.FindObject<Usuario>(new BinaryOperator("UserName", adminName));
            if (administratorUser == null)
            {
                administratorUser = ObjectSpace.CreateObject<Usuario>();
                administratorUser.UserName = adminName;
                administratorUser.IsActive = true;
                administratorUser.SetPassword("$");
                administratorUser.Roles.Add(administrativeRole);
            }

            ObjectSpace.CommitChanges(); //This line persists created object(s).

            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}
            /*
            var sampleUser = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "Invitado"));
            if (sampleUser == null)
            {
                sampleUser = ObjectSpace.CreateObject<SecuritySystemUser>();
                sampleUser.UserName = "Invitado";
                sampleUser.SetPassword("");
            }
            SecuritySystemRole defaultRole = CreateDefaultRole();
            sampleUser.Roles.Add(defaultRole);

            var userAdmin = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "Adminstrador"));
            if (userAdmin == null)
            {
                userAdmin = ObjectSpace.CreateObject<SecuritySystemUser>();
                userAdmin.UserName = "Adminstrador";
                // Set a password if the standard authentication type is used
                userAdmin.SetPassword("");
            }
            // If a role with the Administrators name doesn't exist in the database, create this role
            var adminRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Administradores"));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                adminRole.Name = "Administradores";
            }
            adminRole.IsAdministrative = true;
            userAdmin.Roles.Add(adminRole);
            ObjectSpace.CommitChanges(); //This line persists created object(s).
            */
        }

        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }

        private SecuritySystemRole CreateDefaultRole()
        {
            var defaultRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Default"));
            if (defaultRole == null)
            {
                defaultRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                defaultRole.Name = "Default";

                defaultRole.AddObjectAccessPermission<SecuritySystemUser>("[Oid] = CurrentUserId()",
                    SecurityOperations.ReadOnlyAccess);
                defaultRole.AddMemberAccessPermission<SecuritySystemUser>("ChangePasswordOnFirstLogon",
                    SecurityOperations.Write, "[Oid] = CurrentUserId()");
                defaultRole.AddMemberAccessPermission<SecuritySystemUser>("StoredPassword", SecurityOperations.Write,
                    "[Oid] = CurrentUserId()");
                defaultRole.SetTypePermissionsRecursively<SecuritySystemRole>(SecurityOperations.Read,
                    SecuritySystemModifier.Allow);
                defaultRole.SetTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess,
                    SecuritySystemModifier.Allow);
                defaultRole.SetTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess,
                    SecuritySystemModifier.Allow);
            }
            return defaultRole;
        }
    }
}