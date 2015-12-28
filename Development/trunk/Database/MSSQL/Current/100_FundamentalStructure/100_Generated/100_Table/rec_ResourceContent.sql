SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rec_ResourceContent](
	[ID] [int] NOT NULL,
	[ResourceContentID] [int] NOT NULL,
	[LanguageSetID] [int] NULL,
	[ResourceKeyID] [int] NULL,
	[Content] [nvarchar](200) NULL
)

GO
