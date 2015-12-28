using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wang.Velika.FamilyAccounting.Application.Framework.EntityMetadata;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    public static class HistoryManager
    {
        public static ApplicationTransaction StartApplicationTransaction(string externalID, int? userID, string remoteEndPoint, string localEndPoint, string action, DateTime? beginTimestamp)
        {
            ApplicationTransaction ret = null;

            using (HistoryContext ctx = HistoryContext.CreateInstance())
            {
                ret = new ApplicationTransaction();
                ret.ExternalID = externalID;
                ret.UserID = userID;
                ret.RemoteEndPoint = remoteEndPoint;
                ret.LocalEndPoint = localEndPoint;
                ret.Action = action;
                if (!beginTimestamp.HasValue)
                {
                    beginTimestamp = DateTime.Now;
                }
                ret.BeginTimestamp = beginTimestamp;

                ctx.AddToApplicationTransactionSet(ret);
                ctx.SaveChanges();
            }

            return ret;
        }

        public static ApplicationTransaction FinishApplicationTransaction(int id, int? userID, DateTime? endTimestamp)
        {
            ApplicationTransaction ret = null;

            using (HistoryContext ctx = HistoryContext.CreateInstance())
            {
                ret = ctx.GetApplicationTransaction(id);
                if (ret == null)
                {
                    //TODO: throw.
                }
                if (userID.HasValue)
                {
                    ret.UserID = userID;
                }
                if (!endTimestamp.HasValue)
                {
                    endTimestamp = DateTime.Now;
                }
                ret.EndTimestamp = endTimestamp;

                ctx.SaveChanges();
            }

            return ret;
        }

        public static CoreHistory CreateCoreHistory(IEntityExtend entity, HistoryActionType action, DateTime? timestamp, DecorateCoreHistory decorate)
        {
            if (!InformationCenter.States.TransactionInfo.ApplicationTransactionIdentifier.HasValue)
            {
                //TODO: throw;
            }

            CoreHistory ret = null;
            ret = new CoreHistory();
            ret.ApplicationTransactionID = InformationCenter.States.TransactionInfo.ApplicationTransactionIdentifier.Value;
            ret.EntityTypeID = entity.EntityTypeID;
            ret.EntityID = entity.EntityID;
            ret.ActionType = action;
            if (!timestamp.HasValue)
            {
                timestamp = DateTime.Now;
            }
            ret.Timestamp = timestamp.Value;
            if (decorate != null)
            {
                decorate(ret);
            }

            using (HistoryContext ctx = HistoryContext.CreateInstance())
            {
                ctx.AddToCoreHistorySet(ret);
                ctx.SaveChanges();
            }

            return ret;
        }
    }
}
