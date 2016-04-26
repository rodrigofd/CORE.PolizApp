using System;

namespace FDIT.Core.Sistema
{
    public class FiltroPorEmpresaAttribute : Attribute
    {
        public string CriteriaEmpresa;

        public FiltroPorEmpresaAttribute(string criteriaEmpresa)
        {
            CriteriaEmpresa = criteriaEmpresa;
        }
    }
}