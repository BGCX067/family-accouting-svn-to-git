ALTER TABLE [rel_Table4_Table5_2]  WITH CHECK ADD  CONSTRAINT [ent_Table4_rel_Table4_Table5_2_FK1] FOREIGN KEY([Table4ID])
REFERENCES [ent_Table4] ([ID])
GO
ALTER TABLE [rel_Table4_Table5_2] CHECK CONSTRAINT [ent_Table4_rel_Table4_Table5_2_FK1]
GO
