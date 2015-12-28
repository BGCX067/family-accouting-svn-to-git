ALTER TABLE [met_EntityProperty]  WITH CHECK ADD  CONSTRAINT [met_EntityProperty_met_EntityProperty_FK1] FOREIGN KEY([OppositeEntityPropertyID])
REFERENCES [met_EntityProperty] ([ID])
GO
ALTER TABLE [met_EntityProperty] CHECK CONSTRAINT [met_EntityProperty_met_EntityProperty_FK1]
GO
