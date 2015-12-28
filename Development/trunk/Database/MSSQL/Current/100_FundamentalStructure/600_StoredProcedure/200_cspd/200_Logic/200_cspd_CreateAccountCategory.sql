SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_CreateAccountCategory 
	@parentCategoryCode varchar(100), 
	@name nvarchar(100),
	@code varchar(100),
	@defaultDirection tinyint = null,
	@description nvarchar(2000) = null
AS
BEGIN
	SET NOCOUNT ON;

	declare @parentCategoryID int
	select @parentCategoryID = [ID], @defaultDirection = isnull(@defaultDirection, [DefaultDirection])
		from [ent_AccountCategory]
		where [Code] = @parentCategoryCode
	insert into [ent_AccountCategory] ([ParentCategoryID], [Name], [Code], [DefaultDirection], [Description])
		values (@parentCategoryID, @name, @code, @defaultDirection, @description)
END
GO
