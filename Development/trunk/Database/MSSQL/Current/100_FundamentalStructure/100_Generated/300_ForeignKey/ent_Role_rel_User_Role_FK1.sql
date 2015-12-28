ALTER TABLE [rel_User_Role]  WITH CHECK ADD  CONSTRAINT [ent_Role_rel_User_Role_FK1] FOREIGN KEY([RoleID])
REFERENCES [ent_Role] ([ID])
GO
ALTER TABLE [rel_User_Role] CHECK CONSTRAINT [ent_Role_rel_User_Role_FK1]
GO
