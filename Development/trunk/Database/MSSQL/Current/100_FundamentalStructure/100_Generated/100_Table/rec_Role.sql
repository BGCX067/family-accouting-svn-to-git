SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rec_Role](
	[ID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](2000) NULL,
	[IsFixed] [bit] NULL
)

GO
