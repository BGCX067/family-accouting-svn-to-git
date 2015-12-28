SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_AddPermissionToSetByPattern
		@permissionSetName nvarchar(200),
		@permissionNamePattern nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON

	declare @pname varchar(100)
	DECLARE pers CURSOR FOR
		SELECT met_Permission.[Name]
			FROM met_Permission
			WHERE met_Permission.[Name] LIKE @permissionNamePattern
	OPEN pers

	FETCH NEXT FROM pers INTO @pname
	WHILE @@FETCH_STATUS = 0
	BEGIN
		exec cspd_AddPermissionToSet @permissionSetName, @pname

		FETCH NEXT FROM pers INTO @pname
	END

	CLOSE pers
	DEALLOCATE pers
END



GO
