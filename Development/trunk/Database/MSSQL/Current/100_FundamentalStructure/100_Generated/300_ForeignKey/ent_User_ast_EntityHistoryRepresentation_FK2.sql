ALTER TABLE [ast_EntityHistoryRepresentation]  WITH NOCHECK ADD  CONSTRAINT [ent_User_ast_EntityHistoryRepresentation_FK2] FOREIGN KEY([LatestModifierID])
REFERENCES [ent_User] ([ID])
GO
ALTER TABLE [ast_EntityHistoryRepresentation] NOCHECK CONSTRAINT [ent_User_ast_EntityHistoryRepresentation_FK2]
GO
