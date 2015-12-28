ALTER TABLE [met_EnumerationItem]  WITH CHECK ADD  CONSTRAINT [met_EnumerationType_met_EnumerationItem_FK1] FOREIGN KEY([EnumerationTypeID])
REFERENCES [met_EnumerationType] ([ID])
GO
ALTER TABLE [met_EnumerationItem] CHECK CONSTRAINT [met_EnumerationType_met_EnumerationItem_FK1]
GO
