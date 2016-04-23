﻿using System;
using CORE.General.Modulos.Sistema;

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

    public interface IObjetoPorEmpresa
    {
        Empresa Empresa { get; set; }
    }
}