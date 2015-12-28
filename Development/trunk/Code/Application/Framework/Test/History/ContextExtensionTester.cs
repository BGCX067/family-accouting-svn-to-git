using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data;
using Wang.Velika.FamilyAccounting.Application.Framework.Test.TesterInfrastructure;
using Wang.Velika.FamilyAccounting.Application.Framework.History;
using Wang.Velika.FamilyAccounting.Application.Framework.Core;
using System.Data.Objects;
using NUnit.Framework.Constraints;

namespace Wang.Velika.FamilyAccounting.Application.Framework.Test.History
{
    [TestFixture]
    public class ContextExtensionTester : FakeDBOperationTesterBase
    {
        [Test]
        public void TestSimpleActions()
        {
            // Create
            Table1 o = new Table1();
            o.PropertyDatetime = DateTime.Now;
            o.PropertyString = o.PropertyDatetime.ToString();
            o.PropertyInt = o.PropertyDatetime.Value.GetHashCode();
            DateTime dt01, dt02;
            using (TestHistoryContext ctx = TestHistoryContext.CreateInstance())
            {
                ctx.AddToTable1Set(o);
                dt01 = DateTime.Now;
                ctx.SaveChangesWithHistory();
                dt02 = DateTime.Now;
            }
            Table1 o0;
            using (TestHistoryContext ctx = TestHistoryContext.CreateInstance())
            {
                var temp = from t1 in ctx.Table1Set
                           where t1.ID == o.ID
                           select t1;
                o0 = temp.FirstOrDefault();
                Assert.IsNotNull(o0);
            }
            IList<CoreHistory> histories = o0.RetrieveCoreHistries();
            Assert.AreEqual(histories.Count, 1);
            this.AssertCoreHistoryCommon(histories[0], o0, HistoryActionType.Create, dt01, dt02);
            using (TestHistoryContext ctx = TestHistoryContext.CreateInstance())
            {
                int id = histories[0].ID;
                var list = from h in ctx.Table1HistorySet
                           where h.ID == id
                           select h;
                this.AssertTable1History(list, o0);
            }

            //Modify
            Table1 o1;
            DateTime dt11, dt12;
            using (TestHistoryContext ctx = TestHistoryContext.CreateInstance())
            {
                var temp = from t1 in ctx.Table1Set
                           where t1.ID == o0.ID
                           select t1;
                o1 = temp.FirstOrDefault();
                Assert.IsNotNull(o1);
                o1.PropertyString += "_m";
                dt11 = DateTime.Now;
                ctx.SaveChangesWithHistory();
                dt12 = DateTime.Now;
            }
            IList<CoreHistory> histories1 = o1.RetrieveCoreHistries();
            Assert.AreEqual(histories1.Count, 2);
            this.AssertCoreHistoryCommon(histories1[0], o1, HistoryActionType.Modify, dt11, dt12);
            this.AssertCoreHistoryCommon(histories1[1], o0, HistoryActionType.Create, dt01, dt02);
            using (TestHistoryContext ctx = TestHistoryContext.CreateInstance())
            {
                int id = histories1[0].ID;
                var list = from h in ctx.Table1HistorySet
                           where h.ID == id
                           select h;
                this.AssertTable1History(list, o1);
            }

            //Delete
            Table1 o2;
            DateTime dt21, dt22;
            using (TestHistoryContext ctx = TestHistoryContext.CreateInstance())
            {
                var temp = from t1 in ctx.Table1Set
                           where t1.ID == o0.ID
                           select t1;
                o2 = temp.FirstOrDefault();
                Assert.IsNotNull(o2);
                ctx.DeleteObject(o2);
                dt21 = DateTime.Now;
                ctx.SaveChangesWithHistory();
                dt22 = DateTime.Now;
            }
            IList<CoreHistory> histories2 = o2.RetrieveCoreHistries();
            Assert.AreEqual(histories2.Count, 3);
            this.AssertCoreHistoryCommon(histories2[0], o2, HistoryActionType.Delete, dt21, dt22);
            this.AssertCoreHistoryCommon(histories2[1], o1, HistoryActionType.Modify, dt11, dt12);
            this.AssertCoreHistoryCommon(histories2[2], o0, HistoryActionType.Create, dt01, dt02);
            using (TestHistoryContext ctx = TestHistoryContext.CreateInstance())
            {
                int id = histories2[0].ID;
                var list = from h in ctx.Table1HistorySet
                           where h.ID == id
                           select h;
                this.AssertTable1History(list, o2);
            }
        }


