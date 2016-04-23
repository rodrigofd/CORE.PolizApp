using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DisplayNameAttribute = System.ComponentModel.DisplayNameAttribute;

namespace CORE.General.Modulos.Personas
{
    [ImageName("user-worker")]
    [NonPersistent]
    [System.ComponentModel.DisplayName(@"Rol de persona")]
    public class personas_Rol : BasicObject
    {
        private personas_Persona fPersona;

        public personas_Rol(Session session)
            : base(session)
        {
        }

        [VisibleInDetailView(false)]
        public string TipoRol
        {
            get
            {
                return ClassInfo.HasAttribute(typeof (DisplayNameAttribute))
                    ? ((DisplayNameAttribute) ClassInfo.GetAttributeInfo(typeof (DisplayNameAttribute))).DisplayName
                    : ClassInfo.FullName;
            }
        }

        //[ExpandObjectMembers(ExpandObjectMembers.InDetailView)]
        [ImmediatePostData]
        [VisibleInListView(true)]
        public personas_Persona Persona
        {
            get { return fPersona; }
            set { SetPropertyValue("Persona", ref fPersona, value); }
        }
    }
}