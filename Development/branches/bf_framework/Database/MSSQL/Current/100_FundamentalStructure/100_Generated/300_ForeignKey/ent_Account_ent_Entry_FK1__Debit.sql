ALTER TABLE [ent_Entry]  WITH CHECK ADD  CONSTRAINT [ent_Account_ent_Entry_FK1__Debit] FOREIGN KEY([DebitAccountID])
REFERENCES [ent_Account] ([ID])
GO
ALTER TABLE [ent_Entry] CHECK CONSTRAINT [ent_Account_ent_Entry_FK1__Debit]
GO
