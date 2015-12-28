SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_AddRoleToUser
		@userName nvarchar(100),
		@roleName nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON

	declare @userID int
	declare @roleID int

	select @userID = ent_User.ID from ent_User where ent_User.[Name] = @userName
	if (@userID is not null)
	begin
		select @roleID = ent_Role.ID from ent_Role where ent_Role.[Name] = @roleName
		if (not exists(select * from rel_User_Role where rel_User_Role.[RoleID] = @roleID and rel_User_Role.[UserID] = @userID))
		begin
			insert into rel_User_Role ([RoleID], [UserID])
				values (@roleID, @userID)
		end
	end
END



GO
