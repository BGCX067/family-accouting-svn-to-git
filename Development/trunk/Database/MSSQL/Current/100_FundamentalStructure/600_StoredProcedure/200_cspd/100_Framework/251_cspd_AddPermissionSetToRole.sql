SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_AddPermissionSetToRole
		@roleName nvarchar(100),
		@permissionSetName nvarchar(200),
		@builtIn bit = 0
AS
BEGIN
	SET NOCOUNT ON;

	if (not exists(select * from ent_Role where ent_Role.[Name] = @roleName))
	begin
		insert into ent_Role ([Name], [IsFixed]) values (@roleName, @builtIn)
	end

	insert into rel_Role_PermissionSet ([RoleID], [PermissionSetID])
		select r.ID, ps.ID
			from ent_Role r, met_PermissionSet ps
			where r.Name = @roleName
				and ps.Name = @permissionSetName
END



GO
