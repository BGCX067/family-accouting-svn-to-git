SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [met_EntityType](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[EntityFullTypeName] [nvarchar](200) NOT NULL,
	[EntityAssemblyName] [nvarchar](200) NOT NULL,
	[EntityTableName] [nvarchar](100) NOT NULL,
	[HistoryFullTypeName] [nvarchar](200) NULL,
	[HistoryAssemblyName] [nvarchar](200) NULL,
	[HistoryTableName] [nvarchar](100) NULL,
	[Comment] [nvarchar](2000) NULL
)

GO
