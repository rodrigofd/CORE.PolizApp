using System.ComponentModel;
using CORE.General.Modulos.Regionales;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

//using CORE.General.Modulos.Compras;
//using CORE.General.Modulos.Seguridad;

namespace CORE.General.Modulos.Impuestos
{
    public enum Impuestos
    {
        IVA = 1,
        Ganancias = 2,
        IngresosBrutosProvBuenosAires = 3,
    }

    [Persistent(@"impuestos.Impuesto")]
    //[ DefaultClassOptions ]
    [DefaultProperty("Nombre")]
    [FiltroPorPais(true)]
    [System.ComponentModel.DisplayName(@"Impuestos")]
    public class impuestos_Impuesto : BasicObject
    {
        private string fCodigo;
        private string fNombre;

        private int fOrden;
        private regionales_Pais fPais;

        public impuestos_Impuesto(Session session)
            : base(session)
        {
        }

        [Association(@"ImpuestosReferencesPaises")]
        public regionales_Pais Pais
        {
            get { return fPais; }
            set { SetPropertyValue("Pais", ref fPais, value); }
        }

        [Size(10)]
        [Index(0)]
        public string Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        [Size(50)]
        [Index(1)]
        public string Nombre
        {
            get { return fNombre; }
            set { SetPropertyValue("Nombre", ref fNombre, value); }
        }

        public int Orden
        {
            get { return fOrden; }
            set { SetPropertyValue<int>("Orden", ref fOrden, value); }
        }

        [Association(@"PadronReferencesImpuestos", typeof (impuestos_Padron))]
        public XPCollection<impuestos_Padron> Padron
        {
            get { return GetCollection<impuestos_Padron>("Padron"); }
        }

        [Association(@"ImpuestoTipoReferencesImpuestos", typeof (impuestos_ImpuestoTipo))]
        public XPCollection<impuestos_ImpuestoTipo> ImpuestosTipos
        {
            get { return GetCollection<impuestos_ImpuestoTipo>("ImpuestosTipos"); }
        }

        [Association(@"CategoriasReferencesImpuestos", typeof (impuestos_Categoria))]
        public XPCollection<impuestos_Categoria> Categorias
        {
            get { return GetCollection<impuestos_Categoria>("Categorias"); }
        }

        [Association(@"RegimenesReferencesImpuestos", typeof (impuestos_Regimen))]
        public XPCollection<impuestos_Regimen> Regimenes
        {
            get { return GetCollection<impuestos_Regimen>("Regimenes"); }
        }

        [Association(@"RetencionesEscalaReferencesImpuestos", typeof (impuestos_RetencionEscala))]
        public XPCollection<impuestos_RetencionEscala> RetencionesEscalas
        {
            get { return GetCollection<impuestos_RetencionEscala>("RetencionesEscalas"); }
        }


        /*
            public static bool operator ==(impuestos_Impuesto a, Impuestos b)
            {
              if( a == null ) return false;
              if( a.Oid < 1 ) throw new InvalidCastException( );

              return ( Impuestos ) a.Oid == b;
            }

            public static bool operator !=(impuestos_Impuesto a, Impuestos b)
            {
              return !( a == b );
            }
        */
        /*
        public void CalcularRetencionGanancias( OrdenPago pago )
        {
          var datosImp = pago.Empresa.Persona.DatosImpositivos.FirstOrDefault( di => di.Impuesto == Impuestos.Ganancias );
          if( datosImp == null || !datosImp.AgenteRetencion ) return;

      
        }
        */
    }
}