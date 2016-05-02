using System.ComponentModel;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp
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