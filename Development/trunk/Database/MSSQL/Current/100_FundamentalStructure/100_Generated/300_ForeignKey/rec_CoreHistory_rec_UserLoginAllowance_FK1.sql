ALTER TABLE [rec_UserLoginAllowance]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_rec_UserLoginAllowance_FK1] FOREIGN KEY([ID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [rec_UserLoginAllowance] CHECK CONSTRAINT [rec_CoreHistory_rec_UserLoginAllowance_FK1]
GO
