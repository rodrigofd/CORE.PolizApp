using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Personas
{
    public enum personas_TipoPersona
    {
        [ImageName("user")] Fisica = 1,

        [ImageName("building")] Juridica = 2,

        [ImageName("global_telecom")] Virtual = 3,
    }
}