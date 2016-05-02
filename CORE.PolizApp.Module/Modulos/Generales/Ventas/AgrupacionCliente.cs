using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.Modulos.Ventas
{
  [Persistent( @"ventas.AgrupacionCliente" )]
  [DefaultClassOptions]
  [DefaultProperty( "Nombre" )]
  [System.ComponentModel.DisplayName( "Agrupación de clientes" )]
  [DefaultClassOptions]
public class AgrupacionCliente : BaseObject
  {
    private string fNombre;

    public AgrupacionCliente( Session session ) : base( session )
    {
    }

    public string Nombre
    {
      get { return fNombre; }
      set { SetPropertyValue( "Nombre", ref fNombre, value ); }
    }

    [Association( @"ClientesReferencesAgrupacionesClientes", typeof( Cliente ) )]
    public XPCollection< Cliente > Clientes
    {
      get { return GetCollection< Cliente >( "Clientes" ); }
    }

    public override void AfterConstruction( )
    {
      base.AfterConstruction( );
    }
  }
}