ALTER TABLE [rel_Table4_Table5_2]  WITH CHECK ADD  CONSTRAINT [ent_Table5_rel_Table4_Table5_2_FK1] FOREIGN KEY([Table5ID])
REFERENCES [ent_Table5] ([ID])
GO
ALTER TABLE [rel_Table4_Table5_2] CHECK CONSTRAINT [ent_Table5_rel_Table4_Table5_2_FK1]
GO
