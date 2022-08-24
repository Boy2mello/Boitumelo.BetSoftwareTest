CREATE PROCEDURE [dbo].[sp_GetShippingMethods]
AS
BEGIN
	SELECT * FROM [dbo].[ShippingMethod]
END
GO

CREATE PROCEDURE [dbo].[sp_GetShippingMethodsById]
	@Id int
AS
BEGIN
	SELECT * FROM [dbo].[ShippingMethod] where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteShippingMethods]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[ShippingMethod] where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateShippingMethods]
	@Id int,
	@ShippingMethod [varchar](100)
AS
BEGIN
	UPDATE [dbo].[ShippingMethod]
		SET [ShippingMethod] = @ShippingMethod
	where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertShippingMethods]
	@ShippingMethod [varchar](100)
AS
BEGIN
	INSERT INTO [dbo].[ShippingMethod]
	( [ShippingMethod]) VALUES ( @ShippingMethod)	
END
GO


