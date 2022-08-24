CREATE PROCEDURE [dbo].[sp_GetShoppingCarts]
AS
BEGIN
	SELECT * FROM [dbo].[ShoppingCart]
END
GO

CREATE PROCEDURE [dbo].[sp_GetShoppingCartById]
@Id INT
AS
BEGIN
	SELECT * FROM [dbo].[ShoppingCart] where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_GetShoppingCartByUserId]
@UserId INT
AS
BEGIN
	SELECT * FROM [dbo].[ShoppingCart] where UserId = @UserId
END
GO

CREATE PROCEDURE [dbo].[sp_GetShoppingCartByOrderId]
@OrderId INT
AS
BEGIN
	SELECT * FROM [dbo].[ShoppingCart] where OrderId = @OrderId
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateShoppingCart]
    @Id INT, 
    @UserId INT, 
    @IsOrdered BIT, 
    @OrderId INT
AS
BEGIN
	UPDATE [dbo].[ShoppingCart]
		SET [Id] = @Id,
			[UserId] = @USerID, 
			[IsOrdered] = @IsOrdered, 
			[OrderId] = @OrderId
	WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteShoppingCart]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[ShoppingCart]	
	WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertShoppingCart]	
	@UserId INT, 
    @IsOrdered BIT, 
    @OrderId INT
AS
BEGIN
	INSERT INTO [dbo].[ShoppingCart]
		([UserId] ,[IsOrdered] ,[OrderId] ) 
	VALUES 
		(@USerID, @IsOrdered,@OrderId)
END
GO

