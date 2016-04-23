using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using CORE.Modulos.Fondos;
using CORE.Modulos.Sistema;

namespace CORE.Modulos.Compras
{
  [Persistent( @"compras.ProveedorEmpresa" )]
  [System.ComponentModel.DisplayName( "Proveedores por empresas" )]
  public class ProveedorEmpresa : BasicObject, IObjetoPorEmpresa
  {
    private Empresa fEmpresa;
    private Proveedor fProveedor;
    private Cuenta fCuentaFondosPredeterminada;

    public ProveedorEmpresa( Session session ) : base( session )
    {
    }

    [Association( @"ProveedoresEmpresasReferencesProveedores" )]
    public Proveedor Proveedor
    {
      get { return fProveedor; }
      set { SetPropertyValue( "Proveedor", ref fProveedor, value ); }
    }

    [System.ComponentModel.DisplayName( "Cuenta de fondos predeterminada" )]
    [LookupEditorMode( LookupEditorMode.AllItems )]
    public Cuenta CuentaFondosPredeterminada
    {
      get { return fCuentaFondosPredeterminada; }
      set { SetPropertyValue( "CuentaFondosPredeterminada", ref fCuentaFondosPredeterminada, value ); }
    }

    [Browsable( false )]
    public Empresa Empresa
    {
      get { return fEmpresa; }
      set { SetPropertyValue( "Empresa", ref fEmpresa, value ); }
    }

    public override void AfterConstruction( )
    {
      base.AfterConstruction( );
    }
  }
}