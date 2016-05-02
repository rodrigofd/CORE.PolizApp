using System;
using System.ComponentModel;
using CORE.ES.Module.Modulos.Escribania;
using CORE.PolizApp.Impuestos;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Gestion
{
    [Persistent(@"gestion.ComprobanteTipo")]
    //[DefaultClassOptions]
    [DefaultProperty("Descripcion")]
    [System.ComponentModel.DisplayName("Tipos de comprobantes")]
    [DefaultClassOptions]
public class ComprobanteTipo : BasicObject
    {
        private bool _fActivo;
        private bool _fAutomatico;
        private Categoria _fCategoriaDeIvaPredet;
        private string _fClase;
        private string _fCodigo;
        private int _fCopiasImpresion;
        private DebitoCredito _fDebitoCredito;
        private string _fDescripcionImpresion;
        private bool _fDiscriminaImpuestos;
        private bool _fGestionFinanciera;

        //private IdentificacionTipo fIdentificacionTipoPredet;
        private bool _fIncluyeIva;
        private bool _fIncluyePercepciones;
        private bool _fLibroIvaCompras;
        private bool _fLibroIvaVentas;
        //private ComprobanteTipoModulo fModulo;
        private string _fNombre;
        private int _fOrden;
        //private ComprobanteModeloItem fComprobanteModeloItemPrincipal;
        private bool _fStockEntrada;
        private bool _fStockSalida;
        private bool _fValorizado;
        private int _fAfipCodigo;

        public ComprobanteTipo(Session session) : base(session)
        {
        }

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [VisibleInLookupListView(false)]
        //[ PersistentAlias( "ISNULL('(' + Codigo + ') ' + Nombre, '****')" ) ] 
        [PersistentAlias("ISNULL(Codigo, Nombre)")]
        public string Descripcion => Convert.ToString(EvaluateAlias("Descripcion"));

        [Index(0)]
        [VisibleInLookupListView(true)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(200)]
        [Index(1)]
        [VisibleInLookupListView(true)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Size(1)]
        public string Clase
        {
            get { return _fClase; }
            set { SetPropertyValue("Clase", ref _fClase, value); }
        }

        public DebitoCredito DebitoCredito
        {
            get { return _fDebitoCredito; }
            set { SetPropertyValue("DebitoCredito", ref _fDebitoCredito, value); }
        }

        public bool DiscriminaImpuestos
        {
            get { return _fDiscriminaImpuestos; }
            set { SetPropertyValue("DiscriminaImpuestos", ref _fDiscriminaImpuestos, value); }
        }

        public bool Automatico
        {
            get { return _fAutomatico; }
            set { SetPropertyValue("Automatico", ref _fAutomatico, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }

        public bool LibroIvaCompras
        {
            get { return _fLibroIvaCompras; }
            set { SetPropertyValue("LibroIvaCompras", ref _fLibroIvaCompras, value); }
        }

        public bool LibroIvaVentas
        {
            get { return _fLibroIvaVentas; }
            set { SetPropertyValue("LibroIvaVentas", ref _fLibroIvaVentas, value); }
        }

        public int CopiasImpresion
        {
            get { return _fCopiasImpresion; }
            set { SetPropertyValue<int>("CopiasImpresion", ref _fCopiasImpresion, value); }
        }

        public Categoria CategoriaDeIvaPredet
        {
            get { return _fCategoriaDeIvaPredet; }
            set { SetPropertyValue("CategoriaDeIvaPredet", ref _fCategoriaDeIvaPredet, value); }
        }

        /*
        public IdentificacionTipo IdentificacionTipoPredet
        {
          get { return fIdentificacionTipoPredet; }
          set { SetPropertyValue( "IdentificacionTipoPredet", ref fIdentificacionTipoPredet, value ); }
        }
        */

        public bool Activo
        {
            get { return _fActivo; }
            set { SetPropertyValue("Activo", ref _fActivo, value); }
        }

        public bool IncluyeIva
        {
            get { return _fIncluyeIva; }
            set { SetPropertyValue("IncluyeIva", ref _fIncluyeIva, value); }
        }

        public bool IncluyePercepciones
        {
            get { return _fIncluyePercepciones; }
            set { SetPropertyValue("IncluyePercepciones", ref _fIncluyePercepciones, value); }
        }

        public bool GestionFinanciera
        {
            get { return _fGestionFinanciera; }
            set { SetPropertyValue("GestionFinanciera", ref _fGestionFinanciera, value); }
        }

        public bool StockEntrada
        {
            get { return _fStockEntrada; }
            set { SetPropertyValue("Entrada", ref _fStockEntrada, value); }
        }

        public bool StockSalida
        {
            get { return _fStockSalida; }
            set { SetPropertyValue("Salida", ref _fStockSalida, value); }
        }

        public bool Valorizado
        {
            get { return _fValorizado; }
            set { SetPropertyValue("Valorizado", ref _fValorizado, value); }
        }

        public string DescripcionImpresion
        {
            get { return _fDescripcionImpresion; }
            set { SetPropertyValue("DescripcionImpresion", ref _fDescripcionImpresion, value); }
        }

        public int AfipCodigo
        {
            get { return _fAfipCodigo; }
            set { SetPropertyValue<int>("AfipCodigo", ref _fAfipCodigo, value); }
        }

        /*
        [ Aggregated ]
        [ Association( @"ComprobantesTiposCategoriasReferencesComprobantesTipos", typeof( ComprobanteTipoCategoria ) ) ]
        public XPCollection< ComprobanteTipoCategoria > CategoriasValidas
        {
          get { return GetCollection< ComprobanteTipoCategoria >( "CategoriasValidas" ); }
        }

        [ Aggregated ]
        [ Association( @"ComprobantesTiposCategoriasReferencesIdentificacionesTipos" ) ]
        public XPCollection< ComprobantesTipoIdentificacionTipo > IdentificacionesTiposValidos
        {
          get { return GetCollection< ComprobantesTipoIdentificacionTipo >( "IdentificacionesTiposValidos" ); }
        }

        [ Association ]
        public XPCollection< Talonario > Talonarios
        {
          get { return GetCollection< Talonario >( "Talonarios" ); }
        }
        */

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
            DebitoCredito = DebitoCredito.Debito;
        }
    }
}