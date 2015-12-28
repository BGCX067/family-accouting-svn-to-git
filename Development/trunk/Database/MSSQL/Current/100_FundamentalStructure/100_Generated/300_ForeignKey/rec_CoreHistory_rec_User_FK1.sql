ALTER TABLE [rec_User]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_rec_User_FK1] FOREIGN KEY([ID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [rec_User] CHECK CONSTRAINT [rec_CoreHistory_rec_User_FK1]
GO
