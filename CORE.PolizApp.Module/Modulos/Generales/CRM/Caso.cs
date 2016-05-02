using System.ComponentModel;
using System.Drawing;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using CORE.Modulos.Seguridad;
using CORE.Modulos.Sistema;
using CORE.Modulos.Ventas;

namespace CORE.Modulos.CRM
{
  [ Persistent( @"crm.Caso" ) ]
  [ DefaultClassOptions ]
  [ System.ComponentModel.DisplayName( "Caso" ) ]
  [DefaultClassOptions]
public class Caso : BasicObject, IObjetoPorGrupo
  {
    private string fAsunto;
    private Cliente fCliente;
    private decimal fConsumo;
    private string fContenido;
    private Contrato fContrato;
    private ContratoItem fContratoItem;
    private CasoEstado fEstado;
    private int fEstadoPorcentaje;
    private Grupo fGrupo;
    private int fNivelSatisfaccion;

    private CasoPrioridad fPrioridad;
    private CasoTipo fTipo;

    public Caso( Session session )
      : base( session )
    {
    }

    [ VisibleInDetailView( true ) ]
    [ VisibleInListView( true ) ]
    public override Image Icono
    {
      get { return Tipo != null ? Tipo.TipoIcono : null; }
    }

    [ RuleRequiredField ]
    [ ImmediatePostData ]
    public CasoTipo Tipo
    {
      get { return fTipo; }
      set { SetPropertyValue( "Tipo", ref fTipo, value ); }
    }

    [ ImmediatePostData ]
    [ LookupEditorMode( LookupEditorMode.AllItems ) ]
    public Cliente Cliente
    {
      get { return fCliente; }
      set { SetPropertyValue( "Cliente", ref fCliente, value ); }
    }

    [ ImmediatePostData ]
    [ DataSourceProperty( "Cliente.Contratos" ) ]
    [ LookupEditorMode( LookupEditorMode.AllItems ) ]
    public Contrato Contrato
    {
      get { return fContrato; }
      set { SetPropertyValue( "Contrato", ref fContrato, value ); }
    }

    [ ImmediatePostData ]
    [ DataSourceProperty( "Contrato.Items" ) ]
    [ LookupEditorMode( LookupEditorMode.AllItems ) ]
    public ContratoItem ContratoItem
    {
      get { return fContratoItem; }
      set { SetPropertyValue( "ContratoItem", ref fContratoItem, value ); }
    }

    [ ModelDefault( "DisplayFormat", "{0:n4}" ) ]
    [ ModelDefault( "EditMask", "n4" ) ]
    [ ImmediatePostData ]
    public decimal Consumo
    {
      get { return fConsumo; }
      set { SetPropertyValue< decimal >( "Consumo", ref fConsumo, value ); }
    }

    [ RuleRequiredField ]
    public string Asunto
    {
      get { return fAsunto; }
      set { SetPropertyValue( "Asunto", ref fAsunto, value ); }
    }

    [ Size( SizeAttribute.Unlimited ) ]
    public string Contenido
    {
      get { return fContenido; }
      set { SetPropertyValue( "Contenido", ref fContenido, value ); }
    }

    [ RuleRequiredField ]
    [ ImmediatePostData ]
    public CasoEstado Estado
    {
      get { return fEstado; }
      set { SetPropertyValue( "Estado", ref fEstado, value ); }
    }

    [ RuleRequiredField ]
    [ ImmediatePostData ]
    public CasoPrioridad Prioridad
    {
      get { return fPrioridad; }
      set { SetPropertyValue( "Prioridad", ref fPrioridad, value ); }
    }

    [ RuleRequiredField ]
    [ ImmediatePostData ]
    [ RuleRange( DefaultContexts.Save, 0, 100, CustomMessageTemplate = "El valor debe ser un entero entre 0 y 100" ) ]
    public int EstadoPorcentaje
    {
      get { return fEstadoPorcentaje; }
      set { SetPropertyValue< int >( "EstadoPorcentaje", ref fEstadoPorcentaje, value ); }
    }

    [ RuleRange( DefaultContexts.Save, 1, 10, CustomMessageTemplate = "El valor debe ser un entero entre 1 y 10" ) ]
    public int NivelSatisfaccion
    {
      get { return fNivelSatisfaccion; }
      set { SetPropertyValue< int >( "NivelSatisfaccion", ref fNivelSatisfaccion, value ); }
    }

    [ Association ]
    public XPCollection< CasoResponsable > Responsables
    {
      get { return GetCollection< CasoResponsable >( "Responsables" ); }
    }

    [ Association ]
    public XPCollection< Actividad > ActividadesDelCaso
    {
      get { return GetCollection< Actividad >( "ActividadesDelCaso" ); }
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

      Responsables.Add( new CasoResponsable( Session ) { Responsable = CoreAppLogonParameters.Instance.UsuarioActual( Session ), Principal = true } );
    }
  }
}
