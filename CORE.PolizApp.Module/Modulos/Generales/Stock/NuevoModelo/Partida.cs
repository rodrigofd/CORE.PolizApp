using System;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;
using CORE.Modulos.Regionales;

namespace CORE.Modulos.Stock
{
  [ DefaultClassOptions ]
  [ NavigationItem( "Stock" ) ]
  [ System.ComponentModel.DisplayName( "Partida" ) ]
  [ Persistent( @"stock.Partida" ) ]
  [DefaultClassOptions]
public class Partida : BasicObject
  {
    private string fPartidaAduana;
    private string fNotas;
    private DateTime fPartidaFecha;
    private DateTime fPartidaFechaVencimiento;
    private Pais fPartidaPaisOrigen;
    private bool fPartidaImportada;

    private string fPartidaNumero;
    private string fPartidaNumeroDespacho;

    public Partida( Session session ) : base( session )
    {
    }

    [ Size( 50 ) ]
    public string PartidaNumero
    {
      get { return fPartidaNumero; }
      set { SetPropertyValue( "PartidaNumero", ref fPartidaNumero, value ); }
    }

    public DateTime PartidaFecha
    {
      get { return fPartidaFecha; }
      set { SetPropertyValue< DateTime >( "PartidaFecha", ref fPartidaFecha, value ); }
    }

    public bool PartidaImportada
    {
      get { return fPartidaImportada; }
      set { SetPropertyValue( "PartidaImportada", ref fPartidaImportada, value ); }
    }

    [ Size( 50 ) ]
    public string PartidaNumeroDespacho
    {
      get { return fPartidaNumeroDespacho; }
      set { SetPropertyValue( "PartidaNumeroDespacho", ref fPartidaNumeroDespacho, value ); }
    }

    public Pais PartidaPaisOrigen
    {
      get { return fPartidaPaisOrigen; }
      set { SetPropertyValue( "PartidaPaisOrigen", ref fPartidaPaisOrigen, value ); }
    }

    [ Size( 50 ) ]
    public string PartidaAduana
    {
      get { return fPartidaAduana; }
      set { SetPropertyValue( "PartidaAduana", ref fPartidaAduana, value ); }
    }

    public DateTime PartidaFechaVencimiento
    {
      get { return fPartidaFechaVencimiento; }
      set { SetPropertyValue< DateTime >( "PartidaFechaVencimiento", ref fPartidaFechaVencimiento, value ); }
    }

    [ Size( SizeAttribute.Unlimited ) ]
    public string Notas
    {
      get { return fNotas; }
      set { SetPropertyValue( "Notas", ref fNotas, value ); }
    }

    [ Association( @"Articulos_SeriesReferencesPartidas", typeof( ArticuloSerie ) ) ]
    public XPCollection< ArticuloSerie > ArticulosSeries
    {
      get { return GetCollection<ArticuloSerie>( "ArticulosSeries" ); }
    }
  }
}
