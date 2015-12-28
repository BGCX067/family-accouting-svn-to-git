SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_CreateAccount 
	@categoryCode varchar(100), 
	@name nvarchar(100),
	@code varchar(100),
	@commonDirection tinyint = null,
	@balance int = 0,
	@description nvarchar(2000) = null
AS
BEGIN
	SET NOCOUNT ON;

	declare @categoryID int
	select @categoryID = [ID], @commonDirection = isnull(@commonDirection, [DefaultDirection])
		from [ent_AccountCategory]
		where [Code] = @categoryCode
	insert into [ent_Account] ([CategoryID], [Name], [Code], [CommonDirection], [Balance], [Description])
		values (@categoryID, @name, @code, @commonDirection, @balance, @description)
END
GO
