using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using CORE.Modulos.Sistema;

namespace CORE.Modulos.CRM
{
  [ Persistent( @"crm.ActividadEstado" ) ]
  [ DefaultClassOptions ]
  [ DefaultProperty( "Nombre" ) ]
  [ System.ComponentModel.DisplayName( "Estados de actividades" ) ]
  public class ActividadEstado : BasicObject, IObjetoPorGrupo
  {
    private Grupo fGrupo;
    private string fNombre;
    private int? fPorcentajePredeterminado;

    public ActividadEstado( Session session ) : base( session )
    {
    }

    public string Nombre
    {
      get { return fNombre; }
      set { SetPropertyValue( "Nombre", ref fNombre, value ); }
    }

    public int? PorcentajePredeterminado
    {
      get { return fPorcentajePredeterminado; }
      set { SetPropertyValue( "PorcentajePredeterminado", ref fPorcentajePredeterminado, value ); }
    }

    [ Browsable( false ) ]
    public Grupo Grupo
    {
      get { return fGrupo; }
      set { SetPropertyValue( "Grupo", ref fGrupo, value ); }
    }

    public override void AfterConstruction( )
    {
      base.AfterConstruction( );
    }
  }
}
