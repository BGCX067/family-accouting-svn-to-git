SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_AddPermissionToSet
		@permissionSetName nvarchar(200),
		@permissionName nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON

	if (not exists(select * from met_PermissionSet where [Name] = @permissionSetName))
	begin
		insert into met_PermissionSet ([Name]) values(@permissionSetName)
	end

	insert into rel_PermissionSet_Permission ([PermissionSetID], [PermissionID])
		select ps.ID, p.ID
			from ent_PermissionSet ps, met_Permission p
			where ps.Name = @permissionSetName
				and p.Name = @permissionName
END



GO
