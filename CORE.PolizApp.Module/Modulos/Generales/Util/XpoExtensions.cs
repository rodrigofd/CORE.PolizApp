﻿using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo; using DevExpress.Persistent.Base;

namespace CORE.General.Modulos.Util
{
    public static class XpoExtensions
    {
        public static void Empty<T>(this IEnumerable<T> collection) where T : XPBaseObject
        {
            collection.ToList().ForEach(item => { item.Delete(); });
        }
    }

    [DefaultClassOptions]
public class XPViewCollectionSource : CollectionSourceBase
    {
        private readonly CriteriaOperator _fixedCriteria;
        private readonly Type _objectType;
        private readonly IList<ViewProperty> _properties;

        public XPViewCollectionSource(IObjectSpace objectSpace) : base(objectSpace)
        {
        }

        public XPViewCollectionSource(IObjectSpace objectSpace, Type objectType, IList<ViewProperty> properties,
            CriteriaOperator criteria)
            : this(objectSpace)
        {
            this._objectType = objectType;
            this._properties = properties;
            _fixedCriteria = criteria;
        }

        public override ITypeInfo ObjectTypeInfo
        {
            get { return XafTypesInfo.Instance.FindTypeInfo(_objectType); }
        }

        protected override object CreateCollection()
        {
            var xpv = new XPView(((XPObjectSpace) ObjectSpace).Session, _objectType) {Criteria = _fixedCriteria};
            xpv.Properties.AddRange(_properties.ToArray());
            return xpv;
        }

        protected override void ApplyCriteriaCore(CriteriaOperator criteria)
        {
            ((XPView) originalCollection).Criteria = GroupOperator.Combine(GroupOperatorType.And, _fixedCriteria,
                criteria);
        }
    }
}