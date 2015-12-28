ALTER TABLE [rec_Table5]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_rec_Table5_FK1] FOREIGN KEY([ID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [rec_Table5] CHECK CONSTRAINT [rec_CoreHistory_rec_Table5_FK1]
GO
