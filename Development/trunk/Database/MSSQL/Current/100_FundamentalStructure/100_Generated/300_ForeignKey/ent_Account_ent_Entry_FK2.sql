ALTER TABLE [ent_Entry]  WITH CHECK ADD  CONSTRAINT [ent_Account_ent_Entry_FK2] FOREIGN KEY([CreditAccountID])
REFERENCES [ent_Account] ([ID])
GO
ALTER TABLE [ent_Entry] CHECK CONSTRAINT [ent_Account_ent_Entry_FK2]
GO
