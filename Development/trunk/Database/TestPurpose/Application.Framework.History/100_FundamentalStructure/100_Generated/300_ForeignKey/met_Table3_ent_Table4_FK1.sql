ALTER TABLE [ent_Table4]  WITH CHECK ADD  CONSTRAINT [met_Table3_ent_Table4_FK1] FOREIGN KEY([Table3ID])
REFERENCES [met_Table3] ([ID])
GO
ALTER TABLE [ent_Table4] CHECK CONSTRAINT [met_Table3_ent_Table4_FK1]
GO
