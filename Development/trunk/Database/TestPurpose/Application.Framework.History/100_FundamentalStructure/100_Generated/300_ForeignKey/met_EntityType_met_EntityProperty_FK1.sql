ALTER TABLE [met_EntityProperty]  WITH CHECK ADD  CONSTRAINT [met_EntityType_met_EntityProperty_FK1] FOREIGN KEY([EntityTypeID])
REFERENCES [met_EntityType] ([ID])
GO
ALTER TABLE [met_EntityProperty] CHECK CONSTRAINT [met_EntityType_met_EntityProperty_FK1]
GO
