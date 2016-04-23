using DevExpress.Xpo;
using CORE.Modulos.Seguridad;
using CORE.Modulos.Sistema;

namespace CORE.Modulos.CRM
{
  [ Persistent( @"crm.CasoResponsable" ) ]
  [ System.ComponentModel.DisplayName( "Responsable del caso" ) ]
  public class CasoResponsable : BasicObject
  {
    private Caso fCaso;
    private bool fPrincipal;
    private Usuario fResponsable;

    public CasoResponsable(Session session)
      : base(session)
    {
    }

    [ Association ]
    public Caso Caso
    {
      get { return fCaso; }
      set { SetPropertyValue("Caso", ref fCaso, value); }
    }

    public Usuario Responsable
    {
      get { return fResponsable; }
      set { SetPropertyValue( "Responsable", ref fResponsable, value ); }
    }

    public bool Principal
    {
      get { return fPrincipal; }
      set { SetPropertyValue( "Principal", ref fPrincipal, value ); }
    }

    public override void AfterConstruction( )
    {
      base.AfterConstruction( );
    }
  }
}
