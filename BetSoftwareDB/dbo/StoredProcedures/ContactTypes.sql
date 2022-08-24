CREATE PROCEDURE [dbo].[sp_GetContactTypes]
AS
BEGIN
	SELECT * FROM [dbo].[ContactType]
END
GO

CREATE PROCEDURE [dbo].[sp_GetContactTypesById]
	@Id INT
AS
BEGIN
	SELECT * FROM [dbo].[ContactType] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateContactTypes]
	@Id INT,
	@ContactType [varchar](250) 
AS
BEGIN
	UPDATE [dbo].[ContactType] 
		SET  [ContactType] = @ContactType
	WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteContactTypes]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[ContactType] 	
	WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertContactTypes]	
	@ContactType [varchar](250) 
AS
BEGIN
	INSERT INTO [dbo].[ContactType] 
		(  [ContactType]) 
	VALUES 
		( @ContactType)
END
GO