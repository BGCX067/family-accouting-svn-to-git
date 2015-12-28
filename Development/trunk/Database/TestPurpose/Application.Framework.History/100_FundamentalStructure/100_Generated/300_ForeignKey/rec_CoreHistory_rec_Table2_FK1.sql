ALTER TABLE [rec_Table2]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_rec_Table2_FK1] FOREIGN KEY([ID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [rec_Table2] CHECK CONSTRAINT [rec_CoreHistory_rec_Table2_FK1]
GO
