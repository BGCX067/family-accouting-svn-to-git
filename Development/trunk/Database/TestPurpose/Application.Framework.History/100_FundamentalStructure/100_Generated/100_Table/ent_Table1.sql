SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ent_Table1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyInt] [int] NOT NULL,
	[PropertyString] [nvarchar](100) NULL,
	[PropertyDatetime] [datetime] NULL
)

GO
