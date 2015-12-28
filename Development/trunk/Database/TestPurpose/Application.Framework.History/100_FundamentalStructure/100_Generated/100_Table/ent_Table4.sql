SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ent_Table4](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Table1ID] [int] NOT NULL,
	[Table2ID] [int] NULL,
	[PropertyString] [nvarchar](100) NULL,
	[Table3ID] [int] NOT NULL
)

GO
