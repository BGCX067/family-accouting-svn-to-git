ALTER TABLE [ast_EntityHistoryRepresentation]  WITH CHECK ADD  CONSTRAINT [met_EntityType_ast_EntityHistoryRepresentation_FK1] FOREIGN KEY([EntityTypeID])
REFERENCES [met_EntityType] ([ID])
GO
ALTER TABLE [ast_EntityHistoryRepresentation] CHECK CONSTRAINT [met_EntityType_ast_EntityHistoryRepresentation_FK1]
GO
