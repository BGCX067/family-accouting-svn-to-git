ALTER TABLE [ent_ResourceContent]  WITH CHECK ADD  CONSTRAINT [met_ResourceKey_ent_ResourceContent_FK1] FOREIGN KEY([ResourceKeyID])
REFERENCES [met_ResourceKey] ([ID])
GO
ALTER TABLE [ent_ResourceContent] CHECK CONSTRAINT [met_ResourceKey_ent_ResourceContent_FK1]
GO
