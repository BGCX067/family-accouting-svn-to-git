SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [met_EntityProperty](
	[ID] [int] NOT NULL,
	[EntityTypeID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Required] [bit] NOT NULL,
	[TargetKind] [tinyint] NOT NULL,
	[ColumnName] [nvarchar](100) NULL,
	[EnumerationTypeID] [int] NULL,
	[TargetEntityTypeID] [int] NULL,
	[RelationshipName] [nvarchar](200) NULL,
	[OppositeEntityPropertyID] [int] NULL,
	[Comment] [nvarchar](2000) NULL
)

GO
