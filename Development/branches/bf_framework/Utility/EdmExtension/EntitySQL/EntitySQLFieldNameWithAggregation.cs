using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wang.Velika.Utility.EdmExtension
{
    public class EntitySQLFieldNameWithAggregation
    {
        public string Name { get; set; }

        public string AggregationPattern { get; set; }



        public EntitySQLFieldNameWithAggregation(string name)
            : this(name, null)
        {
        }

        public EntitySQLFieldNameWithAggregation(string name, string aggregationPattern)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            this.Name = name;
            this.AggregationPattern = aggregationPattern;
        }


        public override bool Equals(object obj)
        {
            return ((obj is EntitySQLFieldNameWithAggregation) && String.Equals(((EntitySQLFieldNameWithAggregation)obj).Name, this.Name, StringComparison.OrdinalIgnoreCase));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
