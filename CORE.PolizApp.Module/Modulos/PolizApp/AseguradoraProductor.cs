using System;
using CORE.PolizApp.Personas;
using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.AseguradoraProductor")]
    [DefaultProperty("Productor")]

    public class AseguradoraProductor : BasicObject
    {
        private Aseguradora _fAseguradora;
        private string _fCodigo;
        private DateTime _fDesde;
        private DateTime _fHasta;
        private Persona _fProductor;

        public AseguradoraProductor(Session session) : base(session)
        {
        }

        [Association(@"AseguradoraProductorReferencesAseguradora")]
        public Aseguradora Aseguradora
        {
            get { return _fAseguradora; }
            set { SetPropertyValue("Aseguradora", ref _fAseguradora, value); }
        }

        public Persona Productor
        {
            get { return _fProductor; }
            set { SetPropertyValue<Persona>("Productor", ref _fProductor, value); }
        }

        [Size(50)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        public DateTime Desde
        {
            get { return _fDesde; }
            set { SetPropertyValue<DateTime>("Desde", ref _fDesde, value); }
        }

        public DateTime Hasta
        {
            get { return _fHasta; }
            set { SetPropertyValue<DateTime>("Hasta", ref _fHasta, value); }
        }

        //[Association(@"DocumentoReferencesAseguradoraProductor")]
        //public XPCollection<Documento> Documentos => GetCollection<Documento>("Documentos");
    }
}