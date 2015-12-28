using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Wang.Velika.Utility.EdmExtension
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ObjectContextMetadataMappingAttribute : Attribute
    {
        public string ResourceName { get; set; }

        public ObjectContextMetadataMappingAttribute(string resourceName)
        {
            this.ResourceName = resourceName;
        }

        public static ObjectContextMetadataMappingAttribute RetrieveAttribute(Type t)
        {
            return (ObjectContextMetadataMappingAttribute)Attribute.GetCustomAttribute(t, typeof(ObjectContextMetadataMappingAttribute));
        }

        public static ObjectContextMetadataMappingAttribute RetrieveAttribute<T>()
            where T : ObjectContext
        {
            return RetrieveAttribute(typeof(T));
        }
    }
}
