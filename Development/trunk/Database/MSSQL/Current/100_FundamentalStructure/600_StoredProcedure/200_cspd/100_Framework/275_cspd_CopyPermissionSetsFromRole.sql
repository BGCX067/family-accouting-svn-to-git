SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_CopyPermissionSetsFromRole
		@targetRoleName nvarchar(100),
		@sourceRoleName nvarchar(100),
		@builtIn bit = 0
AS
BEGIN
	SET NOCOUNT ON;

	declare @psID int
	DECLARE pers CURSOR FOR
		select rel_Role_PermissionSet.[PermissionSetID]
			from ent_Role inner join rel_Role_PermissionSet
					on ent_Role.ID = rel_Role_PermissionSet.RoleID
			where ent_Role.[Name] = @sourceRoleName	
	OPEN pers

	FETCH NEXT FROM pers INTO @psID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		exec cspd_AddPermissionSetToRole @targetRoleName, @psID, @builtIn

		FETCH NEXT FROM pers INTO @psID
	END

	CLOSE pers
	DEALLOCATE pers
END
GO
