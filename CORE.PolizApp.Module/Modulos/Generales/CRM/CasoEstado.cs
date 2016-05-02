using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using CORE.Modulos.Sistema;

namespace CORE.Modulos.CRM
{
  [ Persistent( @"crm.CasoEstado" ) ]
  [ DefaultClassOptions ]
  [ DefaultProperty( "Nombre" ) ]
  [ System.ComponentModel.DisplayName( "Estado de caso" ) ]
  [DefaultClassOptions]
public class CasoEstado : BasicObject, IObjetoPorGrupo
  {
    private Grupo fGrupo;
    private string fNombre;
    private int? fPorcentajePredeterminado;

    public CasoEstado(Session session)
      : base(session)
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
