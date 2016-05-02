using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using CORE.Modulos.Sistema;

namespace CORE.Modulos.CRM
{
  [Persistent(@"crm.CasoPrioridad")]
  [ DefaultClassOptions ]
  [ DefaultProperty( "Nombre" ) ]
  [ System.ComponentModel.DisplayName( "Prioridad de caso" ) ]
  [DefaultClassOptions]
public class CasoPrioridad : BasicObject, IObjetoPorGrupo
  {
    private Grupo fGrupo;
    private string fNombre;

    public CasoPrioridad(Session session)
      : base(session)
    {
    }

    public string Nombre
    {
      get { return fNombre; }
      set { SetPropertyValue( "Nombre", ref fNombre, value ); }
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
