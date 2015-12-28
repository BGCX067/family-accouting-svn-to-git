ALTER TABLE [rec_Role]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_rec_Role_FK1] FOREIGN KEY([ID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [rec_Role] CHECK CONSTRAINT [rec_CoreHistory_rec_Role_FK1]
GO
