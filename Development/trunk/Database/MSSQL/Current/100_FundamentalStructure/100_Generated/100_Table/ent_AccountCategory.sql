SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ent_AccountCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentCategoryID] [int] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[DefaultDirection] [tinyint] NULL,
	[Description] [nvarchar](2000) NULL
)

GO
