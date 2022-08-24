CREATE PROCEDURE [dbo].[sp_GetOrderDetails]
AS
BEGIN
	SELECT * FROM [dbo].[OrderDetail]
END
GO

CREATE PROCEDURE [dbo].[sp_GetOrderDetailsById]
	@Id INT 
AS
BEGIN
	SELECT * FROM [dbo].[OrderDetail] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_GetOrderDetailsByProductId]
	@ProductId INT 
AS
BEGIN
	SELECT * FROM [dbo].[OrderDetail] WHERE ProductId = @ProductId
END
GO

CREATE PROCEDURE [dbo].[sp_GetOrderDetailsByOrderId]
	@OrderId INT 
AS
BEGIN
	SELECT * FROM [dbo].[OrderDetail] WHERE OrderId = @OrderId
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteOrderDetails]
	@Id INT 
AS
BEGIN
	DELETE FROM [dbo].[OrderDetail] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateOrderDetails]
	@Id INT,
	@OrderId INT,
	@ProductId INT, 
    @Quantity INT, 
    @UnitPrice FLOAT, 
    @Discount FLOAT
AS
BEGIN
	UPDATE [dbo].[OrderDetail] 
	SET 
		[OrderId] = @OrderId,
		[ProductId] = @ProductId,
		[Quantity] =  @Quantity,
		[UnitPrice] =  @UnitPrice,
		[Discount] =  @UnitPrice
	WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertOrderDetails]	
	@OrderId INT,
	@ProductId INT, 
    @Quantity INT, 
    @UnitPrice FLOAT, 
    @Discount FLOAT
AS
BEGIN
	INSERT INTO [dbo].[OrderDetail] 
	( 
		[OrderId],[ProductId],[Quantity] ,[UnitPrice],[Discount]
	)
	VALUES
	(
		@OrderId,@ProductId,@Quantity,@UnitPrice,@UnitPrice
	)	
END
GO
