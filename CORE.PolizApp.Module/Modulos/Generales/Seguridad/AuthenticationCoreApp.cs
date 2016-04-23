using System;
using System.Collections.Generic;
using System.Diagnostics;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Utils;

namespace CORE.PolizApp.Seguridad
{
  public interface ISupportResetLogonParameters
  {
    void Reset( );
  }

  public class AuthenticationCoreApp : AuthenticationBase, IAuthenticationStandard
  {
    private CoreAppLogonParameters logonParameters;

    public AuthenticationCoreApp( )
    {
      logonParameters = new CoreAppLogonParameters( );
    }

    private bool autoLogin
    {
      get { return false || Debugger.IsAttached; }
    }

    public override bool AskLogonParametersViaUI
    {
      get { return !autoLogin; }
    }

    public override object LogonParameters
    {
      get { return logonParameters; }
    }

    public override bool IsLogoffEnabled
    {
      get { return true; }
    }

    public override void Logoff( )
    {
      base.Logoff( );
      logonParameters = new CoreAppLogonParameters( );
    }

    public override void ClearSecuredLogonParameters( )
    {
      logonParameters.Password = "";
      base.ClearSecuredLogonParameters( );
    }

    public override object Authenticate( IObjectSpace objectSpace )
    {
      Usuario usuario;

      if( autoLogin )
      {
        usuario = objectSpace.FindObject< Usuario >( new BinaryOperator( "UserName", "admin" ) );

        logonParameters.ObjectSpace = objectSpace;
        logonParameters.LoginUserName = usuario.UserName;
        logonParameters.LoginGrupoCodigo = "FDIT";
        logonParameters.LoginEmpresa = usuario.EmpresaPredeterminada;
      }
      else
      {
        if( logonParameters.UsuarioActual( ) == null )
        {
          throw new Exception( CaptionHelper.GetLocalizedText( "Security", "UsuarioNotNull" ) );
        }

        if( logonParameters.GrupoActual( ) == null )
        {
          throw new Exception( CaptionHelper.GetLocalizedText( "Security", "GrupoNotNull" ) );
        }

        if( logonParameters.EmpresaActual( ) == null )
        {
          throw new Exception( CaptionHelper.GetLocalizedText( "Security", "EmpresaNotNull" ) );
        }

        if( !logonParameters.UsuarioActual( ).ComparePassword( logonParameters.Password ) )
        {
          throw new AuthenticationException( logonParameters.UsuarioActual( ).UserName,
                                             SecurityExceptionLocalizer.GetExceptionMessage( SecurityExceptionId.PasswordsAreDifferent ) );
        }

        usuario = objectSpace.GetObjectByKey< Usuario >( logonParameters.UsuarioActualId );
      }

      return usuario;
    }

    public override IList< Type > GetBusinessClasses( )
    {
      return new[ ] { typeof( CoreAppLogonParameters ) };
    }
  }
}
