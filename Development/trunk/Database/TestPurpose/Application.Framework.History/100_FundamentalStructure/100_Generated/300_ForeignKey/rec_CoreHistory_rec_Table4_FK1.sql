ALTER TABLE [rec_Table4]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_rec_Table4_FK1] FOREIGN KEY([ID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [rec_Table4] CHECK CONSTRAINT [rec_CoreHistory_rec_Table4_FK1]
GO
