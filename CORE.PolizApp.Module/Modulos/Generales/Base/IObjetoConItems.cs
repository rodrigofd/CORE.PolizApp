using System.ComponentModel;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Base
{
    /// <summary>
    ///     Define un objeto contenedor, que posee una colecci�n de 'hijos' de un tipo determinado (agregados)
    /// </summary>
    /// <typeparam name="TItems">Tipo de objeto hijo</typeparam>
    public interface IObjetoConItems<TItems>
    {
        [Browsable(false)]
        XPCollection<TItems> Items { get; }
    }
}