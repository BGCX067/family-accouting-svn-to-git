ALTER TABLE [rec_ResourceContent]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_rec_ResourceContent_FK1] FOREIGN KEY([ID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [rec_ResourceContent] CHECK CONSTRAINT [rec_CoreHistory_rec_ResourceContent_FK1]
GO
