ALTER TABLE [rel_PermissionSet_Permission]  WITH CHECK ADD  CONSTRAINT [met_PermissionSet_rel_PermissionSet_Permission_FK1] FOREIGN KEY([PermissionSetID])
REFERENCES [met_PermissionSet] ([ID])
GO
ALTER TABLE [rel_PermissionSet_Permission] CHECK CONSTRAINT [met_PermissionSet_rel_PermissionSet_Permission_FK1]
GO
