using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.EntityClient;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.Utility.EdmExtension
{
    public static class ObjectContextExtensions
    {
        private static readonly BindingFlags nonPublicInstanceMemberFlag = BindingFlags.NonPublic | BindingFlags.Instance;
        private static readonly EntityState allAttached = EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged;


        internal static void EnsureConnection(this ObjectContext context)
        {
            MethodInfo mi = context.GetType().GetMethod("EnsureConnection", nonPublicInstanceMemberFlag);
            mi.Invoke(context, null);
        }

        internal static void ReleaseConnection(this ObjectContext context)
        {
            MethodInfo mi = context.GetType().GetMethod("ReleaseConnection", nonPublicInstanceMemberFlag);
            mi.Invoke(context, null);
        }

        public static T ExecuteScalarFunction<T>(this ObjectContext context, string functionName, EntityParameter[] parameters)
            where T : struct
        {
            if (functionName == null)
            {
                throw new ArgumentNullException("functionName");
            }

            EntityCommand cmd = (EntityCommand)context.Connection.CreateCommand();
            cmd.CommandText = context.DefaultContainerName + "." + functionName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (context.CommandTimeout.HasValue)
            {
                cmd.CommandTimeout = context.CommandTimeout.Value;
            }
            if (parameters != null)
            {
                foreach (EntityParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            T ret = default(T);
            context.EnsureConnection();
            try
            {
                object o = cmd.ExecuteScalar();
                ret = (T)Convert.ChangeType(o, typeof(T));
            }
            finally
            {
                context.ReleaseConnection();
            }

            return ret;
        }

        public static void DetachAllObjects(this ObjectContext context)
        {
            IEnumerable<ObjectStateEntry> entries = context.ObjectStateManager.GetObjectStateEntries(allAttached);
            foreach (ObjectStateEntry entry in entries)
            {
                if (!entry.IsRelationship)
                {
                    // If an entity is unchanged but detached, its entry will keep unchanged but entry.Entity is set null.
                    if (entry.Entity != null)
                    {
                        context.Detach(entry.Entity);
                    }
                }
                else
                {
                }
            }
        }
    }
}
