ALTER TABLE [rec_CoreHistory]  WITH CHECK ADD  CONSTRAINT [met_EntityType_rec_CoreHistory_FK1] FOREIGN KEY([EntityTypeID])
REFERENCES [met_EntityType] ([ID])
GO
ALTER TABLE [rec_CoreHistory] CHECK CONSTRAINT [met_EntityType_rec_CoreHistory_FK1]
GO
