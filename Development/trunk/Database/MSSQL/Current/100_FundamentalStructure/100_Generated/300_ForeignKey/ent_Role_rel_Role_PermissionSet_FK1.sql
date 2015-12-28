ALTER TABLE [rel_Role_PermissionSet]  WITH CHECK ADD  CONSTRAINT [ent_Role_rel_Role_PermissionSet_FK1] FOREIGN KEY([RoleID])
REFERENCES [ent_Role] ([ID])
GO
ALTER TABLE [rel_Role_PermissionSet] CHECK CONSTRAINT [ent_Role_rel_Role_PermissionSet_FK1]
GO
