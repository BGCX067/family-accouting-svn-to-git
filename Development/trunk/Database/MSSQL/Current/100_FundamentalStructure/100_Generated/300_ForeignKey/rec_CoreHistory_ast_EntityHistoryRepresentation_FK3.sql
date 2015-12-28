ALTER TABLE [ast_EntityHistoryRepresentation]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_ast_EntityHistoryRepresentation_FK3] FOREIGN KEY([LastTouchHistoryID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [ast_EntityHistoryRepresentation] CHECK CONSTRAINT [rec_CoreHistory_ast_EntityHistoryRepresentation_FK3]
GO
