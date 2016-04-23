using CORE.General.Modulos.Sistema;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using CORE.Modulos.Personas;
using CORE.Modulos.Regionales;
using CORE.Modulos.Sistema;

namespace CORE.PolizApp.Seguridad
{
  [Persistent( @"seguridad.Usuario" )]
  [System.ComponentModel.DisplayName( "Usuario del sistema" )]
  public class Usuario : SecuritySystemUser
  {
    private PaisIdioma fCulturaPredeterminada;
    private Identificacion fEmailIdentificacion;
    private Empresa fEmpresaPredeterminada;
    private Idioma fIdiomaPredeterminado;
    private Persona fPersona;

    public Usuario( Session session ) :
      base( session )
    {
    }

    [ImmediatePostData]
    public Persona Persona
    {
      get { return fPersona; }
      set { SetPropertyValue( "Persona", ref fPersona, value ); }
    }

    [DataSourceProperty("Persona.Identificaciones")]
    [System.ComponentModel.DisplayName( "E-Mail primario del usuario" )]
    public Identificacion EmailIdentificacion
    {
      get { return fEmailIdentificacion; }
      set { SetPropertyValue( "EmailIdentificacion", ref fEmailIdentificacion, value ); }
    }

    [DataSourceProperty("EmpresasHabilitadas")]
    public Empresa EmpresaPredeterminada
    {
      get { return fEmpresaPredeterminada; }
      set { SetPropertyValue( "EmpresaPredeterminada", ref fEmpresaPredeterminada, value ); }
    }

    public Idioma IdiomaPredeterminado
    {
      get { return fIdiomaPredeterminado; }
      set { SetPropertyValue( "IdiomaPredeterminado", ref fIdiomaPredeterminado, value ); }
    }

    public PaisIdioma CulturaPredeterminada
    {
      get { return fCulturaPredeterminada; }
      set { SetPropertyValue( "CulturaPredeterminada", ref fCulturaPredeterminada, value ); }
    }

    [Association( @"seguridad.UsuarioEmpresa", typeof( Empresa ), UseAssociationNameAsIntermediateTableName = true )]
    public XPCollection< Empresa > EmpresasHabilitadas => GetCollection< Empresa >( "EmpresasHabilitadas" );
  }
}