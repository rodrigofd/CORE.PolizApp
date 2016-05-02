using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.Modulos.Stock
{
  [ DefaultClassOptions ]
  [ NavigationItem( "Stock" ) ]
  [ DefaultProperty( "Nombre" ) ]
  [ System.ComponentModel.DisplayName( "Serie" ) ]
  [ Persistent( @"stock.Serie" ) ]
  [DefaultClassOptions]
public class Serie : BasicObject
  {
    private string fNombre;

    public Serie( Session session ) : base( session )
    {
    }

    [ Size( 50 ) ]
    public string Nombre
    {
      get { return fNombre; }
      set { SetPropertyValue( "Nombre", ref fNombre, value ); }
    }

    [ Association( @"Articulos_SeriesReferencesSeries", typeof( ArticuloSerie ) ) ]
    public XPCollection< ArticuloSerie > ArticulosSeries
    {
      get { return GetCollection<ArticuloSerie>( "ArticulosSeries" ); }
    }
  }
}
