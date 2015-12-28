ALTER TABLE [met_EntityProperty]  WITH CHECK ADD  CONSTRAINT [met_EntityType_met_EntityProperty_FK2] FOREIGN KEY([TargetEntityTypeID])
REFERENCES [met_EntityType] ([ID])
GO
ALTER TABLE [met_EntityProperty] CHECK CONSTRAINT [met_EntityType_met_EntityProperty_FK2]
GO
