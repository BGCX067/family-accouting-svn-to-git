SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_AddAllPermissionSetsToRole
		@roleName nvarchar(100),
		@builtIn bit = 0
AS
BEGIN
	SET NOCOUNT ON;

	declare @pname varchar(100)

	DECLARE pers CURSOR FOR
		SELECT met_PermissionSet.[Name]
			FROM met_PermissionSet
	OPEN pers

	FETCH NEXT FROM pers INTO @pname
	WHILE @@FETCH_STATUS = 0
	BEGIN
		exec cspd_AddPermissionSetToRole @roleName, @pname, @builtIn

		FETCH NEXT FROM pers INTO @pname
	END

	CLOSE pers
	DEALLOCATE pers
END



GO
