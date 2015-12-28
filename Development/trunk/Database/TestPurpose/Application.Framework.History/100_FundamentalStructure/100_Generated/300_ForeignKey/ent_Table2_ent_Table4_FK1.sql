ALTER TABLE [ent_Table4]  WITH CHECK ADD  CONSTRAINT [ent_Table2_ent_Table4_FK1] FOREIGN KEY([Table2ID])
REFERENCES [ent_Table2] ([ID])
GO
ALTER TABLE [ent_Table4] CHECK CONSTRAINT [ent_Table2_ent_Table4_FK1]
GO
