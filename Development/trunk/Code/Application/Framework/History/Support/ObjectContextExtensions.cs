using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    public static class ObjectContextExtensions
    {
        private static readonly EntityState allChanged = EntityState.Added | EntityState.Deleted | EntityState.Modified;


        private static void PrepareHistories<TContext>(this TContext ctx)
            where TContext : ObjectContext, IHistorySupport
        {
            if (!InformationCenter.States.TransactionInfo.ApplicationTransactionIdentifier.HasValue)
            {
                //TODO: throw
            }

            if (ctx.HistoryCache != null)
            {
                ctx.HistoryCache.Clear();
                IEnumerable<ObjectStateEntry> entries = ctx.ObjectStateManager.GetObjectStateEntries(allChanged);
                foreach (ObjectStateEntry entry in entries)
                {
                    if (entry.IsRelationship)
                    {
                        switch (entry.State)
                        {
                            case EntityState.Added:
                            case EntityState.Deleted:
                                ctx.HistoryCache.AddChangedRelation(entry);
                                break;
                        }
                    }
                    else if (((entry.Entity is EntityObject)) && (entry.Entity is IWithHistory))
                    {
                        switch (entry.State)
                        {
                            case EntityState.Added:
                            case EntityState.Modified:
                            case EntityState.Deleted:
                                ctx.HistoryCache.AddChangedEntity(entry.State, (EntityObject)entry.Entity);
                                break;
                        }
                    }
                }
            }
        }

        private static void PrepareHistoriesOnSavingChanges<TContext>(this TContext ctx, object sender, EventArgs e)
            where TContext : ObjectContext, IHistorySupport
        {
            ctx.PrepareHistories();
        }

        private static void SaveHistories<TContext>(this TContext ctx)
            where TContext : ObjectContext, IHistorySupport
        {
            if (ctx.HistoryCache != null)
            {
                ctx.HistoryCache.AddHistories(ctx);
                ctx.SaveChanges();
                ctx.HistoryCache.Clear();
            }
        }



        public static int SaveChangesWithHistory<TContext>(this TContext ctx)
            where TContext : ObjectContext, IHistorySupport
        {
            int ret = 0;
            try
            {
                ctx.SavingChanges += new EventHandler(ctx.PrepareHistoriesOnSavingChanges);
                ret = ctx.SaveChanges();
                ctx.SaveHistories();
            }
            finally
            {
                ctx.SavingChanges -= new EventHandler(ctx.PrepareHistoriesOnSavingChanges);
            }

            return ret;
        }
    }
}
