using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Xpo;

namespace CORE.PolizApp.Seguridad
{
    [Persistent(@"seguridad.Rol")]
    [System.ComponentModel.DisplayName("Rol del sistema")]
    public class Rol : SecuritySystemRole
    {
        public Rol(Session session) :
            base(session)
        {
        }
    }
}