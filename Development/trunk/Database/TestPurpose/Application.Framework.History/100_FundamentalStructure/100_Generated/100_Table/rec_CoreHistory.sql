SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rec_CoreHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationTransactionID] [int] NOT NULL,
	[EntityTypeID] [int] NOT NULL,
	[ActionType] [tinyint] NOT NULL,
	[EntityID] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[Comment] [nvarchar](2000) NULL
)

GO
