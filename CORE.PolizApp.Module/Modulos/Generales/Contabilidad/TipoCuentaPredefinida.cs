using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace FDIT.Core.Contabilidad
{
  [Persistent( @"contabilidad.TipoCuentaPredefinida" )]
  [System.ComponentModel.DisplayName( "Tipos de Cuentas Predefinidas" )]
  [DefaultClassOptions]
public class TipoCuentaPredefinida : BasicObject
  {
    private string fNombre;

    public TipoCuentaPredefinida( Session session ) : base( session )
    {
    }

    public string Nombre
    {
      get { return fNombre; }
      set { SetPropertyValue( "Nombre", ref fNombre, value ); }
    }

    public override void AfterConstruction( )
    {
      base.AfterConstruction( );
    }
  }
}