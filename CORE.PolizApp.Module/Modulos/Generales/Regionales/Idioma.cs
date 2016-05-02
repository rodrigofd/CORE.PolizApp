using System.ComponentModel;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.PolizApp.Regionales
{
    [Persistent(@"regionales.Idioma")]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Idioma")]
    [DefaultClassOptions]
public class Idioma : BasicObject
    {
        private string _fCodigo;
        private string _fCodigo1;
        private string _fCodigo2;
        private int _fCodigoMsLangId;
        private string _fCodigoSqlServer;
        private string _fNombre;
        private string _fNombreEng;

        public Idioma(Session session) : base(session)
        {
        }

        [Size(50)]
        [Index(0)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(SizeAttribute.Unlimited)]
        [Index(1)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        [Size(60)]
        public string NombreEng
        {
            get { return _fNombreEng; }
            set { SetPropertyValue("NombreEng", ref _fNombreEng, value); }
        }

        [Size(50)]
        public string Codigo1
        {
            get { return _fCodigo1; }
            set { SetPropertyValue("Codigo1", ref _fCodigo1, value); }
        }

        [Size(10)]
        public string Codigo2
        {
            get { return _fCodigo2; }
            set { SetPropertyValue("Codigo2", ref _fCodigo2, value); }
        }

        public int CodigoMsLangId
        {
            get { return _fCodigoMsLangId; }
            set { SetPropertyValue<int>("Mslangid", ref _fCodigoMsLangId, value); }
        }

        public string CodigoSqlServer
        {
            get { return _fCodigoSqlServer; }
            set { SetPropertyValue("IdiomaSql", ref _fCodigoSqlServer, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}