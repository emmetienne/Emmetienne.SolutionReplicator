using System;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Model
{
    public class ComponentType
    {
        public string ComponentTypeName { get; set; }
        public int? TargetComponentTypeCode { get; set; }
        public string ComponentEntityLogicalName { get; set; }
        public string ComponentPrimaryFieldLogicalName { get; set; }
        public Type ComponentPrimaryFieldType { get; set; }
        public string ComponentPrimaryKeyLogicalName { get; set; }
        public List<AdditionalComponentFieldForComparison> AdditionalFieldsForComparisonList { get; set; }
        public List<string> NullFieldsForComparisonList { get; set; }
        public bool DoNotAddToSolution { get; set; } = false;
    }
}
