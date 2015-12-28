SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE cspd_CreateEntry 
	@amout decimal(10, 2), 
	@debitAccountCode varchar(100),
	@creditAccountCode varchar(100),
	@groupID int = null
AS
BEGIN
	SET NOCOUNT ON;

	declare @debitAccountID int
	declare @creditAccountID int
	
	if @groupID is null
	begin
		insert into ent_EntityGroup ([OccurenceTimestamp]) values (getdate())
		select @groupID = scope_identity()
	end
	select @debitAccountID = ID from ent_Account where [Code] = @debitAccountCode
	select @creditAccountID = ID from ent_Account where [Code] = @creditAccountCode

	insert into ent_Entry ([Amount], [DebitAccountID], [CreditAccountID], [GroupID])
		values (@amout, @debitAccountCode, @creditAccountCode, @groupID)

END
GO
