using System;
using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Fondos
{
    [Persistent(@"fondos.Especie")]
    //[DefaultClassOptions]
    [DefaultProperty("EspecieID")]
    [System.ComponentModel.DisplayName(@"Especies")]
    public class fondos_Especie : BasicObject
    {
        private string fCodigo;
        private string fEspecie;
        //private Image fEspecieIcono;
        private bool fExigeValor;
        private bool fExpresaMoneda;

        private fondos_EspecieInstrumento fInstrumento;
        private fondos_Moneda fMoneda;
        private int fOrden;
        //private string fTipoValor;
        //private Dictionary<string, string> fTiposValoresPosibles;

        public fondos_Especie(Session session)
            : base(session)
        {
        }

        [VisibleInDetailView(false)]
        [System.ComponentModel.DisplayName(@"Especie")]
        //[PersistentAlias("concat(EscribanoRegistro.EscribanoRegistroID, '-', ToStr(Numero), '-', ToStr(escribania_Protocolo.MIN(Folio)), ' (', Trim(SubString(ToStr(Fecha), 0, 10)), ') ')")]
        [PersistentAlias("Codigo")]
        public string EspecieID
        {
            get { return Convert.ToString(EvaluateAlias("EspecieID")); }
        }

        public fondos_Moneda Moneda
        {
            get { return fMoneda; }
            set { SetPropertyValue("Moneda", ref fMoneda, value); }
        }

        [Association(@"EspeciesReferencesEspeciesInstrumentos")]
        public fondos_EspecieInstrumento Instrumento
        {
            get { return fInstrumento; }
            set { SetPropertyValue("Instrumento", ref fInstrumento, value); }
        }

        [Size(20)]
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
            get { return fEspecie; }
            set { SetPropertyValue("Nombre", ref fEspecie, value); }
        }

        public bool ExpresaMoneda
        {
            get { return fExpresaMoneda; }
            set { SetPropertyValue("ExpresaMoneda", ref fExpresaMoneda, value); }
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
            get { return fExigeValor; }
            set { SetPropertyValue("ExigeValor", ref fExigeValor, value); }
        }

        public int Orden
        {
            get { return fOrden; }
            set { SetPropertyValue<int>("Orden", ref fOrden, value); }
        }

        [Association(@"fondos_CuentaReferencesfondos_Especie", typeof (fondos_Cuenta))]
        public XPCollection<fondos_Cuenta> fondos_Cuenta
        {
            get { return GetCollection<fondos_Cuenta>("fondos_Cuenta"); }
        }

        [Association(@"fondos_ValorReferencesfondos_Especie", typeof (fondos_Valor))]
        public XPCollection<fondos_Valor> fondos_Valor
        {
            get { return GetCollection<fondos_Valor>("fondos_Valor"); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}