ALTER TABLE [ent_Account]  WITH CHECK ADD  CONSTRAINT [ent_AccountCategory_ent_Account_FK1] FOREIGN KEY([CategoryID])
REFERENCES [ent_AccountCategory] ([ID])
GO
ALTER TABLE [ent_Account] CHECK CONSTRAINT [ent_AccountCategory_ent_Account_FK1]
GO
