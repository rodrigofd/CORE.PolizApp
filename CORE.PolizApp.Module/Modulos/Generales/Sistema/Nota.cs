﻿using System;
using System.ComponentModel;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace CORE.PolizApp.Sistema
{
    [ImageName("sticky-note-pin")]
    [Persistent("sistema.Nota")]
    [DefaultProperty("")]
    public class Nota : XPObject
    {
        private string _fContenido;
        private DateTime _fFecha;

        public Nota(Session session) : base(session)
        {
        }

        [NonPersistent]
        [Browsable(false)]
        public BasicObject Originante
        {
            get
            {
                if (OriginanteKey <= 0 || OriginanteType == null)
                    return null;
                if (!OriginanteType.IsValidType)
                    return null;
                return (BasicObject) Session.GetObjectByKey(OriginanteType.TypeClassInfo, OriginanteKey);
            }
            set
            {
                if (value == null)
                {
                    OriginanteType = null;
                    OriginanteKey = null;
                }
                else if (Session.IsNewObject(value))
                {
                    throw new ArgumentException("No puede vincular con un objeto sin guardar.");
                }
                else
                {
                    OriginanteType = Session.GetObjectType(value);
                    OriginanteKey = (int) Session.GetKeyValue(value);
                }
                OnChanged();
            }
        }

        [RuleRequiredField]
        [Persistent]
        [Browsable(false)]
        public XPObjectType OriginanteType { get; set; }

        [Persistent]
        [Browsable(false)]
        public int? OriginanteKey { get; set; }

        [RuleRequiredField]
        [Index(0)]
        [ModelDefault("EditMask", "G")]
        [ModelDefault("DisplayFormat", "{0:G}")]
        public DateTime Fecha
        {
            get { return _fFecha; }
            set { SetPropertyValue<DateTime>("Fecha", ref _fFecha, value); }
        }

        [RuleRequiredField]
        [Index(1)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(SizeAttribute.Unlimited)]
        public string Contenido
        {
            get { return _fContenido; }
            set { SetPropertyValue("Contenido", ref _fContenido, value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            Fecha = DateTime.Now;
        }
    }
}