ALTER TABLE [ast_EntityHistoryRepresentation]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_ast_EntityHistoryRepresentation_FK1] FOREIGN KEY([CreationHistoryID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [ast_EntityHistoryRepresentation] CHECK CONSTRAINT [rec_CoreHistory_ast_EntityHistoryRepresentation_FK1]
GO
