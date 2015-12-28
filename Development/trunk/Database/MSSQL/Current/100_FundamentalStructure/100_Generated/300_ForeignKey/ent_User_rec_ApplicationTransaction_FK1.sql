ALTER TABLE [rec_ApplicationTransaction]  WITH NOCHECK ADD  CONSTRAINT [ent_User_rec_ApplicationTransaction_FK1] FOREIGN KEY([UserID])
REFERENCES [ent_User] ([ID])
GO
ALTER TABLE [rec_ApplicationTransaction] NOCHECK CONSTRAINT [ent_User_rec_ApplicationTransaction_FK1]
GO
