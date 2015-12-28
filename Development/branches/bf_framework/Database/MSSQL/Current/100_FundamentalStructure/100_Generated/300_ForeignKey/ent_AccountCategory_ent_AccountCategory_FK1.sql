ALTER TABLE [ent_AccountCategory]  WITH CHECK ADD  CONSTRAINT [ent_AccountCategory_ent_AccountCategory_FK1] FOREIGN KEY([ParentCategoryID])
REFERENCES [ent_AccountCategory] ([ID])
GO
ALTER TABLE [ent_AccountCategory] CHECK CONSTRAINT [ent_AccountCategory_ent_AccountCategory_FK1]
GO
