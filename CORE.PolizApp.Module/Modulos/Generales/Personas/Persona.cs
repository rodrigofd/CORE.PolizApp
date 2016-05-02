using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using CORE.PolizApp.Gestion;
using CORE.PolizApp.Regionales;
using CORE.PolizApp.Seguridad;
using CORE.PolizApp.Sistema;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace CORE.PolizApp.Personas
{
    [DefaultProperty("NombreCompleto")]
    [Persistent(@"personas.Persona")]
    [System.ComponentModel.DisplayName(@"Persona")]
    [FiltroPorPais]
    //<Appearance("BoldRule", AppearanceItemType := "ViewItem", FontStyle:=FontStyle.Bold, FontColor:="Yellow", TargetItems:="Name", Context:="DetailView")>
    //[Appearance("BoldRule", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "Price>50", Context = "ListView", BackColor = "Red", FontColor = "Maroon", Priority = 2)]
    //[Appearance("DetailViewBoldRule", AppearanceItemType = "ViewItem", TargetItems = "*", FontStyle = FontStyle.Bold, Context = "DetailView", Priority = 0)]
    //[Appearance("RedTipoRule", AppearanceItemType = "ViewItem", TargetItems = "NombreCompleto", Criteria = "Tipo = 'Virtual'", BackColor = "192,192,192", Context = "ListView")]
    public class Persona : BasicObject
    {
        private DateTime? _fAniversarioFecha;
        private string _fApellidosMaterno;
        private string _fApellidosPaterno;
        private ComprobanteTipo _fClienteComprobanteTipoPredeterminado;
        private CondicionDePago _fClienteCondicionDePagoPredeterminada;
        private decimal _fClienteDescuento;
        private Direccion _fClienteDireccionEntrega;
        private Identificacion _fClienteEmailEnvioFacturacion;
        private string _fClienteNota;
        private Direccion _fDireccionPrimaria;
        private int? _fEdad;
        private DateTime _fFallecimientoFecha;
        private Pais _fFallecimientoPais;
        private Identificacion _fIdentificacionPrimaria;
        private DateTime? _fNacimientoFecha;
        private Pais _fNacimientoPais;
        private Pais _fNacionalidad;
        private string _fNombre;
        private string _fNombreCompleto;
        private string _fNombreFantasia;
        private string _fNotas;
        private ComprobanteTipo _fProveedorComprobanteTipoPredeterminado;
        private CondicionDePago _fProveedorCondicionDePagoPredeterminada;
        private Direccion _fProveedorDireccionRetiro;
        private Identificacion _fProveedorEmailAvisoPago;
        private string _fProveedorNota;
        private XPCollection<Relacion> _fRelaciones;
        //private BindingList<personas_Rol> fRoles;
        private Sexo? _fSexo;
        private TipoPersona _fTipo;
        private string _fTratamiento;

        public Persona(Session session)
            : base(session)
        {
        }

        [VisibleInListView(true)]
        [VisibleInDetailView(false)]
        //[Index(0)]
        public override Image Icono
        {
            get
            {
                var descriptor = new EnumDescriptor(typeof (TipoPersona));
                var imageInfo = descriptor.GetImageInfo(Tipo);
                return imageInfo.Image;
            }
        }

        [ImmediatePostData]
        [RuleRequiredField]
        [System.ComponentModel.DisplayName(@"Tipo")]
        public TipoPersona Tipo
        {
            get { return _fTipo; }
            set { SetPropertyValue("Tipo", ref _fTipo, value); }
        }

        [Appearance("tratamiento_tratamiento", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [Size(20)]
        [System.ComponentModel.DisplayName(@"Tratamiento")]
        public string Tratamiento
        {
            get { return _fTratamiento; }
            set { SetPropertyValue("Tratamiento", ref _fTratamiento, value); }
        }

        [Appearance("tratamiento_apellidos_paterno", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        [System.ComponentModel.DisplayName(@"Apellidos paternos")]
        public string ApellidosPaterno
        {
            get { return _fApellidosPaterno; }
            set
            {
                SetPropertyValue("ApellidosPaterno", ref _fApellidosPaterno, value);

                if (CanRaiseOnChanged)
                    ActualizarNombreCompleto();
            }
        }

        [Appearance("tratamiento_apellidos_materno", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        [System.ComponentModel.DisplayName(@"Apellidos maternos")]
        public string ApellidosMaterno
        {
            get { return _fApellidosMaterno; }
            set
            {
                SetPropertyValue("ApellidosMaterno", ref _fApellidosMaterno, value);

                if (CanRaiseOnChanged)
                {
                    ActualizarNombreCompleto();
                }
            }
        }

        //[ Appearance( "personeria_nombre", "Tipo <> 'Juridica'", Enabled = false ) ]
        [ImmediatePostData]
        [RuleRequiredField]
        [System.ComponentModel.DisplayName(@"Nombre")]
        public string Nombre
        {
            get { return _fNombre; }
            set
            {
                SetPropertyValue("Nombre", ref _fNombre, value);

                if (CanRaiseOnChanged)
                {
                    ActualizarNombreCompleto();
                }
            }
        }

        //[Appearance("tratamiento_nombre_fantasia", "Tipo == 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [System.ComponentModel.DisplayName(@"Nombre fantasía/apodo")]
        public string NombreFantasia
        {
            get { return _fNombreFantasia; }
            set
            {
                SetPropertyValue("NombreFantasia", ref _fNombreFantasia, value);

                if (CanRaiseOnChanged)
                {
                    ActualizarNombreCompleto();
                }
            }
        }

        //[ Browsable( false ) ]
        [ReadOnly(true)]
        [System.ComponentModel.DisplayName(@"Nombre completo")]
        public string NombreCompleto
        {
            get { return _fNombreCompleto; }
            set { SetPropertyValue("NombreCompleto", ref _fNombreCompleto, value); }
        }

        [System.ComponentModel.DisplayName(@"Fecha de nacimiento")]
        public DateTime? NacimientoFecha
        {
            get { return _fNacimientoFecha; }
            set
            {
                SetPropertyValue("NacimientoFecha", ref _fNacimientoFecha, value);

                if (CanRaiseOnChanged)
                {
                    var edad = 0;
                    if (value.HasValue)
                    {
                        var now = DateTime.Today;
                        edad = now.Year - value.Value.Year;
                        if (value > now.AddYears(-edad)) edad--;
                    }
                    Edad = edad;
                }
            }
        }

        [System.ComponentModel.DisplayName(@"Fecha de aniversario")]
        public DateTime? AniversarioFecha
        {
            get { return _fAniversarioFecha; }
            set { SetPropertyValue("AniversarioFecha", ref _fAniversarioFecha, value); }
        }

        [Appearance("personeria_edad", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        //[ReadOnly(true)]
        //[Browsable(false)]
        [System.ComponentModel.DisplayName(@"Edad")]
        public int? Edad
        {
            get { return _fEdad; }
            set { SetPropertyValue("Edad", ref _fEdad, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"País de nacimiento")]
        public Pais NacimientoPais
        {
            get { return _fNacimientoPais; }
            set { SetPropertyValue("NacimientoPais", ref _fNacimientoPais, value); }
        }

        [Appearance("personeria_nacionalidad", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"Nacionalidad")]
        public Pais Nacionalidad
        {
            get { return _fNacionalidad; }
            set { SetPropertyValue("Nacionalidad", ref _fNacionalidad, value); }
        }

        [Appearance("personeria_sexo", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        [System.ComponentModel.DisplayName(@"Sexo")]
        public Sexo? Sexo
        {
            get { return _fSexo; }
            set { SetPropertyValue("Sexo", ref _fSexo, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"Fecha de fallecimiento")]
        public DateTime FallecimientoFecha
        {
            get { return _fFallecimientoFecha; }
            set { SetPropertyValue<DateTime>("FallecimientoFecha", ref _fFallecimientoFecha, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"País de fallecimiento")]
        public Pais FallecimientoPais
        {
            get { return _fFallecimientoPais; }
            set { SetPropertyValue("FallecimientoPais", ref _fFallecimientoPais, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("RowCount", "2")]
        public string Notas
        {
            get { return _fNotas; }
            set { SetPropertyValue("Notas", ref _fNotas, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Identificaciones")]
        [System.ComponentModel.DisplayName(@"Identificación primaria")]
        public Identificacion IdentificacionPrimaria
        {
            get { return _fIdentificacionPrimaria; }
            set { SetPropertyValue("IdentificacionPrimaria", ref _fIdentificacionPrimaria, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Direcciones")]
        [System.ComponentModel.DisplayName(@"Dirección primaria")]
        public Direccion DireccionPrimaria
        {
            get { return _fDireccionPrimaria; }
            set { SetPropertyValue("DireccionPrimaria", ref _fDireccionPrimaria, value); }
        }

        [Delayed(true)]
        [ValueConverter(typeof (ImageValueConverter))]
        [System.ComponentModel.DisplayName(@"Imagen")]
        public Image Imagen
        {
            get { return GetDelayedPropertyValue<Image>("Imagen"); }
            set { SetDelayedPropertyValue("Imagen", value); }
        }

        [Delayed(true)]
        [ValueConverter(typeof (ImageValueConverter))]
        [System.ComponentModel.DisplayName(@"Imagen (firma)")]
        public Image ImagenFirma
        {
            get { return GetDelayedPropertyValue<Image>("ImagenFirma"); }
            set { SetDelayedPropertyValue("ImagenFirma", value); }
        }

        [Delayed(true)]
        [ValueConverter(typeof (ImageValueConverter))]
        [System.ComponentModel.DisplayName(@"Imagen (impresiones)")]
        public Image ImagenImp
        {
            get { return GetDelayedPropertyValue<Image>("ImagenImp"); }
            set { SetDelayedPropertyValue("ImagenImp", value); }
        }

        // Cliente

        [System.ComponentModel.DisplayName(@"Comprobante Tipo Predeterminado")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public ComprobanteTipo ClienteComprobanteTipoPredeterminado
        {
            get { return _fClienteComprobanteTipoPredeterminado; }
            set { SetPropertyValue("ClienteComprobanteTipoPredeterminado", ref _fClienteComprobanteTipoPredeterminado, value); }
        }

        [System.ComponentModel.DisplayName(@"Condicion De Pago Predeterminada")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public CondicionDePago ClienteCondicionDePagoPredeterminada
        {
            get { return _fClienteCondicionDePagoPredeterminada; }
            set
            {
                SetPropertyValue("ClienteCondicionDePagoPredeterminada", ref _fClienteCondicionDePagoPredeterminada, value);
            }
        }

        [System.ComponentModel.DisplayName(@"Descuento")]
        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal ClienteDescuento
        {
            get { return _fClienteDescuento; }
            set { SetPropertyValue("ClienteDescuento", ref _fClienteDescuento, value); }
        }

        [System.ComponentModel.DisplayName(@"Dirección Entrega")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Direcciones")]
        public Direccion ClienteDireccionEntrega
        {
            get { return _fClienteDireccionEntrega; }
            set { SetPropertyValue("ClienteDireccionEntrega", ref _fClienteDireccionEntrega, value); }
        }

        [System.ComponentModel.DisplayName(@"EMail envio Facturación")]
        [DataSourceProperty("Identificaciones")]
        public Identificacion ClienteEmailEnvioFacturacion
        {
            get { return _fClienteEmailEnvioFacturacion; }
            set { SetPropertyValue("ClienteEmailEnvioFacturacion", ref _fClienteEmailEnvioFacturacion, value); }
        }

        [System.ComponentModel.DisplayName(@"Nota")]
        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("RowCount", "2")]
        public string ClienteNota
        {
            get { return _fClienteNota; }
            set { SetPropertyValue("ClienteNota", ref _fClienteNota, value); }
        }

        // Proveedor

        [System.ComponentModel.DisplayName(@"Comprobante Tipo Predeterminado")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public ComprobanteTipo ProveedorComprobanteTipoPredeterminado
        {
            get { return _fProveedorComprobanteTipoPredeterminado; }
            set
            {
                SetPropertyValue("ProveedorComprobanteTipoPredeterminado", ref _fProveedorComprobanteTipoPredeterminado,
                    value);
            }
        }

        [System.ComponentModel.DisplayName(@"Condicion De Pago Predeterminada")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public CondicionDePago ProveedorCondicionDePagoPredeterminada
        {
            get { return _fProveedorCondicionDePagoPredeterminada; }
            set
            {
                SetPropertyValue("ProveedorCondicionDePagoPredeterminada", ref _fProveedorCondicionDePagoPredeterminada,
                    value);
            }
        }

        [System.ComponentModel.DisplayName(@"Dirección Retiro")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Direcciones")]
        public Direccion ProveedorDireccionRetiro
        {
            get { return _fProveedorDireccionRetiro; }
            set { SetPropertyValue("ProveedorDireccionRetiro", ref _fProveedorDireccionRetiro, value); }
        }

        [System.ComponentModel.DisplayName(@"EMail aviso Pago")]
        [DataSourceProperty("Identificaciones")]
        public Identificacion ProveedorEmailAvisoPago
        {
            get { return _fProveedorEmailAvisoPago; }
            set { SetPropertyValue("ProveedorEmailAvisoPago", ref _fProveedorEmailAvisoPago, value); }
        }

        [System.ComponentModel.DisplayName(@"Nota")]
        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("RowCount", "2")]
        public string ProveedorNota
        {
            get { return _fProveedorNota; }
            set { SetPropertyValue("ProveedorNota", ref _fProveedorNota, value); }
        }

        [Aggregated]
        [Association(@"DireccionesReferencesPersonas")]
        [System.ComponentModel.DisplayName(@"Direcciones")]
        public XPCollection<Direccion> Direcciones => GetCollection<Direccion>("Direcciones");

        [Aggregated]
        [Association(@"IdentificacionesReferencesPersonas", typeof (Identificacion))]
        [System.ComponentModel.DisplayName(@"Identificaciones")]
        public XPCollection<Identificacion> Identificaciones => GetCollection<Identificacion>("Identificaciones");

        [Aggregated]
        [Association(@"PersonasContactosReferencesPersonas", typeof (PersonaContacto))]
        [System.ComponentModel.DisplayName(@"Contactos")]
        public XPCollection<PersonaContacto> Contactos => GetCollection<PersonaContacto>("Contactos");

        [Aggregated]
        [Association(@"PersonasImpuestosReferencesPersonas", typeof (PersonaImpuesto))]
        [System.ComponentModel.DisplayName(@"Datos impositivos")]
        public XPCollection<PersonaImpuesto> DatosImpositivos => GetCollection<PersonaImpuesto>("DatosImpositivos");

        [Aggregated]
        [Association(@"PersonasPropiedadesReferencesPersonas", typeof (PersonaPropiedad))]
        [System.ComponentModel.DisplayName(@"Propiedades")]
        public XPCollection<PersonaPropiedad> Propiedades => GetCollection<PersonaPropiedad>("Propiedades");

        [Browsable(false)]
        [Association(@"RelacionesReferencesPersonas-Vinculante", typeof (Relacion))]
        [System.ComponentModel.DisplayName(@"Relaciones (vinculante)")]
        public XPCollection<Relacion> RelacionesVinculante => GetCollection<Relacion>("RelacionesVinculante");

        [Browsable(false)]
        [Association(@"RelacionesReferencesPersonas-Vinculado", typeof (Relacion))]
        [System.ComponentModel.DisplayName(@"Relaciones (vinculado)")]
        public XPCollection<Relacion> RelacionesVinculado => GetCollection<Relacion>("RelacionesVinculado");

        [Aggregated]
        [CollectionOperationSet(AllowAdd = false, AllowRemove = true)]
        public XPCollection<Relacion> Relaciones
        {
            get
            {
                if (_fRelaciones == null)
                {
                    var criteria = GroupOperator.Combine(GroupOperatorType.Or,
                        RelacionesVinculante.GetRealFetchCriteria(), RelacionesVinculado.GetRealFetchCriteria());
                    _fRelaciones = new XPCollection<Relacion>(Session, criteria);
                }
                return _fRelaciones;
            }
        }

        public void ActualizarNombreCompleto()
        {
            if (Tipo == TipoPersona.Fisica)
            {
                var apellidos = ApellidosPaterno;
                // Para funcion Propper() = ToTitleCase()
                var cultureInfo = Thread.CurrentThread.CurrentCulture;
                var textInfo = cultureInfo.TextInfo;

                if (!string.IsNullOrWhiteSpace(apellidos) && !string.IsNullOrWhiteSpace(ApellidosMaterno))
                    apellidos += " ";
                apellidos += ApellidosMaterno;
                if (!string.IsNullOrWhiteSpace(apellidos)) apellidos += ", ";
                NombreCompleto = apellidos.ToUpper();
                if (!string.IsNullOrWhiteSpace(Nombre)) NombreCompleto = NombreCompleto + textInfo.ToTitleCase(Nombre);
            }
            else
            {
                NombreCompleto = Nombre.ToUpper();
            }
            //ActualizarNombreCompletoAlias( );
        }

        /*
        private void ActualizarNombreCompletoAlias( )
        {
            NombreCompletoAlias = Nombre + ( string.IsNullOrWhiteSpace( NombreFantasia ) ? "" : " (" + NombreFantasia + ")" );
        }
        */

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            Tipo = TipoPersona.Fisica;
            if (CoreLogonParameters.Instance.EmpresaActual(Session) != null)
                NacimientoPais = Identificadores.GetInstance(Session).PaisPredeterminado;
        }
    }
}