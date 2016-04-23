using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Base
{
    [Appearance("DetailViewBoldRule", AppearanceItemType = "ViewItem", TargetItems = "*", FontStyle = FontStyle.Bold, Context = "DetailView", Priority = 0)]
    [ImageName("information")]
    [NonPersistent]
    [System.ComponentModel.DisplayName("Preferencias")]
    public class IdentificadoresBase<T> : XPLiteObject where T : XPLiteObject
    {
        private int fEmpresa;

        public IdentificadoresBase(Session session)
            : base(session)
        {
        }

        [Key]
        [Browsable(false)]
        public int Empresa
        {
            get { return fEmpresa; }
            set { SetPropertyValue<int>("Empresa", ref fEmpresa, value); }
        }

        public static T GetInstance(IObjectSpace objectSpace)
        {
            return GetInstance(((XPObjectSpace)objectSpace).Session);
        }
        /*
            public static T GetInstance( Session session )
            {
              return GetInstance( session, CoreAppLogonParameters.Instance.EmpresaActualId );
            }
        */
        public static T GetInstance(Session session, int idEmpresa)
        {
            var col = session.GetObjectByKey<T>(idEmpresa);
            if (col != null)
                return col;
            col = (T)Activator.CreateInstance(typeof(T), session);
            col.SetMemberValue("Empresa", idEmpresa);
            col.Save();

            return col;
        }
    }
}
