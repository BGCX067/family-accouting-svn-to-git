SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ast_EntityHistoryRepresentation](
	[EntityTypeID] [int] NOT NULL,
	[EntityID] [int] NOT NULL,
	[CreatorID] [int] NULL,
	[CreatorName] [nvarchar](200) NULL,
	[CreationTimestamp] [datetime] NULL,
	[CreationHistoryID] [int] NULL,
	[LatestModifierID] [int] NULL,
	[LatestModifierName] [nvarchar](200) NULL,
	[LatestModificationTimestamp] [datetime] NULL,
	[LatestModificationHistoryID] [int] NULL,
	[LastToucherID] [int] NULL,
	[LastToucherName] [nvarchar](200) NULL,
	[LastTouchTimestamp] [datetime] NULL,
	[LastTouchHistoryID] [int] NULL
)

GO
