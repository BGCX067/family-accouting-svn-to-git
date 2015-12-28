SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [met_EnumerationItem](
	[ID] [int] NOT NULL,
	[EnumerationTypeID] [int] NOT NULL,
	[Value] [tinyint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Comment] [nvarchar](2000) NULL
)

GO
