using CORE.PolizApp.Personas;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.DocumentoInterviniente")]
    public class DocumentoInterviniente : BasicObject
    {
        private decimal _fComisionCobranzaTasa;
        private decimal _fComisionPrimaTasa;
        private PersonaContacto _fContacto;
        private Direccion _fDireccion;
        private Documento _fDocumento;
        private DocumentoItem _fDocumentoItem;
        private Identificacion _fIdentificacion;
        private Persona _fInterviniente;
        private decimal _fParticipacion;
        private bool _fPrincipal;
        private Rol _fRol;

        public DocumentoInterviniente(Session session) : base(session)
        {
        }

        [Association(@"DocumentoIntervinienteReferencesDocumento")]
        public Documento Documento
        {
            get { return _fDocumento; }
            set { SetPropertyValue("Documento", ref _fDocumento, value); }
        }

        [Association(@"DocumentoIntervinienteReferencesDocumentoItem")]
        public DocumentoItem DocumentoItem
        {
            get { return _fDocumentoItem; }
            set { SetPropertyValue("DocumentoItem", ref _fDocumentoItem, value); }
        }

        [Association(@"DocumentoIntervinienteReferencesRol")]
        public Rol Rol
        {
            get { return _fRol; }
            set { SetPropertyValue("Rol", ref _fRol, value); }
        }

        public bool Principal
        {
            get { return _fPrincipal; }
            set { SetPropertyValue("Principal", ref _fPrincipal, value); }
        }

        public decimal Participacion
        {
            get { return _fParticipacion; }
            set { SetPropertyValue<decimal>("Participacion", ref _fParticipacion, value); }
        }

        public decimal ComisionPrimaTasa
        {
            get { return _fComisionPrimaTasa; }
            set { SetPropertyValue<decimal>("ComisionPrimaTasa", ref _fComisionPrimaTasa, value); }
        }

        public decimal ComisionCobranzaTasa
        {
            get { return _fComisionCobranzaTasa; }
            set { SetPropertyValue<decimal>("ComisionCobranzaTasa", ref _fComisionCobranzaTasa, value); }
        }

        public Persona Interviniente
        {
            get { return _fInterviniente; }
            set { SetPropertyValue("Interviniente", ref _fInterviniente, value); }
        }

        public Direccion Direccion
        {
            get { return _fDireccion; }
            set { SetPropertyValue("Direccion", ref _fDireccion, value); }
        }

        public Identificacion Identificacion
        {
            get { return _fIdentificacion; }
            set { SetPropertyValue("Identificacion", ref _fIdentificacion, value); }
        }

        public PersonaContacto Contacto
        {
            get { return _fContacto; }
            set { SetPropertyValue("Contacto", ref _fContacto, value); }
        }
    }
}