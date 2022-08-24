CREATE PROCEDURE [dbo].[sp_GetOrders]
AS
BEGIN
	SELECT * FROM [dbo].[Order]
END
GO

CREATE PROCEDURE [dbo].[sp_GetOrdersById]
	@Id INT
AS
BEGIN
	SELECT * FROM [dbo].[Order] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_GetOrdersByShippingMethodId]
	@ShippingMethodId INT
AS
BEGIN
	SELECT * FROM [dbo].[Order]  WHERE ShippingMethodId = @ShippingMethodId
END
GO

CREATE PROCEDURE [dbo].[sp_GetOrdersBySalesPersonId]
	@SalesPersonId INT
AS
BEGIN
	SELECT * FROM [dbo].[Order]  WHERE SalesPersonId = @SalesPersonId
END
GO

CREATE PROCEDURE [dbo].[sp_GetOrdersByCustomerId]
	@CustomerId INT
AS
BEGIN
	SELECT * FROM [dbo].[Order]  WHERE CustomerId = @CustomerId
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteOrders]
	@Id INT
AS
BEGIN
	SELECT * FROM [dbo].[Order]  WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateOrders]
	@Id INT,
	@ShippingMethodId INT, 
    @SalesPersonId INT, 
    @CustomerId INT, 
    @OrderDate DATE
AS
BEGIN
	UPDATE [dbo].[Order]  
	SET	
		[ShippingMethodId] = @ShippingMethodId,
		[SalesPersonId] =  @SalesPersonId,
		[CustomerId] = @CustomerId,
		[OrderDate] = @OrderDate	
	WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertOrders]	
	@ShippingMethodId INT, 
    @SalesPersonId INT, 
    @CustomerId INT, 
    @OrderDate DATE
AS
BEGIN
	INSERT INTO [dbo].[Order]  
	(
		[ShippingMethodId],	[SalesPersonId],[CustomerId],[OrderDate]	
	)
	VALUES
	(
		@ShippingMethodId,@SalesPersonId,@CustomerId,@OrderDate	
	)	
END
GO
