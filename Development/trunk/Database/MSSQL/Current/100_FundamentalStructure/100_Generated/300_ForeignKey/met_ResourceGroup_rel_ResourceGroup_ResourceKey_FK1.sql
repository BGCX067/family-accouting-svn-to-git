ALTER TABLE [rel_ResourceGroup_ResourceKey]  WITH CHECK ADD  CONSTRAINT [met_ResourceGroup_rel_ResourceGroup_ResourceKey_FK1] FOREIGN KEY([ResourceGroupID])
REFERENCES [met_ResourceGroup] ([ID])
GO
ALTER TABLE [rel_ResourceGroup_ResourceKey] CHECK CONSTRAINT [met_ResourceGroup_rel_ResourceGroup_ResourceKey_FK1]
GO
