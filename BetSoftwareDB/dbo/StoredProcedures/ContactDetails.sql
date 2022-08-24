CREATE PROCEDURE [dbo].[sp_GetContactDetails]	
AS
BEGIN
	SELECT * FROM [dbo].[ContactDetails]
END
GO

CREATE PROCEDURE [dbo].[sp_GetContactDetailsById]
	@Id INT
AS
BEGIN
	SELECT * FROM [dbo].[ContactDetails] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_GetContactDetailsByUserId]
	@UserId INT
AS
BEGIN
	SELECT * FROM [dbo].[ContactDetails] WHERE Id = @UserId
END
GO

CREATE PROCEDURE [dbo].[sp_GetContactDetailsByContact]
	@Contact [varchar](250)
AS
BEGIN
  SELECT cd.[Id]
      ,cd.[UserID]
      ,cd.[ContactTypeId]
      ,cd.[Contact]
  FROM [dbo].[ContactDetails] cd
  INNER JOIN [dbo].[ContactType] ct
  ON cd.ContactTypeId = ct.Id
  WHERE ct.ContactType = 'Email'
  AND cd.Contact = @Contact
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateContactDetails]
	@Id INT, 
    @UserID INT,
	@ContactTypeId INT,
	@Contact [varchar](250)  
AS
BEGIN
	UPDATE [dbo].[ContactDetails]
	SET 
		[UserID] = @UserID,
		[ContactTypeId] = @ContactTypeId,
		[Contact] = @Contact
	
	WHERE Id = @Id
END
GO


CREATE PROCEDURE [dbo].[sp_InsertContactDetails]
    @UserID INT,
	@ContactTypeId INT,
	@Contact [varchar](250)  
AS
BEGIN
	INSERT INTO [dbo].[ContactDetails]
	( 
		[UserID],[ContactTypeId],[Contact]
	)
	VALUES
	(	
		@UserID,@ContactTypeId,	@Contact  
	)
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteContactDetails]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[ContactDetails] WHERE Id = @ID
END
GO

