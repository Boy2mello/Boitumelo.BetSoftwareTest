CREATE TABLE [dbo].[ShoppingCartItems]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ShoppingCartId] INT NOT NULL, 
    [ProductId] INT NOT NULL
)
