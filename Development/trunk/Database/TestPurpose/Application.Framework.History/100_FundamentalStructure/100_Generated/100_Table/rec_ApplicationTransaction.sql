SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rec_ApplicationTransaction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExternalID] [nvarchar](200) NULL,
	[RemoteEndPoint] [nvarchar](1000) NULL,
	[LocalEndPoint] [nvarchar](1000) NULL,
	[Action] [nvarchar](1000) NULL,
	[UserID] [int] NULL,
	[RoleID] [int] NULL,
	[BeginTimestamp] [datetime] NULL,
	[EndTimestamp] [datetime] NULL
)

GO
