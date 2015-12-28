ALTER TABLE [rel_Role_PermissionSet]  WITH CHECK ADD  CONSTRAINT [met_PermissionSet_rel_Role_PermissionSet_FK1] FOREIGN KEY([PermissionSetID])
REFERENCES [met_PermissionSet] ([ID])
GO
ALTER TABLE [rel_Role_PermissionSet] CHECK CONSTRAINT [met_PermissionSet_rel_Role_PermissionSet_FK1]
GO
