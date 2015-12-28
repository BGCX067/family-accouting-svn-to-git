ALTER TABLE [rec_LanguageSet]  WITH CHECK ADD  CONSTRAINT [rec_CoreHistory_rec_LanguageSet_FK1] FOREIGN KEY([ID])
REFERENCES [rec_CoreHistory] ([ID])
GO
ALTER TABLE [rec_LanguageSet] CHECK CONSTRAINT [rec_CoreHistory_rec_LanguageSet_FK1]
GO
