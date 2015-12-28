ALTER TABLE [met_EntityProperty]  WITH CHECK ADD  CONSTRAINT [met_EnumerationType_met_EntityProperty_FK1] FOREIGN KEY([EnumerationTypeID])
REFERENCES [met_EnumerationType] ([ID])
GO
ALTER TABLE [met_EntityProperty] CHECK CONSTRAINT [met_EnumerationType_met_EntityProperty_FK1]
GO
