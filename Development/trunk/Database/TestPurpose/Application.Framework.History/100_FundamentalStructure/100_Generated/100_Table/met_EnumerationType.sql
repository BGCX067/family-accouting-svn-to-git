SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [met_EnumerationType](
	[ID] [int] NOT NULL,
	[FullTypeName] [nvarchar](200) NOT NULL,
	[AssemblyName] [nvarchar](200) NOT NULL,
	[IsFlag] [bit] NOT NULL,
	[Comment] [nvarchar](2000) NULL
)

GO
