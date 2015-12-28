ALTER TABLE [rec_ApplicationTransaction]  WITH NOCHECK ADD  CONSTRAINT [ent_Role_rec_ApplicationTransaction_FK1] FOREIGN KEY([RoleID])
REFERENCES [ent_Role] ([ID])
GO
ALTER TABLE [rec_ApplicationTransaction] NOCHECK CONSTRAINT [ent_Role_rec_ApplicationTransaction_FK1]
GO
