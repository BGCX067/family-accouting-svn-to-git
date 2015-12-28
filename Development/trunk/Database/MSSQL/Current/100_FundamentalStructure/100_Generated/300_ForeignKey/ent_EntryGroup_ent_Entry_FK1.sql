ALTER TABLE [ent_Entry]  WITH CHECK ADD  CONSTRAINT [ent_EntryGroup_ent_Entry_FK1] FOREIGN KEY([GroupID])
REFERENCES [ent_EntryGroup] ([ID])
GO
ALTER TABLE [ent_Entry] CHECK CONSTRAINT [ent_EntryGroup_ent_Entry_FK1]
GO
