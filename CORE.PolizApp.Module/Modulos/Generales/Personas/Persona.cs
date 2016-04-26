using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using CORE.PolizApp.Gestion;
using CORE.PolizApp.Regionales;
using CORE.PolizApp.Sistema;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
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
    //[DefaultClassOptions]
    [System.ComponentModel.DisplayName(@"Persona")]
    [FiltroPorPais]
    //<Appearance("BoldRule", AppearanceItemType := "ViewItem", FontStyle:=FontStyle.Bold, FontColor:="Yellow", TargetItems:="Name", Context:="DetailView")>
    //[Appearance("BoldRule", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "Price>50", Context = "ListView", BackColor = "Red", FontColor = "Maroon", Priority = 2)]
    //[Appearance("DetailViewBoldRule", AppearanceItemType = "ViewItem", TargetItems = "*", FontStyle = FontStyle.Bold, Context = "DetailView", Priority = 0)]
    [Appearance("RedTipoRule", AppearanceItemType = "ViewItem", TargetItems = "NombreCompleto",
        Criteria = "Tipo = 'Virtual'", BackColor = "192,192,192", Context = "ListView")]
    public class Persona : BasicObject
    {
        private DateTime? fAniversarioFecha;
        private string fApellidosMaterno;
        private string fApellidosPaterno;
        private ComprobanteTipo fClienteComprobanteTipoPredeterminado;
        private CondicionDePago fClienteCondicionDePagoPredeterminada;
        private decimal fClienteDescuento;
        private Direccion fClienteDireccionEntrega;
        private Identificacion fClienteEmailEnvioFacturacion;
        private string fClienteNota;
        private Direccion fDireccionPrimaria;
        private int? fEdad;
        private DateTime fFallecimientoFecha;
        private Pais fFallecimientoPais;
        private Identificacion fIdentificacionPrimaria;
        private DateTime? fNacimientoFecha;
        private Pais fNacimientoPais;
        private Pais fNacionalidad;
        private string fNombre;
        private string fNombreCompleto;
        private string fNombreFantasia;
        private string fNotas;
        private ComprobanteTipo fProveedorComprobanteTipoPredeterminado;
        private CondicionDePago fProveedorCondicionDePagoPredeterminada;
        private Direccion fProveedorDireccionRetiro;
        private Identificacion fProveedorEmailAvisoPago;
        private string fProveedorNota;
        private XPCollection<Relacion> fRelaciones;
        //private BindingList<personas_Rol> fRoles;
        private Sexo? fSexo;
        private TipoPersona fTipo;
        private string fTratamiento;

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
            get { return fTipo; }
            set { SetPropertyValue("Tipo", ref fTipo, value); }
        }

        [Appearance("tratamiento_tratamiento", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [Size(20)]
        [System.ComponentModel.DisplayName(@"Tratamiento")]
        public string Tratamiento
        {
            get { return fTratamiento; }
            set { SetPropertyValue("Tratamiento", ref fTratamiento, value); }
        }

        [Appearance("tratamiento_apellidos_paterno", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        [System.ComponentModel.DisplayName(@"Apellidos paternos")]
        public string ApellidosPaterno
        {
            get { return fApellidosPaterno; }
            set
            {
                SetPropertyValue("ApellidosPaterno", ref fApellidosPaterno, value);

                if (CanRaiseOnChanged)
                    ActualizarNombreCompleto();
            }
        }

        [Appearance("tratamiento_apellidos_materno", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        [System.ComponentModel.DisplayName(@"Apellidos maternos")]
        public string ApellidosMaterno
        {
            get { return fApellidosMaterno; }
            set
            {
                SetPropertyValue("ApellidosMaterno", ref fApellidosMaterno, value);

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
            get { return fNombre; }
            set
            {
                SetPropertyValue("Nombre", ref fNombre, value);

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
            get { return fNombreFantasia; }
            set
            {
                SetPropertyValue("NombreFantasia", ref fNombreFantasia, value);

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
            get { return fNombreCompleto; }
            set { SetPropertyValue("NombreCompleto", ref fNombreCompleto, value); }
        }

        [System.ComponentModel.DisplayName(@"Fecha de nacimiento")]
        public DateTime? NacimientoFecha
        {
            get { return fNacimientoFecha; }
            set
            {
                SetPropertyValue("NacimientoFecha", ref fNacimientoFecha, value);

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
            get { return fAniversarioFecha; }
            set { SetPropertyValue("AniversarioFecha", ref fAniversarioFecha, value); }
        }

        [Appearance("personeria_edad", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        //[ReadOnly(true)]
        //[Browsable(false)]
        [System.ComponentModel.DisplayName(@"Edad")]
        public int? Edad
        {
            get { return fEdad; }
            set { SetPropertyValue("Edad", ref fEdad, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"País de nacimiento")]
        public Pais NacimientoPais
        {
            get { return fNacimientoPais; }
            set { SetPropertyValue("NacimientoPais", ref fNacimientoPais, value); }
        }

        [Appearance("personeria_nacionalidad", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"Nacionalidad")]
        public Pais Nacionalidad
        {
            get { return fNacionalidad; }
            set { SetPropertyValue("Nacionalidad", ref fNacionalidad, value); }
        }

        [Appearance("personeria_sexo", "Tipo <> 'Fisica'", Visibility = ViewItemVisibility.Hide)]
        [ImmediatePostData]
        [System.ComponentModel.DisplayName(@"Sexo")]
        public Sexo? Sexo
        {
            get { return fSexo; }
            set { SetPropertyValue("Sexo", ref fSexo, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"Fecha de fallecimiento")]
        public DateTime FallecimientoFecha
        {
            get { return fFallecimientoFecha; }
            set { SetPropertyValue<DateTime>("FallecimientoFecha", ref fFallecimientoFecha, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [System.ComponentModel.DisplayName(@"País de fallecimiento")]
        public Pais FallecimientoPais
        {
            get { return fFallecimientoPais; }
            set { SetPropertyValue("FallecimientoPais", ref fFallecimientoPais, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("RowCount", "2")]
        public string Notas
        {
            get { return fNotas; }
            set { SetPropertyValue("Notas", ref fNotas, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Identificaciones")]
        [System.ComponentModel.DisplayName(@"Identificación primaria")]
        public Identificacion IdentificacionPrimaria
        {
            get { return fIdentificacionPrimaria; }
            set { SetPropertyValue("IdentificacionPrimaria", ref fIdentificacionPrimaria, value); }
        }

        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Direcciones")]
        [System.ComponentModel.DisplayName(@"Dirección primaria")]
        public Direccion DireccionPrimaria
        {
            get { return fDireccionPrimaria; }
            set { SetPropertyValue("DireccionPrimaria", ref fDireccionPrimaria, value); }
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
            get { return fClienteComprobanteTipoPredeterminado; }
            set
            {
                SetPropertyValue("ClienteComprobanteTipoPredeterminado", ref fClienteComprobanteTipoPredeterminado,
                    value);
            }
        }

        [System.ComponentModel.DisplayName(@"Condicion De Pago Predeterminada")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public CondicionDePago ClienteCondicionDePagoPredeterminada
        {
            get { return fClienteCondicionDePagoPredeterminada; }
            set
            {
                SetPropertyValue("ClienteCondicionDePagoPredeterminada", ref fClienteCondicionDePagoPredeterminada,
                    value);
            }
        }

        [System.ComponentModel.DisplayName(@"Descuento")]
        [ModelDefault("DisplayFormat", "{0:n2}"), ModelDefault("EditMask", "n2")]
        public decimal ClienteDescuento
        {
            get { return fClienteDescuento; }
            set { SetPropertyValue("ClienteDescuento", ref fClienteDescuento, value); }
        }

        [System.ComponentModel.DisplayName(@"Dirección Entrega")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Direcciones")]
        public Direccion ClienteDireccionEntrega
        {
            get { return fClienteDireccionEntrega; }
            set { SetPropertyValue("ClienteDireccionEntrega", ref fClienteDireccionEntrega, value); }
        }

        [System.ComponentModel.DisplayName(@"EMail envio Facturación")]
        [DataSourceProperty("Identificaciones")]
        public Identificacion ClienteEmailEnvioFacturacion
        {
            get { return fClienteEmailEnvioFacturacion; }
            set { SetPropertyValue("ClienteEmailEnvioFacturacion", ref fClienteEmailEnvioFacturacion, value); }
        }

        [System.ComponentModel.DisplayName(@"Nota")]
        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("RowCount", "2")]
        public string ClienteNota
        {
            get { return fClienteNota; }
            set { SetPropertyValue("ClienteNota", ref fClienteNota, value); }
        }

        // Proveedor

        [System.ComponentModel.DisplayName(@"Comprobante Tipo Predeterminado")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public ComprobanteTipo ProveedorComprobanteTipoPredeterminado
        {
            get { return fProveedorComprobanteTipoPredeterminado; }
            set
            {
                SetPropertyValue("ProveedorComprobanteTipoPredeterminado", ref fProveedorComprobanteTipoPredeterminado,
                    value);
            }
        }

        [System.ComponentModel.DisplayName(@"Condicion De Pago Predeterminada")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        public CondicionDePago ProveedorCondicionDePagoPredeterminada
        {
            get { return fProveedorCondicionDePagoPredeterminada; }
            set
            {
                SetPropertyValue("ProveedorCondicionDePagoPredeterminada", ref fProveedorCondicionDePagoPredeterminada,
                    value);
            }
        }

        [System.ComponentModel.DisplayName(@"Dirección Retiro")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [DataSourceProperty("Direcciones")]
        public Direccion ProveedorDireccionRetiro
        {
            get { return fProveedorDireccionRetiro; }
            set { SetPropertyValue("ProveedorDireccionRetiro", ref fProveedorDireccionRetiro, value); }
        }

        [System.ComponentModel.DisplayName(@"EMail aviso Pago")]
        [DataSourceProperty("Identificaciones")]
        public Identificacion ProveedorEmailAvisoPago
        {
            get { return fProveedorEmailAvisoPago; }
            set { SetPropertyValue("ProveedorEmailAvisoPago", ref fProveedorEmailAvisoPago, value); }
        }

        [System.ComponentModel.DisplayName(@"Nota")]
        [Size(SizeAttribute.Unlimited)]
        [ModelDefault("RowCount", "2")]
        public string ProveedorNota
        {
            get { return fProveedorNota; }
            set { SetPropertyValue("ProveedorNota", ref fProveedorNota, value); }
        }

        [DevExpress.Xpo.Aggregated]
        [Association(@"EmpresaReferencespersonas_Persona")]
        [System.ComponentModel.DisplayName(@"Empresas")]
        public XPCollection<Empresa> Empresas
        {
            get { return GetCollection<Empresa>("Empresas"); }
        }

        [DevExpress.Xpo.Aggregated]
        [Association(@"DireccionesReferencesPersonas")]
        [System.ComponentModel.DisplayName(@"Direcciones")]
        public XPCollection<Direccion> Direcciones => GetCollection<Direccion>("Direcciones");

        [DevExpress.Xpo.Aggregated]
        [Association(@"IdentificacionesReferencesPersonas", typeof (Identificacion))]
        [System.ComponentModel.DisplayName(@"Identificaciones")]
        public XPCollection<Identificacion> Identificaciones => GetCollection<Identificacion>("Identificaciones");

        [DevExpress.Xpo.Aggregated]
        [Association(@"PersonasContactosReferencesPersonas", typeof (PersonaContacto))]
        [System.ComponentModel.DisplayName(@"Contactos")]
        public XPCollection<PersonaContacto> Contactos => GetCollection<PersonaContacto>("Contactos");

        [DevExpress.Xpo.Aggregated]
        [Association(@"PersonasImpuestosReferencesPersonas", typeof (PersonaImpuesto))]
        [System.ComponentModel.DisplayName(@"Datos impositivos")]
        public XPCollection<PersonaImpuesto> DatosImpositivos => GetCollection<PersonaImpuesto>("DatosImpositivos");

        [DevExpress.Xpo.Aggregated]
        [Association(@"PersonasPropiedadesReferencesPersonas", typeof (PersonaPropiedad))]
        [System.ComponentModel.DisplayName(@"Propiedades")]
        public XPCollection<PersonaPropiedad> Propiedades => GetCollection<PersonaPropiedad>("Propiedades");

        [Browsable(false)]
        [Association(@"RelacionesReferencesPersonas-Vinculante", typeof (Relacion))]
        [System.ComponentModel.DisplayName(@"Relaciones (vinculante)")]
        public XPCollection<Relacion> RelacionesVinculante => GetCollection<Relacion>("RelacionesVinculante");

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [CollectionOperationSet(AllowAdd = false, AllowRemove = false)]
        [Association(@"vRelacionesReferencesPersonas-Vinculante", typeof (vRelacion))]
        [System.ComponentModel.DisplayName(@"RelacionesPersonas")]
        public XPCollection<vRelacion> vRelacionesVinculante => GetCollection<vRelacion>("vRelacionesVinculante");

        [Browsable(false)]
        [Association(@"RelacionesReferencesPersonas-Vinculado", typeof (Relacion))]
        [System.ComponentModel.DisplayName(@"Relaciones (vinculado)")]
        public XPCollection<Relacion> RelacionesVinculado => GetCollection<Relacion>("RelacionesVinculado");

        //[Browsable(false)]
        [DevExpress.Xpo.Aggregated]
        [CollectionOperationSet(AllowAdd = true, AllowRemove = true)]
        [VisibleInListView(false)]
        //[VisibleInDetailView(false)]
        public XPCollection<Relacion> Relaciones
        {
            get
            {
                if (fRelaciones == null)
                {
                    var criteria = GroupOperator.Combine(GroupOperatorType.Or,
                        RelacionesVinculante.GetRealFetchCriteria(), RelacionesVinculado.GetRealFetchCriteria());
                    fRelaciones = new XPCollection<Relacion>(Session, criteria);
                }
                return fRelaciones;
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
            //if( CoreLogonParameters.Instance.EmpresaActual(Session) != null )
            //  NacimientoPais = Identificadores.GetInstance( Session ).PaisPredeterminado;
        }
    }
}