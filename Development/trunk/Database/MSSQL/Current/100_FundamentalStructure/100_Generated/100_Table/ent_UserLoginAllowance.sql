SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ent_UserLoginAllowance](
	[UserID] [int] NOT NULL,
	[LoginType] [tinyint] NOT NULL,
	[Password] [nvarchar](1000) NULL,
	[IsActive] [bit] NOT NULL
)

GO