        private void AssertTable1History(IEnumerable<Table1History> list, Table1 ent)
        {
            List<Table1History> hists = new List<Table1History>(list);
            Assert.AreEqual(1, hists.Count);
            Table1History hist = hists[0];
            Assert.AreEqual(ent.ID, hist.Table1ID);
            Assert.AreEqual(ent.PropertyInt, hist.PropertyInt);
            Assert.AreEqual(ent.PropertyString, hist.PropertyString);
            Assert.AreEqual(ent.PropertyDatetime, hist.PropertyDatetime);
        }

        private void AssertCoreHistoryCommon(CoreHistory hist, IWithHistory ent, HistoryActionType action, DateTime dtLower, DateTime dtUpper)
        {
            Assert.AreEqual(InformationCenter.States.TransactionInfo.ApplicationTransactionIdentifier.Value, hist.ApplicationTransactionID);
            Assert.AreEqual(ent.EntityTypeID, hist.EntityTypeID);
            Assert.AreEqual(ent.EntityID, hist.EntityID);
            Assert.AreEqual(action, hist.ActionType);
            Assert.Greater(TimeSpan.FromSeconds(1), dtLower.Subtract(hist.Timestamp));
            Assert.Greater(TimeSpan.FromSeconds(1), hist.Timestamp.Subtract(dtUpper));
        }
        
        [Test]
        public void TestRelation()
        {
            Table1 t1 = new Table1();
            t1.PropertyInt = DateTime.Now.GetHashCode();
            Table2 t2 = new Table2();
            Table3 t3 = new Table3();
            t3.PropertyString = DateTime.Now.ToString();
            Table5 t5 = new Table5();
            Table5 tt5 = new Table5();
            Table4 t4 = new Table4();
            t4.DualTable1 = t1;
            t4.MonoTable2 = t2;
            t4.MetaTable3 = t3;
            t4.DualTable5s.Add(t5);
            t4.MonoTable5s.Add(tt5);
            using (TestHistoryContext ctx = TestHistoryContext.CreateInstance())
            {
                ctx.AddToTable4Set(t4);
                ctx.SaveChangesWithHistory();
            }
            IList<CoreHistory> chists_t1 = t1.RetrieveCoreHistries();
            IList<CoreHistory> chists_t2 = t2.RetrieveCoreHistries();
            IList<CoreHistory> chists_t4 = t4.RetrieveCoreHistries();
            IList<CoreHistory> chists_t5 = t5.RetrieveCoreHistries();
            IList<CoreHistory> chists_tt5 = tt5.RetrieveCoreHistries();
            Assert.AreEqual(1, chists_t1.Count);
            Assert.AreEqual(1, chists_t2.Count);
            Assert.AreEqual(1, chists_t4.Count);
            Assert.AreEqual(1, chists_t5.Count);
            Assert.AreEqual(1, chists_tt5.Count);
            Assert.AreEqual(0, chists_t1[0].CollectionChanges.Count);
            Assert.AreEqual(0, chists_t2[0].CollectionChanges.Count);
            Assert.AreEqual(0, chists_t5[0].CollectionChanges.Count);
            Assert.AreEqual(0, chists_tt5[0].CollectionChanges.Count);
            List<CollectionChange> cg_t4_1 = new List<CollectionChange>(chists_t4[0].CollectionChanges);
            this.AssertHasCollectionChange(cg_t4_1, 104, t4.ID, null, t1.ID);
            this.AssertHasCollectionChange(cg_t4_1, 402, t1.ID, null, null);
            this.AssertHasCollectionChange(cg_t4_1, 403, t2.ID, null, null);
            this.AssertHasCollectionChange(cg_t4_1, 404, t3.ID, null, null);
            this.AssertHasCollectionChange(cg_t4_1, 405, t4.ID, null, null);
            this.AssertHasCollectionChange(cg_t4_1, 406, tt5.ID, null, null);
            this.AssertHasCollectionChange(cg_t4_1, 502, t4.ID, null, t5.ID);
            Assert.AreEqual(0, chists_t4[0].CollectionChanges.Count);
        }

        private void AssertHasCollectionChange(List<CollectionChange> changes, int propID, int? estID, int? relID, int? exID)
        {
            CollectionChange change = null;
            foreach (CollectionChange cge in changes)
            {
                if (new EqualConstraint(propID).Matches(change.EntityPropertyID)
                    && new EqualConstraint(estID).Matches(change.EstablishedEntityID)
                    && new EqualConstraint(relID).Matches(change.ReleasedEntityID)
                    && new EqualConstraint(exID).Matches(change.ExtraSourceEntityID))
                {
                    change = cge;
                }
            }
            if (change == null)
            {
                Assert.Fail();
            }
            else
            {
                changes.Remove(change);
            }
        }
    }
}
