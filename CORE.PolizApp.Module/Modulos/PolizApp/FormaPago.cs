﻿using CORE.PolizApp.Sistema;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace CORE.PolizApp.PolizApp
{
    [DefaultClassOptions]
    [Persistent(@"polizapp.FormaPago")]
    [DefaultProperty("Codigo")]

    public class FormaPago : BasicObject
    {
        private string _fCodigo;
        private string _fNombre;
        private int _forden;
        private string _fsmartixId;

        public FormaPago(Session session) : base(session)
        {
        }

        [Size(50)]
        public string Codigo
        {
            get { return _fCodigo; }
            set { SetPropertyValue("Codigo", ref _fCodigo, value); }
        }

        [Size(50)]
        public string Nombre
        {
            get { return _fNombre; }
            set { SetPropertyValue("Nombre", ref _fNombre, value); }
        }

        public int Orden
        {
            get { return _forden; }
            set { SetPropertyValue<int>("orden", ref _forden, value); }
        }

        [Size(10)]
        [Persistent(@"smartix_Id")]
        public string SmartixId
        {
            get { return _fsmartixId; }
            set { SetPropertyValue("SmartixId", ref _fsmartixId, value); }
        }

        //[Association(@"DocumentoReferencesFormaPago")]
        //public XPCollection<Documento> Documentos => GetCollection<Documento>("Documentos");
    }
}