using System;
using System.ComponentModel;
using CORE.PolizApp.Regionales;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Personas
{
    [Persistent(@"personas.IdentificacionTipo")]
    [DefaultProperty("Descripcion")]
    [FiltroPorPais(true)]
    [System.ComponentModel.DisplayName(@"Tipo de identificación")]
    [DefaultClassOptions]
public class IdentificacionTipo : BasicObject
    {
        //TODO: parametrizar
        public const int Cuit = 80;
        public const int NumeroIngresosBrutos = 101;

        private bool _fAdmiteDuplicados;
        private IdentificacionClase _fClase;
        private string _fCodigo;
        private string _fFmt;
        private string _fNombre;
        private Pais _fPais;
        private bool _fValida;
        private string _fValidaJs;

        public IdentificacionTipo(Session session) : base(session)
        {
        }

        [VisibleInDetailView(false)]
        //[PersistentAlias( "IIf(IsNull(Codigo), '', Codigo + ' - ') + Nombre" )]
        [PersistentAlias("ISNULL(Codigo,'')")]
        public string Descripcion => Convert.ToString(EvaluateAlias("Descripcion"));

        [Association(@"IdentificacionesTiposReferencesIdentificacionesClases", typeof (IdentificacionClase))]
        public IdentificacionClase Clase
        {
            get { return _fClase; }
            set { SetPropertyValue("Clase", ref _fClase, value); }
        }

        [Association(@"IdentificacionesTiposReferencesPaises", typeof (Pais))]
        public Pais Pais
        {
            get { return _fPais; }
            set { SetPropertyValue("Pais", ref _fPais, value); }
        }

        [Size(20)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Index(1)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        public bool ValidacionActiva
        {
            get { return _fValida; }
            set { SetPropertyValue("Valida", ref _fValida, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string ValidacionLogica
        {
            get { return _fValidaJs; }
            set { SetPropertyValue("ValidaJs", ref _fValidaJs, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        public string Formato
        {
            get { return _fFmt; }
            set { SetPropertyValue("Fmt", ref _fFmt, value); }
        }

        public bool AdmiteDuplicados
        {
            get { return _fAdmiteDuplicados; }
            set { SetPropertyValue("AdmiteDuplicados", ref _fAdmiteDuplicados, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}