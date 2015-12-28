using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.Objects;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using Wang.Velika.Utility.EdmExtension;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure
{
    public class MockDBContext : IDBContext, IDisposable
    {
        private static ObjectContextAssistantWithConfig contextAssistant;


        static MockDBContext()
        {
            contextAssistant = new ObjectContextAssistantWithConfig(MockStateRepository.DatabaseInformation);
        }


        public virtual DbConnection Connection { get; private set; }


        public MockDBContext()
        {
            this.Connection = contextAssistant.CreateConnectionForContext();
        }


        public virtual TContext RetrieveContext<TContext>()
            where TContext : class
        {
            return contextAssistant.CreateEntityContext<TContext>(this.Connection);
        }

        protected virtual void Dispose()
        {
            if (this.Connection != null)
            {
                this.Connection.Dispose();
                this.Connection = null;
            }
        }


        #region IDBContext Members

        DbConnection IDBContext.Connection
        {
            get
            {
                return this.Connection;
            }
        }

        TContext IDBContext.RetrieveContext<TContext>()
        {
            return this.RetrieveContext<TContext>();
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        #endregion
    }
}
