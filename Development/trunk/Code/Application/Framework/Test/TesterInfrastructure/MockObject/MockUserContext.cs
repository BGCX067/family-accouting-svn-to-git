using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure
{
    public class MockUserContext : IUserContext
    {
        public virtual int? UserIdentifier { get; set; }
        public virtual int? AuthorityIdentifier { get; set; }
        public virtual bool RunAsSuper { get; set; }

        #region IUserContext Members

        int? IUserContext.UserIdentifier
        {
            get
            {
                return this.UserIdentifier;
            }
        }

        int? IUserContext.AuthorityIdentifier
        {
            get
            {
                return this.AuthorityIdentifier;
            }
        }

        bool IUserContext.RunAsSuper
        {
            get
            {
                return this.RunAsSuper;
            }
        }

        #endregion
    }
}
