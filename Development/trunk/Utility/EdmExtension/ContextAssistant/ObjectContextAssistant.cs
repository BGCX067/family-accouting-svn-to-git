using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Metadata.Edm;
using System.Data.Common;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Reflection;

namespace Wang.Velika.Utility.EdmExtension
{
    public class ObjectContextAssistant
    {
        private const string ENTITY_METADATA_PATH_SCHEMA = "res";
        private static readonly string[] ENTITY_METADATA_PATH_EXTENSIONS = new string[] { ".csdl", ".ssdl", ".msl" };


        private Dictionary<Type, MetadataWorkspace> metadatas;


        public ObjectContextAssistant()
        {
            this.metadatas = new Dictionary<Type, MetadataWorkspace>();
        }


        private MetadataWorkspace CheckRetrieveMetadata(Type t)
        {
            MetadataWorkspace ret;
            lock (this.metadatas)
            {
                if (!this.metadatas.TryGetValue(t, out ret))
                {
                    ret = new MetadataWorkspace(this.GenerateEntityMetadataPaths(t), new Assembly[] { t.Assembly });
                    this.metadatas.Add(t, ret);
                }
            }
            return ret;
        }

        public DbConnection CreateConnectionForContext(string providerName, string connString)
        {
            if (providerName == null)
            {
                throw new ArgumentNullException("providerName");
            }
            if (connString == null)
            {
                throw new ArgumentNullException("connString");
            }

            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            DbConnection ret = factory.CreateConnection();
            ret.ConnectionString = connString;

            return ret;
        }

        public TContext CreateEntityContext<TContext>(DbConnection connection, TimeSpan? timeout)
            where TContext : class
        {
            if (!typeof(TContext).IsSubclassOf(typeof(ObjectContext)))
            {
                throw new NotSupportedException();
            }
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            Type t = typeof(TContext);
            EntityConnection conn = this.GenerateEntityConnection(t, connection);
            ConstructorInfo ci = this.RetrieveConstructorOfContextForDbConnection(t);
            TContext ret = (TContext)ci.Invoke(new object[] {conn});
            if (timeout.HasValue)
            {
                (ret as ObjectContext).CommandTimeout = (int)timeout.Value.TotalSeconds;
            }

            return ret;
        }

        private EntityConnection GenerateEntityConnection(Type t, DbConnection connection)
        {
            MetadataWorkspace mw = this.CheckRetrieveMetadata(t);
            return new EntityConnection(mw, connection);
        }

        private IEnumerable<string> GenerateEntityMetadataPaths(Type t)
        {
            List<string> ret = new List<string>();
            string assemblyName = t.Assembly.FullName;
            ObjectContextMetadataMappingAttribute attr = ObjectContextMetadataMappingAttribute.RetrieveAttribute(t);
            string modelName = (attr == null ? t.Name : attr.ResourceName);
            foreach (string ext in ENTITY_METADATA_PATH_EXTENSIONS)
            {
                UriBuilder ub = new UriBuilder();
                ub.Scheme = ENTITY_METADATA_PATH_SCHEMA;
                ub.Host = assemblyName;
                ub.Path = modelName + ext;
                ret.Add(ub.ToString());
            }

            return ret;
        }

        private ConstructorInfo RetrieveConstructorOfContextForDbConnection(Type t)
        {
            ConstructorInfo ret = t.GetConstructor(new Type[] { typeof(EntityConnection) });
            if (ret == null)
            {
                throw new InvalidOperationException(String.Format(Resources.Culture, Resources._Exception_Context_NoConstructor_DbConnection, t.AssemblyQualifiedName));
            }

            return ret;
        }
    }
}
