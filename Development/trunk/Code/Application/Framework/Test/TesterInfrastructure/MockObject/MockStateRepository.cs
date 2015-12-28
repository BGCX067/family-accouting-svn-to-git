using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using System.Runtime.Remoting.Messaging;
using Wang.Velika.Utility.EdmExtension;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure
{
    public class MockStateRepository : IStateRepository
    {
        public static MockStateRepository CurrentInstance
        {
            get
            {
                return (MockStateRepository)InformationCenter.States;
            }
        }

        public static DatabaseInformationSection DatabaseInformation { get; internal set; }


        public virtual MockLanguageContext LanguageInfo { get; set; }

        public virtual MockUserContext UserInfo { get; set; }

        public virtual MockTransactionContext TransactionInfo { get; set; }


        public MockStateRepository()
        {
            this.UserInfo = new MockUserContext();
            this.LanguageInfo = new MockLanguageContext();
            this.TransactionInfo = new MockTransactionContext();
        }


        #region IStateRepository Members

        IUserContext IStateRepository.UserInfo
        {
            get
            {
                return this.UserInfo;
            }
        }

        ILanguageContext IStateRepository.LanguageInfo
        {
            get
            {
                return this.LanguageInfo;
            }
        }

        ITransactionContext IStateRepository.TransactionInfo
        {
            get
            {
                return this.TransactionInfo;
            }
        }

        IDBContext IStateRepository.DBInfo
        {
            get
            {
                MockDBContext ret = (MockDBContext)CallContext.GetData("DBContext");
                if (ret == null)
                {
                    ret = new MockDBContext();
                    CallContext.SetData("DBContext", ret);
                }

                return ret;
            }
        }

        #endregion

        #region IStateRepository Members


        public IDictionary<string, IDBContext> DBInfoPool
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
