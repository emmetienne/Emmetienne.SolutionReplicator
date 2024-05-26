using System;

namespace Emmetienne.SolutionReplicator.Model
{
    public class AdditionalComponentFieldForComparison
    {
        public string FieldName { get; set; }  
        public Type FieldType { get; set; }

        public static AdditionalComponentFieldForComparison Create(string fieldName, Type fieldType)
        {
            return new AdditionalComponentFieldForComparison
            {
                FieldName = fieldName,
                FieldType = fieldType
            };
        }
    }
}
