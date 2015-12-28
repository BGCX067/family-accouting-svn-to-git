SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rec_UserLoginAllowance](
	[ID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[LoginType] [tinyint] NULL,
	[Password] [nvarchar](1000) NULL,
	[IsActive] [bit] NULL
)

GO
