SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ent_ResourceContent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageSetID] [int] NOT NULL,
	[ResourceKeyID] [int] NOT NULL,
	[Content] [nvarchar](200) NOT NULL
)

GO
