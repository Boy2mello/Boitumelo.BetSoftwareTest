CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ShippingMethodId] INT NOT NULL, 
    [SalesPersonId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [OrderDate] DATE NOT NULL, 
  
	
)
