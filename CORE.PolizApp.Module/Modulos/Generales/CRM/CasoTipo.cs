using System.ComponentModel;
using System.Drawing;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using CORE.Modulos.Personas;
using CORE.Modulos.Sistema;

namespace CORE.Modulos.CRM
{
  [ Persistent( @"crm.CasoTipo" ) ]
  [ DefaultClassOptions ]
  [ DefaultProperty( "Nombre" ) ]
  [ System.ComponentModel.DisplayName( "Tipo de caso" ) ]
  public class CasoTipo : BasicObject, IObjetoPorGrupo
  {
    private CasoEstado fEstadoPredeterminado;
    private Grupo fGrupo;
    private string fNombre;
    private Image fTipoIcono;

    public CasoTipo(Session session)
      : base(session)
    {
    }

    [ ModelDefault( "ImageSizeMode", "Normal" ) ]
    [ Index( 0 ) ]
    [ VisibleInLookupListView( true ) ]
    [ ValueConverter( typeof( ImageValueConverter ) ) ]
    public Image TipoIcono
    {
      get { return fTipoIcono; }
      set { SetPropertyValue( "TipoIcono", ref fTipoIcono, value ); }
    }

    [ Index( 1 ) ]
    [ VisibleInLookupListView( true ) ]
    public string Nombre
    {
      get { return fNombre; }
      set { SetPropertyValue( "Nombre", ref fNombre, value ); }
    }

    public CasoEstado EstadoPredeterminado
    {
      get { return fEstadoPredeterminado; }
      set { SetPropertyValue( "EstadoPredeterminado", ref fEstadoPredeterminado, value ); }
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
