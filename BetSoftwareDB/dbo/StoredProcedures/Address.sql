CREATE PROCEDURE [dbo].[sp_GetAddress]	
AS
BEGIN
	SELECT * FROM [dbo].[Address]
END
GO

CREATE PROCEDURE [dbo].[sp_GetAddressById]	
	@Id int
AS
BEGIN
	SELECT * FROM [dbo].[Address] where UserId = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_GetAddressByUserId]	
	@UserId int
AS
BEGIN
	SELECT * FROM [dbo].[Address] where UserId = @UserId
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteAddress]	
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[Address] where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateAddress]	
	@Id int,
	@UserID INT ,
	@Address1 [varchar](250),
	@Address2 [varchar](250),
	@Address3 [varchar](250),	
	@Country [varchar](100),
	@City [varchar](100),
	@Town [varchar](100),
	@AreaCode [varchar](20) 
AS
BEGIN
	UPDATE [dbo].[Address] 	
	SET 
		[UserID] = @UserID,
		[Address1] = @Address1,
		[Address2] = @Address2,
		[Address3] = @Address3,
		[Country] = @Country,
		[City] = @City,
		[Town] = @Town,
		[AreaCode] = @AreaCode	
	WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertAddress]	
	@UserID INT ,
	@Address1 [varchar](250),
	@Address2 [varchar](250),
	@Address3 [varchar](250),	
	@Country [varchar](100),
	@City [varchar](100),
	@Town [varchar](100),
	@AreaCode [varchar](20) 
AS
BEGIN
	INSERT INTO [dbo].[Address] 	
	( 
		[UserID],[Address1],[Address2],[Address3],[Country],[City],[Town],[AreaCode]
	)
	VALUES
	(
		@UserID,@Address1,@Address2,@Address3,@Country,@City,@Town,@AreaCode
	)	
END
GO

