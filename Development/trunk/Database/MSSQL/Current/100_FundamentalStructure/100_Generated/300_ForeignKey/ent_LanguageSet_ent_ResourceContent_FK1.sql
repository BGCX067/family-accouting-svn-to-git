ALTER TABLE [ent_ResourceContent]  WITH CHECK ADD  CONSTRAINT [ent_LanguageSet_ent_ResourceContent_FK1] FOREIGN KEY([LanguageSetID])
REFERENCES [ent_LanguageSet] ([ID])
GO
ALTER TABLE [ent_ResourceContent] CHECK CONSTRAINT [ent_LanguageSet_ent_ResourceContent_FK1]
GO
