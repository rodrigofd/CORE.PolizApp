using System.ComponentModel;
using System.Drawing;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using CORE.Modulos.Personas;
using CORE.Modulos.Sistema;

namespace CORE.Modulos.CRM
{
  [ Persistent( @"crm.ActividadTipo" ) ]
  [ DefaultClassOptions ]
  [ DefaultProperty( "Nombre" ) ]
  [ System.ComponentModel.DisplayName( "Tipo de actividades" ) ]
  [DefaultClassOptions]
public class ActividadTipo : BasicObject, IObjetoPorGrupo
  {
    private Direccion? fDireccionPredeterminada;
    private int fDuracionPredeterminada;
    private ActividadEstado fEstadoPredeterminado;
    private Grupo fGrupo;
    private bool fInicioAutomatico;
    private string fNombre;
    private Image fTipoIcono;
    private bool fUsaBCC;
    private bool fUsaCC;

    public ActividadTipo( Session session ) : base( session )
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

    public ActividadEstado EstadoPredeterminado
    {
      get { return fEstadoPredeterminado; }
      set { SetPropertyValue( "EstadoPredeterminado", ref fEstadoPredeterminado, value ); }
    }

    public Direccion? DireccionPredeterminada
    {
      get { return fDireccionPredeterminada; }
      set { SetPropertyValue( "DireccionPredeterminada", ref fDireccionPredeterminada, value ); }
    }

    public bool UsaCC
    {
      get { return fUsaCC; }
      set { SetPropertyValue( "UsaCC", ref fUsaCC, value ); }
    }

    public bool UsaBCC
    {
      get { return fUsaBCC; }
      set { SetPropertyValue( "UsaBCC", ref fUsaBCC, value ); }
    }

    public bool InicioAutomatico
    {
      get { return fInicioAutomatico; }
      set { SetPropertyValue( "InicioAutomatico", ref fInicioAutomatico, value ); }
    }

    [ System.ComponentModel.DisplayName( "Duraci�n predet. (min.)" ) ]
    public int DuracionPredeterminada
    {
      get { return fDuracionPredeterminada; }
      set { SetPropertyValue< int >( "DuracionPredeterminada", ref fDuracionPredeterminada, value ); }
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
