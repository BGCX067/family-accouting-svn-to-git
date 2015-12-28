CREATE UNIQUE NONCLUSTERED INDEX [met_EnumerationType_AK1] ON [met_EnumerationType] 
(
	[FullTypeName] ASC,
	[AssemblyName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
