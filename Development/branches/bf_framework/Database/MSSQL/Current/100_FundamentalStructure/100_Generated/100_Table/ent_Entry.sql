SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ent_Entry](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[DebitAccountID] [int] NOT NULL,
	[CreditAccountID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
	[Comment] [nvarchar](2000) NULL
)

GO
