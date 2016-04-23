using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;

namespace CORE.General.Modulos.Util
{
    public static class XpoExtensions
    {
        public static void Empty<T>(this IEnumerable<T> collection) where T : XPBaseObject
        {
            collection.ToList().ForEach(item => { item.Delete(); });
        }
    }

    public class XPViewCollectionSource : CollectionSourceBase
    {
        private readonly CriteriaOperator fixedCriteria;
        private readonly Type objectType;
        private readonly IList<ViewProperty> properties;

        public XPViewCollectionSource(IObjectSpace objectSpace) : base(objectSpace)
        {
        }

        public XPViewCollectionSource(IObjectSpace objectSpace, Type objectType, IList<ViewProperty> properties,
            CriteriaOperator criteria)
            : this(objectSpace)
        {
            this.objectType = objectType;
            this.properties = properties;
            fixedCriteria = criteria;
        }

        public override ITypeInfo ObjectTypeInfo
        {
            get { return XafTypesInfo.Instance.FindTypeInfo(objectType); }
        }

        protected override object CreateCollection()
        {
            var xpv = new XPView(((XPObjectSpace) ObjectSpace).Session, objectType) {Criteria = fixedCriteria};
            xpv.Properties.AddRange(properties.ToArray());
            return xpv;
        }

        protected override void ApplyCriteriaCore(CriteriaOperator criteria)
        {
            ((XPView) originalCollection).Criteria = GroupOperator.Combine(GroupOperatorType.And, fixedCriteria,
                criteria);
        }
    }
}