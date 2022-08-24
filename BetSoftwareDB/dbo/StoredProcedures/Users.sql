CREATE PROCEDURE [dbo].[sp_GetUsers]
AS
BEGIN
	SELECT * FROM [dbo].[User]
END
GO

CREATE PROCEDURE [dbo].[sp_GetUsersById]
	@Id INT
AS
BEGIN
	SELECT * FROM [dbo].[User] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteUsers]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[User] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateUsers]
	@Id INT,
	@Title [varchar](10) ,
	@FirstName [varchar](50) ,
	@LastName [varchar](50) , 
    @DateOfBirth DATE 
AS
BEGIN
	UPDATE [dbo].[User]
	SET 		
		[Title] = @Title,
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[DateOfBirth] = @DateOfBirth	
	WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertUsers]	
	@Title [varchar](10) ,
	@FirstName [varchar](50) ,
	@LastName [varchar](50) , 
    @DateOfBirth DATE 
AS
BEGIN
	INSERT INTO [dbo].[User]
	( 		
		[Title],[FirstName],[LastName],[DateOfBirth] 		
	)
	VALUES
	(
		@Title,@FirstName,@LastName,@DateOfBirth		
	)
	
END
GO
