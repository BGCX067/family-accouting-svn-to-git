ALTER TABLE [rel_User_Role]  WITH CHECK ADD  CONSTRAINT [ent_User_rel_User_Role_FK1] FOREIGN KEY([UserID])
REFERENCES [ent_User] ([ID])
GO
ALTER TABLE [rel_User_Role] CHECK CONSTRAINT [ent_User_rel_User_Role_FK1]
GO
