SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ent_EntryGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OccurrenceTimestamp] [datetime] NOT NULL,
	[Comment] [nvarchar](2000) NULL
)

GO
