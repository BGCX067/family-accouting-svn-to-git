ALTER TABLE [rec_CoreHistory]  WITH CHECK ADD  CONSTRAINT [rec_ApplicationTransaction_rec_CoreHistory_FK1] FOREIGN KEY([ApplicationTransactionID])
REFERENCES [rec_ApplicationTransaction] ([ID])
GO
ALTER TABLE [rec_CoreHistory] CHECK CONSTRAINT [rec_ApplicationTransaction_rec_CoreHistory_FK1]
GO
