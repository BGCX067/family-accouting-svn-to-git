ALTER TABLE [rec_CollectionChange]  WITH CHECK ADD  CONSTRAINT [met_EntityProperty_rec_CollectionChange_FK1] FOREIGN KEY([EntityPropertyID])
REFERENCES [met_EntityProperty] ([ID])
GO
ALTER TABLE [rec_CollectionChange] CHECK CONSTRAINT [met_EntityProperty_rec_CollectionChange_FK1]
GO
