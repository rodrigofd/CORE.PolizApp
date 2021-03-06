using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
//using FDIT.Core.Sistema;

namespace FDIT.Core.Personas
{
  [Persistent( @"personas.RelacionTipoGrupo" )]
  [System.ComponentModel.DisplayName( "Tipo de relaci�n por grupo" )]

  [DefaultClassOptions]
public class RelacionTipoGrupo : BasicObject
  {
    private RelacionTipo fRelacionTipo;
    private bool fUniversal;

    public RelacionTipoGrupo( Session session ) : base( session )
    {
    }

    [Browsable( false )]
    //[Association( @"RelacionesTiposGruposReferencesRelacionesTipos" )]
    public RelacionTipo RelacionTipo
    {
      get { return fRelacionTipo; }
      set { SetPropertyValue( "RelacionTipo", ref fRelacionTipo, value ); }
    }

    public bool Universal
    {
      get { return fUniversal; }
      set { SetPropertyValue( "Universal", ref fUniversal, value ); }
    }

    public override void AfterConstruction( )
    {
      base.AfterConstruction( );
    }
  }
}