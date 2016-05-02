using System;
using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Fondos
{
    [Persistent(@"fondos.Especie")]
    //[DefaultClassOptions]
    [System.ComponentModel.DisplayName(@"Especies")]
    [DefaultClassOptions]
public class Especie : BasicObject
    {
        private string _fCodigo;
        private string _fEspecie;
        //private Image fEspecieIcono;
        private bool _fExigeValor;
        private bool _fExpresaMoneda;

        private EspecieInstrumento _fInstrumento;
        private Moneda _fMoneda;
        private int _fOrden;
        //private string fTipoValor;
        //private Dictionary<string, string> fTiposValoresPosibles;

        public Especie(Session session)
            : base(session)
        {
        }
        
        public Moneda Moneda
        {
            get { return _fMoneda; }
            set { SetPropertyValue("Moneda", ref _fMoneda, value); }
        }

        [Association(@"EspeciesReferencesEspeciesInstrumentos")]
        public EspecieInstrumento Instrumento
        {
            get { return _fInstrumento; }
            set { SetPropertyValue("Instrumento", ref _fInstrumento, value); }
        }

        [Size(20)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(50)]
        [Index(1)]
        public string Nombre
        {
            get { return _fEspecie; }
            set { SetPropertyValue("Nombre", ref _fEspecie, value); }
        }

        public bool ExpresaMoneda
        {
            get { return _fExpresaMoneda; }
            set { SetPropertyValue("ExpresaMoneda", ref _fExpresaMoneda, value); }
        }

/*
        [Browsable(false)]
        public Dictionary<string, string> TiposValoresPosibles
        {
            get
            {
                if (fTiposValoresPosibles == null)
                {
                    fTiposValoresPosibles = new Dictionary<string, string>();

                    //TODO: los objetos XPO no deberian referenciar la plataforma XAF; cambiar para usar los tipos XPO
                    var documentoItemType = XafTypesInfo.Instance.PersistentTypes.First(info => info.Type == typeof(Valor));
                    var desc = documentoItemType.Name;
                    var displayNameAttr = documentoItemType.FindAttribute<DisplayNameAttribute>();
                    if (displayNameAttr != null) desc = displayNameAttr.DisplayName;

                    fTiposValoresPosibles.Add(documentoItemType.Type.FullName, desc);

                    foreach (var type in documentoItemType.Descendants.OrderBy(info => info.Name))
                    {
                        desc = type.Name;
                        displayNameAttr = type.FindAttribute<DisplayNameAttribute>();
                        if (displayNameAttr != null) desc = displayNameAttr.DisplayName;

                        fTiposValoresPosibles.Add(type.Type.FullName, desc);
                    }
                }
                return fTiposValoresPosibles;
            }
        }

        [SimpleComboBox(AllowEdit = false, AllowNullValues = true, DataSourceProperty = "TiposValoresPosibles", DisplayValues = false)]
        public string TipoValor
        {
            get { return fTipoValor; }
            set { SetPropertyValue("TipoValor", ref fTipoValor, value); }
        }
*/

        public bool ExigeValor
        {
            get { return _fExigeValor; }
            set { SetPropertyValue("ExigeValor", ref _fExigeValor, value); }
        }

        public int Orden
        {
            get { return _fOrden; }
            set { SetPropertyValue<int>("Orden", ref _fOrden, value); }
        }

        [Association(@"fondos_CuentaReferencesfondos_Especie", typeof (Cuenta))]
        public XPCollection<Cuenta> Cuentas => GetCollection<Cuenta>("Cuentas");

        [Association(@"fondos_ValorReferencesfondos_Especie", typeof (Valor))]
        public XPCollection<Valor> Valores => GetCollection<Valor>("Valores");

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}