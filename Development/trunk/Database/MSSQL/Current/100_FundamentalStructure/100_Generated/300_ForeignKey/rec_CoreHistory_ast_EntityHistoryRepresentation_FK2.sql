ALTER TABLE [ast_EntityHistoryRepresentation]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_ast_EntityHistoryRepresentation_FK2] FOREIGN KEY([LatestModificationHistoryID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [ast_EntityHistoryRepresentation] CHECK CONSTRAINT [rec_CoreHistory_ast_EntityHistoryRepresentation_FK2]
GO
