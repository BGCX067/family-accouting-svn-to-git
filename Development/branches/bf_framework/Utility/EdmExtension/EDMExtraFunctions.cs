using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Objects;
using System.Reflection;
using System.Data.EntityClient;
using System.Data;
using System.Linq;
using System.Data.Common;

namespace Wang.Velika.Utility.EdmExtension
{
    public static class EdmExtraFunctions
    {
        private static readonly BindingFlags nonPublicInstanceMemberFlag = BindingFlags.NonPublic | BindingFlags.Instance;


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

        public static T ExecuteScalarFunction<T>(this ObjectContext context, string functionImportName, EntityParameter[] parameters)
            where T : struct
        {
            if (functionImportName == null)
            {
                throw new ArgumentNullException("functionName");
            }

            EntityCommand cmd = (EntityCommand)context.Connection.CreateCommand();
            cmd.CommandText = context.DefaultContainerName + "." + functionImportName;
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


        public static ObjectQuery<T> Clone<T>(this ObjectQuery<T> query)
        {
            //TODO: To handle parameters.
            return query.Context.CreateQuery<T>(query.CommandText);
        }


        private static ObjectQuery<T> Join<T>(this ObjectQuery<T> query, ObjectQuery<DbDataRecord> tatget, string key)
        {
            ObjectQuery<T> ret = query;
            if ((tatget != null) && !String.IsNullOrEmpty(key))
            {
                if (String.Equals(query.Name, tatget.Name, StringComparison.OrdinalIgnoreCase))
                {
                    tatget.Name += "_join";
                }
                string cmd = String.Format("SELECT VALUE {1} FROM ({0}) AS {1} INNER JOIN ({2}) AS {3} ON {1}.{4} = {3}.{4}", query.CommandText, query.Name, tatget.CommandText, tatget.Name, key);
                ret = query.Context.CreateQuery<T>(cmd);
            }

            return ret;
        }

        private static ObjectQuery Build<T>(this ObjectQuery<T> query, EntitySQLQueryWrapper items, bool forTotalCount)
        {
            ObjectQuery ret = null;
            ObjectQuery<T> resultQuery = query;
            if (items != null)
            {
                string filters = items.BuildFilterSegment(resultQuery.Name);
                if (!String.IsNullOrEmpty(filters))
                {
                    resultQuery = resultQuery.Where(filters);
                }

                if (items.HasGroup)
                {
                    string groupProjection;
                    string groupKey = items.BuildGroupSegment(resultQuery.Name, out groupProjection);
                    ObjectQuery<DbDataRecord> interQuery = resultQuery.GroupBy(groupKey, groupProjection);
                    if (forTotalCount)
                    {
                        ret = interQuery;
                    }
                    else
                    {
                        interQuery = interQuery.BuildSort(items, true);
                        interQuery = interQuery.Select(items.GroupBy.BuildEntitySQLSegment(interQuery.Name));
                        resultQuery = query.Join(interQuery, items.GroupBy.FieldName);
                    }
                }
                else if (forTotalCount)
                {
                    ret = resultQuery;
                }
                if (!forTotalCount)
                {
                    ret = resultQuery.BuildSort(items, !items.HasGroup);
                }
            }

            return ret;
        }

        private static ObjectQuery<T> BuildSort<T>(this ObjectQuery<T> query, EntitySQLQueryWrapper items, bool plusPaging)
        {
            ObjectQuery<T> ret = query;
            string sorts = items.BuildSortSegment(ret.Name);
            if (!String.IsNullOrEmpty(sorts))
            {
                if (plusPaging && (items.StartIndex.GetValueOrDefault() > 0))
                {
                    ret = ret.Skip(sorts, items.StartIndex.ToString());
                }
                else
                {
                    ret = ret.OrderBy(sorts);
                }
            }
            if (plusPaging && items.Count.HasValue)
            {
                ret = ret.Top(items.Count.ToString());
            }

            return ret;
        }

        public static int CalculateTotalCount<T>(this ObjectQuery<T> query, ISearchDataWrapper searchData)
        {
            int ret = 0;
            ObjectQuery qry = query.Build(EntitySQLQueryWrapper.BuildEntitySQLQueryWrapper(searchData), true);
            if (qry is ObjectQuery<T>)
            {
                ret = ((ObjectQuery<T>)qry).Count();
            }
            else
            {
                ret = ((ObjectQuery<DbDataRecord>)qry).Count();
            }

            return ret;
        }

        public static ObjectQuery<T> BuildForResult<T>(this ObjectQuery<T> query, ISearchDataWrapper searchData)
        {
            return (ObjectQuery<T>)query.Build(EntitySQLQueryWrapper.BuildEntitySQLQueryWrapper(searchData), false);
        }
    }
}
