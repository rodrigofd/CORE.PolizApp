using System.ComponentModel;
using CORE.PolizApp.Regionales;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.Impuestos
{
    [Persistent(@"impuestos.Impuesto")]
    //[ DefaultClassOptions ]
    [DefaultProperty("Nombre")]
    [FiltroPorPais(true)]
    [System.ComponentModel.DisplayName(@"Impuestos")]
    public class Impuesto : BasicObject
    {
        private string fCodigo;
        private string fNombre;

        private int fOrden;
        private Pais fPais;

        public Impuesto(Session session)
            : base(session)
        {
        }

        [Association(@"ImpuestosReferencesPaises")]
        public Pais Pais
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

        [Association(@"PadronReferencesImpuestos", typeof (Padron))]
        public XPCollection<Padron> Padron => GetCollection<Padron>("Padron");

        [Association(@"ImpuestoTipoReferencesImpuestos", typeof (ImpuestoTipo))]
        public XPCollection<ImpuestoTipo> ImpuestosTipos => GetCollection<ImpuestoTipo>("ImpuestosTipos");

        [Association(@"CategoriasReferencesImpuestos", typeof (Categoria))]
        public XPCollection<Categoria> Categorias => GetCollection<Categoria>("Categorias");

        [Association(@"RegimenesReferencesImpuestos", typeof (Regimen))]
        public XPCollection<Regimen> Regimenes => GetCollection<Regimen>("Regimenes");

        [Association(@"RetencionesEscalaReferencesImpuestos", typeof (RetencionEscala))]
        public XPCollection<RetencionEscala> RetencionesEscalas => GetCollection<RetencionEscala>("RetencionesEscalas");

        /*
        public void CalcularRetencionGanancias( OrdenPago pago )
        {
          var datosImp = pago.Empresa.Persona.DatosImpositivos.FirstOrDefault( di => di.Impuesto == Impuestos.Ganancias );
          if( datosImp == null || !datosImp.AgenteRetencion ) return;      
        }
        */

        /*
        public static bool operator ==(Impuesto a, Impuestos b)
        {
            if( a == null ) return false;
            if( a.Oid < 1 ) throw new InvalidCastException( );

            return ( Impuestos ) a.Oid == b;
        }

        public static bool operator !=(Impuesto a, Impuestos b)
        {
            return !( a == b );
        }
        */
    }
}