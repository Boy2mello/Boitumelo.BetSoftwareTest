CREATE TABLE [dbo].[ShoppingCart]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [IsOrdered] BIT NULL, 
    [OrderId] INT NULL
)
