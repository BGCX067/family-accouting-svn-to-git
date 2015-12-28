ALTER TABLE [ent_UserLoginAllowance]  WITH CHECK ADD  CONSTRAINT [ent_User_ent_UserLoginAllowance_FK1] FOREIGN KEY([UserID])
REFERENCES [ent_User] ([ID])
GO
ALTER TABLE [ent_UserLoginAllowance] CHECK CONSTRAINT [ent_User_ent_UserLoginAllowance_FK1]
GO
