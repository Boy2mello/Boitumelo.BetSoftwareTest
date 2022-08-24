CREATE TABLE [dbo].[OrderDetail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[OrderId] INT NOT NULL ,
	[ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [UnitPrice] FLOAT NOT NULL, 
    [Discount] FLOAT NOT NULL ,
)
