ALTER TABLE [ast_EntityHistoryRepresentation]  WITH NOCHECK ADD  CONSTRAINT [ent_User_ast_EntityHistoryRepresentation_FK1] FOREIGN KEY([CreatorID])
REFERENCES [ent_User] ([ID])
GO
ALTER TABLE [ast_EntityHistoryRepresentation] NOCHECK CONSTRAINT [ent_User_ast_EntityHistoryRepresentation_FK1]
GO
