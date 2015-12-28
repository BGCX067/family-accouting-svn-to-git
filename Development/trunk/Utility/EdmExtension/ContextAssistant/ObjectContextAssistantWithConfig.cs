using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Wang.Velika.Utility.EdmExtension
{
    public class ObjectContextAssistantWithConfig
    {
        private DatabaseInformationSection config;

        private ObjectContextAssistant assistant;


        public ObjectContextAssistantWithConfig(DatabaseInformationSection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            this.config = config;
            this.assistant = new ObjectContextAssistant();
        }


        public DbConnection CreateConnectionForContext()
        {
            return this.assistant.CreateConnectionForContext(this.config.Provider, this.config.ConnectionString);
        }

        public TContext CreateEntityContext<TContext>(DbConnection connection)
            where TContext : class
        {
            return this.assistant.CreateEntityContext<TContext>(connection, this.config.Timeout);
        }
    }
}
