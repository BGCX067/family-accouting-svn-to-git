ALTER TABLE [rec_Table1]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_rec_Table1_FK1] FOREIGN KEY([ID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [rec_Table1] CHECK CONSTRAINT [rec_CoreHistory_rec_Table1_FK1]
GO
