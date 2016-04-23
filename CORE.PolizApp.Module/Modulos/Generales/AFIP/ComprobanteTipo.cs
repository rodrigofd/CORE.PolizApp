using System.ComponentModel;
using CORE.General.Modulos.Sistema;
using DevExpress.Xpo;

namespace CORE.General.Modulos.AFIP
{
    [Persistent(@"afip.ComprobanteTipo")]
    //[DefaultClassOptions]
    [DefaultProperty("Nombre")]
    [System.ComponentModel.DisplayName(@"Tipos de comprobantes AFIP")]
    public class afip_ComprobanteTipo : BasicObject
    {
        private short fCodigo;
        private string fComprobanteTipo;

        public afip_ComprobanteTipo(Session session)
            : base(session)
        {
        }

        public short Codigo
        {
            get { return fCodigo; }
            set { SetPropertyValue("Codigo", ref fCodigo, value); }
        }

        public string Nombre
        {
            get { return fComprobanteTipo; }
            set { SetPropertyValue("Nombre", ref fComprobanteTipo, value); }
        }
    }
}