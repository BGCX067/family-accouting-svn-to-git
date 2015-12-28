ALTER TABLE [rec_Login]  WITH NOCHECK ADD  CONSTRAINT [ent_User_rec_Login_FK1] FOREIGN KEY([UserID])
REFERENCES [ent_User] ([ID])
GO
ALTER TABLE [rec_Login] NOCHECK CONSTRAINT [ent_User_rec_Login_FK1]
GO
