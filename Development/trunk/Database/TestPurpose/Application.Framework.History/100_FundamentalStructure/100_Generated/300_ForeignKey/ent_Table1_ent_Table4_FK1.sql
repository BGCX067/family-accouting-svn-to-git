ALTER TABLE [ent_Table4]  WITH CHECK ADD  CONSTRAINT [ent_Table1_ent_Table4_FK1] FOREIGN KEY([Table1ID])
REFERENCES [ent_Table1] ([ID])
GO
ALTER TABLE [ent_Table4] CHECK CONSTRAINT [ent_Table1_ent_Table4_FK1]
GO
