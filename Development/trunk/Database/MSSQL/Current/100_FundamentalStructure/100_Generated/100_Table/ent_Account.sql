SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ent_Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[CommonDirection] [tinyint] NULL,
	[Balance] [decimal](12, 3) NOT NULL,
	[Description] [nvarchar](2000) NULL
)

GO
