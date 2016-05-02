using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.VehiculoModelo")]
    public class VehiculoModelo : BasicObject
    {
        private bool _fAbs;
        private bool _fAirbag;
        private bool _fAireAcondicionado;
        private string _fAlimentacion;
        private string _fCabina;
        private string _fCaja;
        private string _fCodigo;
        private string _fCombustion;
        private string _fDireccion;
        private bool _fEsCarga;
        private int _fHp;
        private bool _fImportado;
        private int _finfoautoId;
        private string _fMotor;
        private int _fPeso;
        private string _fPuertas;
        private decimal _fTarifaTramo1;
        private decimal _fTarifaTramo2;
        private decimal _fTarifaTramo3;
        private string _fTipo;
        private string _fTraccion;
        private string _fVehiculoGrupo;
        private VehiculoMarca _fVehiculoMarca;
        private string _fVehiculoModelo1;
        private int _fVelocidadMax;

        public VehiculoModelo(Session session) : base(session)
        {
        }

        [Association(@"VehiculoModeloReferencesVehiculoMarca")]
        public VehiculoMarca VehiculoMarca
        {
            get { return _fVehiculoMarca; }
            set { SetPropertyValue("VehiculoMarca", ref _fVehiculoMarca, value); }
        }

        [Size(10)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(50)]
        public string VehiculoGrupo
        {
            get { return _fVehiculoGrupo; }
            set { SetPropertyValue("VehiculoGrupo", ref _fVehiculoGrupo, value); }
        }

        [Size(50)]
        [Persistent(@"VehiculoModelo")]
        public string VehiculoModelo1
        {
            get { return _fVehiculoModelo1; }
            set { SetPropertyValue("VehiculoModelo1", ref _fVehiculoModelo1, value); }
        }

        [Size(3)]
        public string Combustion
        {
            get { return _fCombustion; }
            set { SetPropertyValue("Combustion", ref _fCombustion, value); }
        }

        [Size(3)]
        public string Alimentacion
        {
            get { return _fAlimentacion; }
            set { SetPropertyValue("Alimentacion", ref _fAlimentacion, value); }
        }

        [Size(10)]
        public string Motor
        {
            get { return _fMotor; }
            set { SetPropertyValue("Motor", ref _fMotor, value); }
        }

        [Size(1)]
        public string Puertas
        {
            get { return _fPuertas; }
            set { SetPropertyValue("Puertas", ref _fPuertas, value); }
        }

        [Size(3)]
        public string Tipo
        {
            get { return _fTipo; }
            set { SetPropertyValue("Tipo", ref _fTipo, value); }
        }

        [Size(4)]
        public string Cabina
        {
            get { return _fCabina; }
            set { SetPropertyValue("Cabina", ref _fCabina, value); }
        }

        public bool EsCarga
        {
            get { return _fEsCarga; }
            set { SetPropertyValue("EsCarga", ref _fEsCarga, value); }
        }

        public int Peso
        {
            get { return _fPeso; }
            set { SetPropertyValue<int>("Peso", ref _fPeso, value); }
        }

        public int VelocidadMax
        {
            get { return _fVelocidadMax; }
            set { SetPropertyValue<int>("VelocidadMax", ref _fVelocidadMax, value); }
        }

        public int Hp
        {
            get { return _fHp; }
            set { SetPropertyValue<int>("Hp", ref _fHp, value); }
        }

        [Size(3)]
        public string Direccion
        {
            get { return _fDireccion; }
            set { SetPropertyValue("Direccion", ref _fDireccion, value); }
        }

        public bool AireAcondicionado
        {
            get { return _fAireAcondicionado; }
            set { SetPropertyValue("AireAcondicionado", ref _fAireAcondicionado, value); }
        }

        [Size(3)]
        public string Traccion
        {
            get { return _fTraccion; }
            set { SetPropertyValue("Traccion", ref _fTraccion, value); }
        }

        public bool Importado
        {
            get { return _fImportado; }
            set { SetPropertyValue("Importado", ref _fImportado, value); }
        }

        [Size(3)]
        public string Caja
        {
            get { return _fCaja; }
            set { SetPropertyValue("Caja", ref _fCaja, value); }
        }

        public bool Abs
        {
            get { return _fAbs; }
            set { SetPropertyValue("Abs", ref _fAbs, value); }
        }

        public bool Airbag
        {
            get { return _fAirbag; }
            set { SetPropertyValue("Airbag", ref _fAirbag, value); }
        }

        public int InfoautoId
        {
            get { return _finfoautoId; }
            set { SetPropertyValue<int>("infoauto_Id", ref _finfoautoId, value); }
        }

        public decimal TarifaTramo1
        {
            get { return _fTarifaTramo1; }
            set { SetPropertyValue<decimal>("TarifaTramo1", ref _fTarifaTramo1, value); }
        }

        public decimal TarifaTramo2
        {
            get { return _fTarifaTramo2; }
            set { SetPropertyValue<decimal>("TarifaTramo2", ref _fTarifaTramo2, value); }
        }

        public decimal TarifaTramo3
        {
            get { return _fTarifaTramo3; }
            set { SetPropertyValue<decimal>("TarifaTramo3", ref _fTarifaTramo3, value); }
        }

        [Association(@"DocumentoItemReferencesVehiculoModelo")]
        public XPCollection<DocumentoItem> DocumentoItems => GetCollection<DocumentoItem>("DocumentoItems");

        [Association(@"VehiculoPrecioReferencesVehiculoModelo")]
        public XPCollection<VehiculoPrecio> Precios => GetCollection<VehiculoPrecio>("Precios");
    }
}