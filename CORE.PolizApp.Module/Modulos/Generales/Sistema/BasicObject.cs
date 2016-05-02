using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace CORE.PolizApp.Sistema
{
    [Appearance("DetailViewBoldRule", AppearanceItemType = "ViewItem", TargetItems = "*", FontStyle = FontStyle.Bold, Context = "DetailView", Priority = 0)]
    [NonPersistent]
    [DefaultProperty("Descripcion")]
    public abstract class BasicObject : XPObject
    {
        private XPCollection<AuditDataItemPersistent> _auditTrail;
        private XPMemberInfo _defaultPropertyMemberInfo;
        private XPCollection<ArchivoAdjunto> _fArchivosAsociados;
        private XPCollection<Nota> _fNotas;
        private XPCollection<Vinculo> _fVinculos;
        [NonPersistent] [Browsable(false)] public bool IgnoreOnChanged;
        private bool _isDefaultPropertyAttributeInit;
        protected Dictionary<string, int> TempKeys = new Dictionary<string, int>();

        protected BasicObject()
        {
        }

        protected BasicObject(Session session)
            : base(session)
        {
        }

        [NonPersistent]
        [Browsable(false)]
        public bool CanRaiseOnChanged => !IsLoading && !IsSaving && !IgnoreOnChanged;

        [Browsable(false)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [ModelDefault("ImageSizeMode", "Normal")]
        [ModelDefault("Caption", " ")]
        public virtual Image Icono => null;

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [DevExpress.Xpo.Aggregated]
        [CollectionOperationSet(AllowAdd = true, AllowRemove = true)]
        public XPCollection<Nota> Anotaciones
        {
            get
            {
                if (_fNotas == null)
                {
                    var criteria =
                        CriteriaOperator.Parse("OriginanteKey = " + Oid + " and OriginanteType.Oid = " +
                                               Session.GetObjectType(this).Oid);
                    _fNotas = new XPCollection<Nota>(Session, criteria);
                }
                return _fNotas;
            }
        }

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [DevExpress.Xpo.Aggregated]
        [CollectionOperationSet(AllowAdd = true, AllowRemove = true)]
        public XPCollection<ArchivoAdjunto> ArchivosAsociados
        {
            get
            {
                if (_fArchivosAsociados == null)
                {
                    var criteria =
                        CriteriaOperator.Parse("OriginanteKey = " + Oid + " and OriginanteType.Oid = " +
                                               Session.GetObjectType(this).Oid);
                    _fArchivosAsociados = new XPCollection<ArchivoAdjunto>(Session, criteria);
                }
                return _fArchivosAsociados;
            }
        }

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [DevExpress.Xpo.Aggregated]
        [CollectionOperationSet(AllowAdd = false, AllowRemove = true)]
        public XPCollection<Vinculo> Vinculos
        {
            get
            {
                if (_fVinculos == null)
                {
                    var criteria = GroupOperator.Combine(GroupOperatorType.Or,
                        CriteriaOperator.Parse("OriginanteKey = " + Oid + " and OriginanteType.Oid = " +
                                               Session.GetObjectType(this).Oid),
                        CriteriaOperator.Parse("DestinatarioKey = " + Oid + " and DestinatarioType.Oid = " +
                                               Session.GetObjectType(this).Oid));
                    _fVinculos = new XPCollection<Vinculo>(Session, criteria);
                }
                return _fVinculos;
            }
        }

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [System.ComponentModel.DisplayName(@"Auditoría")]
        public XPCollection<AuditDataItemPersistent> AuditTrail
            => _auditTrail ?? (_auditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this));

        protected override XPCollection<T> CreateCollection<T>(XPMemberInfo property)
        {
            //interceptar la creación de colecciones; para actuar ante cualquier A/B/M de los mismos (ids)
            var collection = base.CreateCollection<T>(property);
            collection.ListChanged += (o, args) => collection_ListChanged(o, args, property.Name);
            return collection;
        }

        private void collection_ListChanged(object sender, ListChangedEventArgs e, string collectionName)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                var tempKey = TempKeys.ContainsKey(collectionName) ? TempKeys[collectionName] : 0;

                tempKey--;

                var xpObject = ((IList) sender)[e.NewIndex] as XPObject;
                if (xpObject == null || xpObject.Oid != -1) return;

                xpObject.Oid = tempKey;
                TempKeys[collectionName] = tempKey;
            }
        }


        public void SetIgnoreOnChangedRecursive(bool ignoreOnChanged)
        {
            IgnoreOnChanged = ignoreOnChanged;

            foreach (
                var child in
                    ClassInfo.Members.Where(xpMemberInfo => xpMemberInfo.IsCollection && xpMemberInfo.IsAggregated)
                        .SelectMany(xpMemberInfo => ((IEnumerable) xpMemberInfo.GetValue(this)).Cast<BasicObject>()))
            {
                child.SetIgnoreOnChangedRecursive(ignoreOnChanged);
            }
        }

        public override string ToString()
        {
            if (!BaseObject.IsXpoProfiling)
            {
                if (!_isDefaultPropertyAttributeInit)
                {
                    var memberName = string.Empty;
                    var attribute1 =
                        XafTypesInfo.Instance.FindTypeInfo(GetType()).FindAttribute<XafDefaultPropertyAttribute>();
                    if (attribute1 != null)
                    {
                        memberName = attribute1.Name;
                    }
                    else
                    {
                        var attribute2 =
                            XafTypesInfo.Instance.FindTypeInfo(GetType()).FindAttribute<DefaultPropertyAttribute>();
                        if (attribute2 != null)
                            memberName = attribute2.Name;
                    }
                    if (!string.IsNullOrEmpty(memberName))
                        _defaultPropertyMemberInfo = ClassInfo.FindMember(memberName);
                    _isDefaultPropertyAttributeInit = true;
                }

                if (_defaultPropertyMemberInfo != null)
                {
                    var obj = _defaultPropertyMemberInfo.GetValue(this);
                    if (obj != null)
                        return obj.ToString();
                }
            }
            return base.ToString();
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            // Set las propiedades de tipo bool, el valor inicial a FALSE (el null lo maneja mal la pantalla)
            foreach (var mem in ClassInfo.Members.Where(mem => mem.MemberType == typeof (bool)))
                mem.SetValue(this, false);
        }

        public T GetParentObject<T>(T obj)
        {
            var nestedUow = Session as NestedUnitOfWork;
            if (nestedUow != null)
            {
                return nestedUow.GetParentObject(obj);
            }
            return obj;
        }
    }
}