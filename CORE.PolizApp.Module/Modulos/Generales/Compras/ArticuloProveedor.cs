using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using CORE.Modulos.Stock;
using CORE.Modulos.Sistema;

namespace CORE.Modulos.Compras
{
  [ Persistent( @"compras.ArticuloProveedor" ) ]
  [ DefaultProperty( "Nombre" ) ]
  [ System.ComponentModel.DisplayName( "Art. seg�n proveedor" ) ]
  [DefaultClassOptions]
public class ArticuloProveedor : BasicObject
  {
    private Articulo fArticulo;
    private string fCodigo;
    private Proveedor fProveedor;

    public ArticuloProveedor( Session session )
      : base( session )
    {
    }

    [ System.ComponentModel.DisplayName( "Art�culo" ) ]
    public Articulo Articulo
    {
      get { return fArticulo; }
      set { SetPropertyValue( "Articulo", ref fArticulo, value ); }
    }

    [ Association( @"ArticuloProveedorReferencesProveedores" ) ]
    [ System.ComponentModel.DisplayName( "Proveedor" ) ]
    public Proveedor Proveedor
    {
      get { return fProveedor; }
      set { SetPropertyValue( "Proveedor", ref fProveedor, value ); }
    }

    [ Size( 30 ) ]
    [ System.ComponentModel.DisplayName( "C�d. por proveedor" ) ]
    [ Index( 0 ) ]
    public string Codigo
    {
      get { return fCodigo; }
      set { SetPropertyValue( "Codigo", ref fCodigo, value ); }
    }

    public override void AfterConstruction( )
    {
      base.AfterConstruction( );
    }
  }
}
