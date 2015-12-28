ALTER TABLE [rel_ResourceGroup_ResourceKey]  WITH CHECK ADD  CONSTRAINT [met_ResourceKey_rel_ResourceGroup_ResourceKey_FK1] FOREIGN KEY([ResourceKeyID])
REFERENCES [met_ResourceKey] ([ID])
GO
ALTER TABLE [rel_ResourceGroup_ResourceKey] CHECK CONSTRAINT [met_ResourceKey_rel_ResourceGroup_ResourceKey_FK1]
GO
