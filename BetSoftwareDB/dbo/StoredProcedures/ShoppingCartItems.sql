CREATE PROCEDURE [dbo].[sp_GetShoppingCartItems]
AS
BEGIN
	SELECT * FROM [dbo].[ShoppingCartItems]
END
GO

CREATE PROCEDURE [dbo].[sp_GetShoppingCartItemById]
	@Id int
AS
BEGIN
	SELECT * FROM [dbo].[ShoppingCartItems] where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteShoppingCartItem]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[ShoppingCartItems] where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_GetShoppingCartItemsByUserId]
	@UserId int
AS
BEGIN
	SELECT sci.* FROM [dbo].[ShoppingCartItems] sci
	inner join [dbo].[ShoppingCart] sc
	on sc.Id = sci.ShoppingCartId
	where sc.UserId = @UserId
END
GO



CREATE PROCEDURE [dbo].[sp_UpdateShoppingCartItem]
	@Id INT, 
    @ShoppingCartId  INT, 
    @ProductId INT 
AS
BEGIN
	UPDATE [dbo].[ShoppingCartItems]
		SET [ShoppingCartId] = @ShoppingCartId,
		[ProductId]= @ProductId
	where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertShoppingCartItem]	
	@ShoppingCartId  INT, 
    @ProductId INT 
AS
BEGIN
	INSERT INTO [dbo].[ShoppingCartItems]
	( [ShoppingCartId], [ProductId]) VALUES ( @ShoppingCartId,@ProductId )	
END
GO
