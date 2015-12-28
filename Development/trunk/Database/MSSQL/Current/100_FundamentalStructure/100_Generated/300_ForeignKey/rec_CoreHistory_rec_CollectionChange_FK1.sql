ALTER TABLE [rec_CollectionChange]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_rec_CollectionChange_FK1] FOREIGN KEY([CoreHistoryID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [rec_CollectionChange] CHECK CONSTRAINT [rec_CoreHistory_rec_CollectionChange_FK1]
GO
