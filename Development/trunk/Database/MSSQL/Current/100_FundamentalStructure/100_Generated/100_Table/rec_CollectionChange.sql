SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rec_CollectionChange](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CoreHistoryID] [int] NOT NULL,
	[EntityPropertyID] [int] NOT NULL,
	[ExtraSourceEntityID] [int] NULL,
	[EstablishedEntityID] [int] NULL,
	[ReleasedEntityID] [int] NULL
)

GO
