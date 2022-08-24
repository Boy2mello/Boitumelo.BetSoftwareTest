CREATE PROCEDURE [dbo].[sp_GetUserTypes]
AS
BEGIN
	SELECT * FROM [dbo].[UserType]
END
GO


CREATE PROCEDURE [dbo].[sp_GetUserTypesById]
	@Id int
AS
BEGIN
	SELECT * FROM [dbo].[UserType] where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteUserTypes]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[UserType] where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateUserTypes]
	@Id int,
	@UserType [varchar](250)
AS
BEGIN
	UPDATE [dbo].[UserType]
		SET [UserType] = @UserType
	where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertUserTypes]
	@UserType [varchar](250)
AS
BEGIN
	INSERT INTO [dbo].[UserType]
	( [UserType]) VALUES ( @UserType)	
END
GO

