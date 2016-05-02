using System;

namespace CORE.PolizApp.Regionales
{
public class FiltroPorPaisAttribute : Attribute
    {
        public bool Filtrar = true;

        public FiltroPorPaisAttribute()
        {
        }

        public FiltroPorPaisAttribute(bool filtrar)
        {
            Filtrar = filtrar;
        }
    }
}