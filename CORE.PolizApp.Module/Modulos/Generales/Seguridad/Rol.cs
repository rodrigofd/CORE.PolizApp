using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Seguridad
{
    [Persistent(@"seguridad.Rol")]
    [System.ComponentModel.DisplayName("Rol del sistema")]
    [DefaultClassOptions]
public class Rol : SecuritySystemRole
    {
        public Rol(Session session) : base(session)
        {
        }
    }
}