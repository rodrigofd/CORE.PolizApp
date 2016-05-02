using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using FDIT.Core.Sistema;

namespace CORE.Modulos.Fondos
{
  [Persistent( @"fondos.CuentaPredefinida" )]
  [DefaultClassOptions]
  [System.ComponentModel.DisplayName( "Cuentas Predefinidas" )]
  [DefaultClassOptions]
public class CuentaPredefinida : BasicObject, IObjetoPorEmpresa
  {
    private Empresa fEmpresa;
    private Cuenta fCuenta;

    private TipoCuentaPredefinida fTipoCuentaPredefinida;

    public CuentaPredefinida( Session session ) : base( session )
    {
    }

    public TipoCuentaPredefinida TipoCuentaPredefinida
    {
      get { return fTipoCuentaPredefinida; }
      set { SetPropertyValue( "TipoCuentaPredefinida", ref fTipoCuentaPredefinida, value ); }
    }

    public Cuenta Cuenta
    {
      get { return fCuenta; }
      set { SetPropertyValue( "Cuenta", ref fCuenta, value ); }
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