using System;
using CORE.PolizApp.Impuestos;
using CORE.PolizApp.Personas;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using FDIT.Core.Sistema;
using CORE.PolizApp.Fondos;
using System.ComponentModel;
using DevExpress.ExpressApp.Model;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.Documento")]
    [DefaultProperty("Numero")]

    public class Documento : BasicObject, IObjetoPorEmpresa
    {
        //private string _faceptadaNotas;
        private DateTime _fAceptadaFecha;
        private string _fAceptadaHost;
        private string _fAceptadaUsuario;
        //private string _facuseDeReciboNotas;
        private DateTime _fAcuseReciboFecha;
        private string _fAcuseReciboHost;
        private string _fAcuseReciboUsuario;
        private decimal _fAdicionalFinanciero;
        private decimal _fAdicionalFinancieroTasa;
        //private string _fanuladaNotas;
        private DateTime _fAnuladaFecha;
        private string _fAnuladaHost;
        private string _fAnuladaUsuario;
        private Aseguradora _fAseguradora;
        private decimal _fCambio;
        //private string _fcargadaNotas;
        private DateTime _fCargadaFecha;
        private string _fCargadaHost;
        private string _fCargadaUsuario;
        private decimal _fComisionPremioTasa;
        private decimal _fComisionPremioTasaProductor;
        private decimal _fComisionPrimaTasa;
        private decimal _fComisionPrimaTasaProductor;
        //private int _fcomprobantesComprobantesIdComprobante;
        private decimal _fDerechoEmision;
        private decimal _fDerechoEmisionTasa;
        //private string _fdespachadaNotas;
        private DateTime _fDespachadaFecha;
        private string _fDespachadaHost;
        private string _fDespachadaUsuario;
        private DocumentoClase _clase;
        private DocumentoClaseTipo _fClaseTipo;
        private Documento _fDocumentoCotizacion;
        private Documento _fDocumentoPiloto;
        private Documento _fDocumentoPoliza;
        private Documento _fDocumentoRenueva;
        private DateTime _fEmitidaFecha;
        private Empresa _fEmpresa;
        private string _fEndosoNumero;
        //private string _fenviadaNotas;
        private DateTime _fEnviadaFecha;
        private string _fEnviadaHost;
        private string _fEnviadaUsuario;
        private Especie _fEspecie;
        private int _fFacturaCuotas;
        private FacturaPeriodicidad _fFacturaPeriodicidad;
        private string _fFacturaReferencia;
        private FacturaTipo _fFacturaTipo;
        private FormaPago _fFormaPago;
        private string _fFormaPagoDetalle;
        //private int _fidAceptadaUsuario;
        //private int _fidAcuseDeReciboUsuario;
        //private int _fidAnuladaUsuario;
        //private int _fidAseguradoraR;
        //private int _fidCargadaUsuario;
        //private int _fidDespachadaUsuario;
        //private int _fidDocumentoEstado;
        //private int _fidDocumentoPilotoRol;
        //private int _fidDocumentoTipo;
        //private int _fidEnviadaUsuario;
        //private int _fidNegocioLinea;
        //private int _fidPlanDePago;

        //private int _fidProductorR;
        //private int _fidRecepcionPropuestaUsuario;
        //private int _fidRegularizadaUsuario;
        //private int _fidTomadorR;
        //private int _fidValidadaUsuario;
        //private int _fidVentaTipo;
        private decimal _fImpuestosOtros;
        private decimal _fIva;
        private decimal _fIvaTasa;
        private string _fNotaAseguradora;
        private string _fNotaInterna;
        private string _fNotaTomador;
        private int _fNumero;
        //private decimal _fpagoAnticipoTasa;
        //private decimal _fpagoDescuentoImporte;
        //private decimal _fpagoDescuentoTasa;
        //private bool _fpedidoDeEmision;
        private string _fPolizaNumero;
        private decimal _fPremio;
        private decimal _fPrimaComisionable;
        private decimal _fPrimaGravada;
        private decimal _fPrimaNoGravada;
        private decimal _fPrimaPremioIndice;
        private AseguradoraProductor _fAseguradoraProductor;
        private Ramo _fRamo;
        private RamoTipo _fRamoTipo;
        private decimal _fRecargoAdministrativo;
        private decimal _fRecargoAdministrativoTasa;
        private DateTime _fRecepcionFecha;
        private string _fRecepcionHost;
        private string _fRecepcionUsuario;
        private DateTime _fRegularizadaFecha;
        private string _fRegularizadaHost;
        private string _fRegularizadaUsuario;
        private bool _fRenueva;
        private string _fRenuevaDetalle;
        private int _fsmartixId;
        private decimal _fSumaAsegurada;
        private decimal _fTasaRiesgo;
        private TasaRiesgoUm _fTasaRiesgoUm;
        private Persona _fTomador;
        private Categoria _fTomadorCategoriaIVA;
        private Direccion _fTomadorDireccion;
        private Identificacion _fTomadorIdentificacion;
        private DateTime _fValidadaFecha;
        private string _fValidadaHost;
        private string _fValidadaUsuario;
        private DateTime _fVigenciaFin;
        private DateTime _fVigenciaFinPoliza;
        private DateTime _fVigenciaInicio;

        //private bool _frecepcionPropuestaAceptada;
        //private string _frecepcionPropuestaNotas;
        //private string _fregularizadaNotas;
        //private string _fvalidadaNotas;
        //private int _fvigenciaDias;
        //private int _fvigenciaDiasAlVencimiento;
        //private int _fvigenciaMeses;

        public Documento(Session session) : base(session)
        {
        }

        [System.ComponentModel.DisplayName(@"Organizador")]
        public Empresa Empresa
        {
            get { return _fEmpresa; }
            set { SetPropertyValue("Empresa", ref _fEmpresa, value); }
        }

        [System.ComponentModel.DisplayName(@"Doc")]
        [ModelDefault("DisplayFormat", "{0:D}"), ModelDefault("EditMask", "D")]
        public int Numero
        {
            get { return _fNumero; }
            set { SetPropertyValue<int>("Numero", ref _fNumero, value); }
        }

        //[Association(@"DocumentoReferencesDocumento")]
        [System.ComponentModel.DisplayName(@"DocCotiz")]
        public Documento DocumentoCotizacion
        {
            get { return _fDocumentoCotizacion; }
            set { SetPropertyValue("DocumentoCotizacion", ref _fDocumentoCotizacion, value); }
        }

        //[Association(@"DocumentoReferencesDocumento1")]
        [System.ComponentModel.DisplayName(@"DocPol")]
        public Documento DocumentoPoliza
        {
            get { return _fDocumentoPoliza; }
            set { SetPropertyValue("DocumentoPoliza", ref _fDocumentoPoliza, value); }
        }

        //[Association(@"DocumentoReferencesDocumento2")]
        [System.ComponentModel.DisplayName(@"DocRenuA")]
        public Documento DocumentoRenueva
        {
            get { return _fDocumentoRenueva; }
            set { SetPropertyValue("DocumentoRenueva", ref _fDocumentoRenueva, value); }
        }

        //[Association(@"DocumentoReferencesDocumento3")]
        [System.ComponentModel.DisplayName(@"DocPil")]
        public Documento DocumentoPiloto
        {
            get { return _fDocumentoPiloto; }
            set { SetPropertyValue("DocumentoPiloto", ref _fDocumentoPiloto, value); }
        }

        //[Association(@"DocumentoReferencesDocumentoClase")]
        [Persistent("DocumentoClase")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public DocumentoClase Clase
        {
            get { return _clase; }
            set { SetPropertyValue("Clase", ref _clase, value); }
        }

        //[Association(@"DocumentoReferencesDocumentoClaseTipo")]
        [Persistent("DocumentoClaseTipo")]
        [DataSourceProperty("Clase.DocumentoClaseTipos")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"CTipo")]
        public DocumentoClaseTipo ClaseTipo
        {
            get { return _fClaseTipo; }
            set { SetPropertyValue("ClaseTipo", ref _fClaseTipo, value); }
        }

        //[Association(@"DocumentoReferencesAseguradora")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public Aseguradora Aseguradora
        {
            get { return _fAseguradora; }
            set { SetPropertyValue("Aseguradora", ref _fAseguradora, value); }
        }

        private decimal _fAseguradoraParticipacion;
        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"Part%")]
        public decimal AseguradoraParticipacion
        {
            get { return _fAseguradoraParticipacion; }
            set { SetPropertyValue<decimal>("AseguradoraParticipacion", ref _fAseguradoraParticipacion, value); }
        }

        //[Association(@"DocumentoReferencesAseguradoraProductor")]
        [VisibleInListView(false)]
        [System.ComponentModel.DisplayName(@"AseguradoraProductor")]
        [DataSourceProperty("Aseguradora.Productores")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public AseguradoraProductor AseguradoraProductor
        {
            get { return _fAseguradoraProductor; }
            set { SetPropertyValue("AseguradoraProductor", ref _fAseguradoraProductor, value); }
        }

        [VisibleInDetailView(false)]
        [System.ComponentModel.DisplayName(@"Productor")]
        [PersistentAlias("AseguradoraProductor.Productor")]
        public Persona ProductorPersona
        {
            get { return (Persona)(EvaluateAlias("ProductorPersona")); }
        }

        public Persona Tomador
        {
            get { return _fTomador; }
            set { SetPropertyValue("Tomador", ref _fTomador, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Tomador.Direcciones")]
        [System.ComponentModel.DisplayName(@"Dirección")]
        public Direccion TomadorDireccion
        {
            get { return _fTomadorDireccion; }
            set { SetPropertyValue<Direccion>("TomadorDireccion", ref _fTomadorDireccion, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Tomador.Identificaciones")]
        [System.ComponentModel.DisplayName(@"Identificación")]
        public Identificacion TomadorIdentificacion
        {
            get { return _fTomadorIdentificacion; }
            set { SetPropertyValue<Identificacion>("TomadorIdentificacion", ref _fTomadorIdentificacion, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"CatIVA")]
        public Categoria TomadorCategoriaIVA
        {
            get { return _fTomadorCategoriaIVA; }
            set { SetPropertyValue<Categoria>("TomadorCategoriaIVA", ref _fTomadorCategoriaIVA, value); }
        }

        //[Association(@"DocumentoReferencesRamo")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public Ramo Ramo
        {
            get { return _fRamo; }
            set { SetPropertyValue("Ramo", ref _fRamo, value); }
        }

        //[Association(@"DocumentoReferencesRamoTipo")]
        [DataSourceProperty("Ramo.RamoTipos")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"RTipo")]
        public RamoTipo RamoTipo
        {
            get { return _fRamoTipo; }
            set { SetPropertyValue("RamoTipo", ref _fRamoTipo, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"NotaAseg")]
        public string NotaAseguradora
        {
            get { return _fNotaAseguradora; }
            set { SetPropertyValue("NotaAseguradora", ref _fNotaAseguradora, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string NotaTomador
        {
            get { return _fNotaTomador; }
            set { SetPropertyValue("NotaTomador", ref _fNotaTomador, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string NotaInterna
        {
            get { return _fNotaInterna; }
            set { SetPropertyValue("NotaInterna", ref _fNotaInterna, value); }
        }

        [Size(50)]
        [System.ComponentModel.DisplayName(@"PolNro")]
        public string PolizaNumero
        {
            get { return _fPolizaNumero; }
            set { SetPropertyValue("PolizaNumero", ref _fPolizaNumero, value); }
        }

        [Size(50)]
        [System.ComponentModel.DisplayName(@"EndNro")]
        public string EndosoNumero
        {
            get { return _fEndosoNumero; }
            set { SetPropertyValue("EndosoNumero", ref _fEndosoNumero, value); }
        }

        public DateTime EmitidaFecha
        {
            get { return _fEmitidaFecha; }
            set { SetPropertyValue<DateTime>("EmitidaFecha", ref _fEmitidaFecha, value); }
        }

        public DateTime VigenciaInicio
        {
            get { return _fVigenciaInicio; }
            set { SetPropertyValue<DateTime>("VigenciaInicio", ref _fVigenciaInicio, value); }
        }

        public DateTime VigenciaFin
        {
            get { return _fVigenciaFin; }
            set { SetPropertyValue<DateTime>("VigenciaFin", ref _fVigenciaFin, value); }
        }

        public DateTime VigenciaFinPoliza
        {
            get { return _fVigenciaFinPoliza; }
            set { SetPropertyValue<DateTime>("VigenciaFinPoliza", ref _fVigenciaFinPoliza, value); }
        }

        public bool Renueva
        {
            get { return _fRenueva; }
            set { SetPropertyValue("Renueva", ref _fRenueva, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string RenuevaDetalle
        {
            get { return _fRenuevaDetalle; }
            set { SetPropertyValue("RenuevaDetalle", ref _fRenuevaDetalle, value); }
        }
        
        [DataSourceCriteria("[ExpresaMoneda] = true")]
        [System.ComponentModel.DisplayName(@"Mon")]
        public Especie Especie
        {
            get { return _fEspecie; }
            set { SetPropertyValue("Especie", ref _fEspecie, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n4}"), ModelDefault("EditMask", "n4")]
        public decimal Cambio
        {
            get { return _fCambio; }
            set { SetPropertyValue<decimal>("Cambio", ref _fCambio, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"Suma")]
        public decimal SumaAsegurada
        {
            get { return _fSumaAsegurada; }
            set { SetPropertyValue<decimal>("SumaAsegurada", ref _fSumaAsegurada, value); }
        }

        [Association(@"DocumentoReferencesTasaRiesgoUM")]
        [System.ComponentModel.DisplayName(@"TasaUM")]
        public TasaRiesgoUm TasaRiesgoUm
        {
            get { return _fTasaRiesgoUm; }
            set { SetPropertyValue("TasaRiesgoUM", ref _fTasaRiesgoUm, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n4}"), ModelDefault("EditMask", "n4")]
        [System.ComponentModel.DisplayName(@"Tasa")]
        public decimal TasaRiesgo
        {
            get { return _fTasaRiesgo; }
            set { SetPropertyValue<decimal>("TasaRiesgo", ref _fTasaRiesgo, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"Prima")]
        public decimal PrimaGravada
        {
            get { return _fPrimaGravada; }
            set { SetPropertyValue<decimal>("PrimaGravada", ref _fPrimaGravada, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"DerEmiTasa")]
        public decimal DerechoEmisionTasa
        {
            get { return _fDerechoEmisionTasa; }
            set { SetPropertyValue<decimal>("DerechoEmisionTasa", ref _fDerechoEmisionTasa, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"DerEmi")]
        public decimal DerechoEmision
        {
            get { return _fDerechoEmision; }
            set { SetPropertyValue<decimal>("DerechoEmision", ref _fDerechoEmision, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"RecAdmTasa")]
        public decimal RecargoAdministrativoTasa
        {
            get { return _fRecargoAdministrativoTasa; }
            set { SetPropertyValue<decimal>("RecargoAdministrativoTasa", ref _fRecargoAdministrativoTasa, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"RecAdm")]
        public decimal RecargoAdministrativo
        {
            get { return _fRecargoAdministrativo; }
            set { SetPropertyValue<decimal>("RecargoAdministrativo", ref _fRecargoAdministrativo, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"RecFinTasa")]
        public decimal AdicionalFinancieroTasa
        {
            get { return _fAdicionalFinancieroTasa; }
            set { SetPropertyValue<decimal>("AdicionalFinancieroTasa", ref _fAdicionalFinancieroTasa, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"RecFin")]
        public decimal AdicionalFinanciero
        {
            get { return _fAdicionalFinanciero; }
            set { SetPropertyValue<decimal>("AdicionalFinanciero", ref _fAdicionalFinanciero, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"IvaTasa")]
        public decimal IvaTasa
        {
            get { return _fIvaTasa; }
            set { SetPropertyValue<decimal>("IvaTasa", ref _fIvaTasa, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"Iva")]
        public decimal Iva
        {
            get { return _fIva; }
            set { SetPropertyValue<decimal>("Iva", ref _fIva, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"ImpOtros")]
        public decimal ImpuestosOtros
        {
            get { return _fImpuestosOtros; }
            set { SetPropertyValue<decimal>("ImpuestosOtros", ref _fImpuestosOtros, value); }
        }

        [Browsable(false)]
        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal PrimaNoGravada
        {
            get { return _fPrimaNoGravada; }
            set { SetPropertyValue<decimal>("PrimaNoGravada", ref _fPrimaNoGravada, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"PrimaCom")]
        public decimal PrimaComisionable
        {
            get { return _fPrimaComisionable; }
            set { SetPropertyValue<decimal>("PrimaComisionable", ref _fPrimaComisionable, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"Premio")]
        public decimal Premio
        {
            get { return _fPremio; }
            set { SetPropertyValue<decimal>("Premio", ref _fPremio, value); }
        }

        [Browsable(false)]
        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"IndCom")]
        public decimal PrimaPremioIndice
        {
            get { return _fPrimaPremioIndice; }
            set { SetPropertyValue<decimal>("PrimaPremioIndice", ref _fPrimaPremioIndice, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"ComPriTasa")]
        public decimal ComisionPrimaTasa
        {
            get { return _fComisionPrimaTasa; }
            set { SetPropertyValue<decimal>("ComisionPrimaTasa", ref _fComisionPrimaTasa, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"ComPreTasa")]
        public decimal ComisionPremioTasa
        {
            get { return _fComisionPremioTasa; }
            set { SetPropertyValue<decimal>("ComisionPremioTasa", ref _fComisionPremioTasa, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"ComPriProdTasa")]
        public decimal ComisionPrimaTasaProductor
        {
            get { return _fComisionPrimaTasaProductor; }
            set { SetPropertyValue<decimal>("ComisionPrimaTasaProductor", ref _fComisionPrimaTasaProductor, value); }
        }

        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        [System.ComponentModel.DisplayName(@"ComPreProdTasa")]
        public decimal ComisionPremioTasaProductor
        {
            get { return _fComisionPremioTasaProductor; }
            set { SetPropertyValue<decimal>("ComisionPremioTasaProductor", ref _fComisionPremioTasaProductor, value); }
        }

        //[Association(@"DocumentoReferencesFacturaTipo")]
        [System.ComponentModel.DisplayName(@"FacTipo")]
        public FacturaTipo FacturaTipo
        {
            get { return _fFacturaTipo; }
            set { SetPropertyValue("FacturaTipo", ref _fFacturaTipo, value); }
        }

        //[Association(@"DocumentoReferencesFacturaPeriodicidad")]
        [System.ComponentModel.DisplayName(@"FacPeri")]
        public FacturaPeriodicidad FacturaPeriodicidad
        {
            get { return _fFacturaPeriodicidad; }
            set { SetPropertyValue("FacturaPeriodicidad", ref _fFacturaPeriodicidad, value); }
        }

        [ModelDefault("DisplayFormat", "{0:D}"), ModelDefault("EditMask", "D")]
        [System.ComponentModel.DisplayName(@"FacCuotas")]
        public int FacturaCuotas
        {
            get { return _fFacturaCuotas; }
            set { SetPropertyValue<int>("FacturaCuotas", ref _fFacturaCuotas, value); }
        }

        [Size(50)]
        [System.ComponentModel.DisplayName(@"FacNro")]
        public string FacturaReferencia
        {
            get { return _fFacturaReferencia; }
            set { SetPropertyValue("FacturaReferencia", ref _fFacturaReferencia, value); }
        }

        //[Association(@"DocumentoReferencesFormaPago")]
        [System.ComponentModel.DisplayName(@"FormPago")]
        public FormaPago FormaPago
        {
            get { return _fFormaPago; }
            set { SetPropertyValue("FormaPago", ref _fFormaPago, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [System.ComponentModel.DisplayName(@"FormPagoDeta")]
        public string FormaPagoDetalle
        {
            get { return _fFormaPagoDetalle; }
            set { SetPropertyValue("FormaPagoDetalle", ref _fFormaPagoDetalle, value); }
        }

        [Browsable(false)]
        public int SmartixId
        {
            get { return _fsmartixId; }
            set { SetPropertyValue<int>("smartix_Id", ref _fsmartixId, value); }
        }

        public DateTime CargadaFecha
        {
            get { return _fCargadaFecha; }
            set { SetPropertyValue<DateTime>("CargadaFecha", ref _fCargadaFecha, value); }
        }

        public string CargadaUsuario
        {
            get { return _fCargadaUsuario; }
            set { SetPropertyValue("CargadaUsuario", ref _fCargadaUsuario, value); }
        }

        public string CargadaHost
        {
            get { return _fCargadaHost; }
            set { SetPropertyValue("CargadaHost", ref _fCargadaHost, value); }
        }

        public DateTime ValidadaFecha
        {
            get { return _fValidadaFecha; }
            set { SetPropertyValue<DateTime>("ValidadaFecha", ref _fValidadaFecha, value); }
        }

        public string ValidadaUsuario
        {
            get { return _fValidadaUsuario; }
            set { SetPropertyValue("ValidadaUsuario", ref _fValidadaUsuario, value); }
        }

        public string ValidadaHost
        {
            get { return _fValidadaHost; }
            set { SetPropertyValue("ValidadaHost", ref _fValidadaHost, value); }
        }

        public DateTime EnviadaFecha
        {
            get { return _fEnviadaFecha; }
            set { SetPropertyValue<DateTime>("EnviadaFecha", ref _fEnviadaFecha, value); }
        }

        public string EnviadaUsuario
        {
            get { return _fEnviadaUsuario; }
            set { SetPropertyValue("EnviadaUsuario", ref _fEnviadaUsuario, value); }
        }

        public string EnviadaHost
        {
            get { return _fEnviadaHost; }
            set { SetPropertyValue("EnviadaHost", ref _fEnviadaHost, value); }
        }

        public DateTime AcuseReciboFecha
        {
            get { return _fAcuseReciboFecha; }
            set { SetPropertyValue<DateTime>("AcuseReciboFecha", ref _fAcuseReciboFecha, value); }
        }

        public string AcuseReciboUsuario
        {
            get { return _fAcuseReciboUsuario; }
            set { SetPropertyValue("AcuseReciboUsuario", ref _fAcuseReciboUsuario, value); }
        }

        public string AcuseReciboHost
        {
            get { return _fAcuseReciboHost; }
            set { SetPropertyValue("AcuseReciboHost", ref _fAcuseReciboHost, value); }
        }

        public DateTime RecepcionFecha
        {
            get { return _fRecepcionFecha; }
            set { SetPropertyValue<DateTime>("RecepcionFecha", ref _fRecepcionFecha, value); }
        }

        public string RecepcionUsuario
        {
            get { return _fRecepcionUsuario; }
            set { SetPropertyValue("RecepcionUsuario", ref _fRecepcionUsuario, value); }
        }

        public string RecepcionHost
        {
            get { return _fRecepcionHost; }
            set { SetPropertyValue("RecepcionHost", ref _fRecepcionHost, value); }
        }

        public DateTime RegularizadaFecha
        {
            get { return _fRegularizadaFecha; }
            set { SetPropertyValue<DateTime>("RegularizadaFecha", ref _fRegularizadaFecha, value); }
        }

        public string RegularizadaUsuario
        {
            get { return _fRegularizadaUsuario; }
            set { SetPropertyValue("RegularizadaUsuario", ref _fRegularizadaUsuario, value); }
        }

        public string RegularizadaHost
        {
            get { return _fRegularizadaHost; }
            set { SetPropertyValue("RegularizadaHost", ref _fRegularizadaHost, value); }
        }

        public DateTime DespachadaFecha
        {
            get { return _fDespachadaFecha; }
            set { SetPropertyValue<DateTime>("DespachadaFecha", ref _fDespachadaFecha, value); }
        }

        public string DespachadaUsuario
        {
            get { return _fDespachadaUsuario; }
            set { SetPropertyValue("DespachadaUsuario", ref _fDespachadaUsuario, value); }
        }

        public string DespachadaHost
        {
            get { return _fDespachadaHost; }
            set { SetPropertyValue("DespachadaHost", ref _fDespachadaHost, value); }
        }

        public DateTime AceptadaFecha
        {
            get { return _fAceptadaFecha; }
            set { SetPropertyValue<DateTime>("AceptadaFecha", ref _fAceptadaFecha, value); }
        }

        public string AceptadaUsuario
        {
            get { return _fAceptadaUsuario; }
            set { SetPropertyValue("AceptadaUsuario", ref _fAceptadaUsuario, value); }
        }

        public string AceptadaHost
        {
            get { return _fAceptadaHost; }
            set { SetPropertyValue("AceptadaHost", ref _fAceptadaHost, value); }
        }

        public DateTime AnuladaFecha
        {
            get { return _fAnuladaFecha; }
            set { SetPropertyValue<DateTime>("AnuladaFecha", ref _fAnuladaFecha, value); }
        }

        public string AnuladaUsuario
        {
            get { return _fAnuladaUsuario; }
            set { SetPropertyValue("AnuladaUsuario", ref _fAnuladaUsuario, value); }
        }

        public string AnuladaHost
        {
            get { return _fAnuladaHost; }
            set { SetPropertyValue("AnuladaHost", ref _fAnuladaHost, value); }
        }
        /*
        public int IdProductorR
        {
            get { return _fidProductorR; }
            set { SetPropertyValue<int>("id_productor_r", ref _fidProductorR, value); }
        }

        public int IdAseguradoraR
        {
            get { return _fidAseguradoraR; }
            set { SetPropertyValue<int>("id_aseguradora_r", ref _fidAseguradoraR, value); }
        }

        public int IdTomadorR
        {
            get { return _fidTomadorR; }
            set { SetPropertyValue<int>("id_tomador_r", ref _fidTomadorR, value); }
        }

        public int IdDocumentoTipo
        {
            get { return _fidDocumentoTipo; }
            set { SetPropertyValue<int>("id_documento_tipo", ref _fidDocumentoTipo, value); }
        }

        public int IdDocumentoEstado
        {
            get { return _fidDocumentoEstado; }
            set { SetPropertyValue<int>("id_documento_estado", ref _fidDocumentoEstado, value); }
        }

        public bool PedidoDeEmision
        {
            get { return _fpedidoDeEmision; }
            set { SetPropertyValue("pedido_de_emision", ref _fpedidoDeEmision, value); }
        }

        public int IdVentaTipo
        {
            get { return _fidVentaTipo; }
            set { SetPropertyValue<int>("id_venta_tipo", ref _fidVentaTipo, value); }
        }

        public int IdNegocioLinea
        {
            get { return _fidNegocioLinea; }
            set { SetPropertyValue<int>("id_negocio_linea", ref _fidNegocioLinea, value); }
        }

        public int VigenciaDias
        {
            get { return _fvigenciaDias; }
            set { SetPropertyValue<int>("vigencia_dias", ref _fvigenciaDias, value); }
        }

        public int VigenciaMeses
        {
            get { return _fvigenciaMeses; }
            set { SetPropertyValue<int>("vigencia_meses", ref _fvigenciaMeses, value); }
        }

        public int VigenciaDiasAlVencimiento
        {
            get { return _fvigenciaDiasAlVencimiento; }
            set { SetPropertyValue<int>("vigencia_dias_al_vencimiento", ref _fvigenciaDiasAlVencimiento, value); }
        }

        public int IdCargadaUsuario
        {
            get { return _fidCargadaUsuario; }
            set { SetPropertyValue<int>("id_cargada_usuario", ref _fidCargadaUsuario, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string CargadaNotas
        {
            get { return _fcargadaNotas; }
            set { SetPropertyValue("cargada_notas", ref _fcargadaNotas, value); }
        }

        public int IdValidadaUsuario
        {
            get { return _fidValidadaUsuario; }
            set { SetPropertyValue<int>("id_validada_usuario", ref _fidValidadaUsuario, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string ValidadaNotas
        {
            get { return _fvalidadaNotas; }
            set { SetPropertyValue("validada_notas", ref _fvalidadaNotas, value); }
        }

        public int IdEnviadaUsuario
        {
            get { return _fidEnviadaUsuario; }
            set { SetPropertyValue<int>("id_enviada_usuario", ref _fidEnviadaUsuario, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string EnviadaNotas
        {
            get { return _fenviadaNotas; }
            set { SetPropertyValue("enviada_notas", ref _fenviadaNotas, value); }
        }

        public int IdAcuseDeReciboUsuario
        {
            get { return _fidAcuseDeReciboUsuario; }
            set { SetPropertyValue<int>("id_acuse_de_recibo_usuario", ref _fidAcuseDeReciboUsuario, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string AcuseDeReciboNotas
        {
            get { return _facuseDeReciboNotas; }
            set { SetPropertyValue("acuse_de_recibo_notas", ref _facuseDeReciboNotas, value); }
        }

        public int IdRecepcionPropuestaUsuario
        {
            get { return _fidRecepcionPropuestaUsuario; }
            set { SetPropertyValue<int>("id_recepcion_propuesta_usuario", ref _fidRecepcionPropuestaUsuario, value); }
        }

        public bool RecepcionPropuestaAceptada
        {
            get { return _frecepcionPropuestaAceptada; }
            set { SetPropertyValue("recepcion_propuesta_aceptada", ref _frecepcionPropuestaAceptada, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string RecepcionPropuestaNotas
        {
            get { return _frecepcionPropuestaNotas; }
            set { SetPropertyValue("recepcion_propuesta_notas", ref _frecepcionPropuestaNotas, value); }
        }

        public int IdRegularizadaUsuario
        {
            get { return _fidRegularizadaUsuario; }
            set { SetPropertyValue<int>("id_regularizada_usuario", ref _fidRegularizadaUsuario, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string RegularizadaNotas
        {
            get { return _fregularizadaNotas; }
            set { SetPropertyValue("regularizada_notas", ref _fregularizadaNotas, value); }
        }

        public int IdDespachadaUsuario
        {
            get { return _fidDespachadaUsuario; }
            set { SetPropertyValue<int>("id_despachada_usuario", ref _fidDespachadaUsuario, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string DespachadaNotas
        {
            get { return _fdespachadaNotas; }
            set { SetPropertyValue("despachada_notas", ref _fdespachadaNotas, value); }
        }

        public int IdAceptadaUsuario
        {
            get { return _fidAceptadaUsuario; }
            set { SetPropertyValue<int>("id_aceptada_usuario", ref _fidAceptadaUsuario, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string AceptadaNotas
        {
            get { return _faceptadaNotas; }
            set { SetPropertyValue("aceptada_notas", ref _faceptadaNotas, value); }
        }

        public int IdAnuladaUsuario
        {
            get { return _fidAnuladaUsuario; }
            set { SetPropertyValue<int>("id_anulada_usuario", ref _fidAnuladaUsuario, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string AnuladaNotas
        {
            get { return _fanuladaNotas; }
            set { SetPropertyValue("anulada_notas", ref _fanuladaNotas, value); }
        }

        public int IdPlanDePago
        {
            get { return _fidPlanDePago; }
            set { SetPropertyValue<int>("id_plan_de_pago", ref _fidPlanDePago, value); }
        }

        public decimal PagoAnticipoTasa
        {
            get { return _fpagoAnticipoTasa; }
            set { SetPropertyValue<decimal>("pago_anticipo_tasa", ref _fpagoAnticipoTasa, value); }
        }

        public decimal PagoDescuentoTasa
        {
            get { return _fpagoDescuentoTasa; }
            set { SetPropertyValue<decimal>("pago_descuento_tasa", ref _fpagoDescuentoTasa, value); }
        }

        public decimal PagoDescuentoImporte
        {
            get { return _fpagoDescuentoImporte; }
            set { SetPropertyValue<decimal>("pago_descuento_importe", ref _fpagoDescuentoImporte, value); }
        }

        public int ComprobantesComprobantesIdComprobante
        {
            get { return _fcomprobantesComprobantesIdComprobante; }
            set
            {
                SetPropertyValue<int>("comprobantes_comprobantes_id_comprobante",
                    ref _fcomprobantesComprobantesIdComprobante, value);
            }
        }

        public int IdDocumentoPilotoRol
        {
            get { return _fidDocumentoPilotoRol; }
            set { SetPropertyValue<int>("id_documento_piloto_rol", ref _fidDocumentoPilotoRol, value); }
        }
        */
        /*
        [Browsable(false)]
        [Association(@"DocumentoReferencesDocumento")]
        public XPCollection<Documento> DocumentoCollection => GetCollection<Documento>("DocumentoCollection");

        [Browsable(false)]
        [Association(@"DocumentoReferencesDocumento1")]
        public XPCollection<Documento> DocumentoCollection1 => GetCollection<Documento>("DocumentoCollection1");

        [Browsable(false)]
        [Association(@"DocumentoReferencesDocumento2")]
        public XPCollection<Documento> DocumentoCollection2 => GetCollection<Documento>("DocumentoCollection2");

        [Browsable(false)]
        [Association(@"DocumentoReferencesDocumento3")]
        public XPCollection<Documento> DocumentoCollection3 => GetCollection<Documento>("DocumentoCollection3");
        */
        //[Browsable(false)]
        [Association(@"DocumentoCuotaReferencesDocumento")]
        public XPCollection<DocumentoCuota> Cuotas => GetCollection<DocumentoCuota>("Cuotas");

        //[Browsable(false)]
        [Association(@"DocumentoIntervinienteReferencesDocumento")]
        public XPCollection<DocumentoInterviniente> Intervinientes => GetCollection<DocumentoInterviniente>("Intervinientes");

        //[Browsable(false)]
        [Association(@"DocumentoItemReferencesDocumento")]
        public XPCollection<DocumentoItem> Items => GetCollection<DocumentoItem>("Items");

        [Browsable(false)]
        [Association(@"RefacturacionItemReferencesDocumento")]
        public XPCollection<RefacturacionItem> ItemsRefacturacion => GetCollection<RefacturacionItem>("ItemsRefacturacion");

        [Browsable(false)]
        [Association(@"RendicionArtItemReferencesDocumento")]
        public XPCollection<RendicionARTItem> ItemsRendicionART => GetCollection<RendicionARTItem>("ItemsRendicionART");

        [Browsable(false)]
        [Association(@"RendicionVoItemReferencesDocumento")]
        public XPCollection<RendicionVOItem> ItemsRendicionVO => GetCollection<RendicionVOItem>("ItemsRendicionVO");

        [Browsable(false)]
        [Association(@"SiniestroReferencesDocumento")]
        public XPCollection<Siniestro> Siniestros => GetCollection<Siniestro>("Siniestros");
        
    }
}