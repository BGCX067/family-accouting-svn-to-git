ALTER TABLE [rel_PermissionSet_Permission]  WITH CHECK ADD  CONSTRAINT [met_Permission_rel_PermissionSet_Permission_FK1] FOREIGN KEY([PermissionID])
REFERENCES [met_Permission] ([ID])
GO
ALTER TABLE [rel_PermissionSet_Permission] CHECK CONSTRAINT [met_Permission_rel_PermissionSet_Permission_FK1]
GO
