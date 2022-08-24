CREATE PROCEDURE [dbo].[sp_GetProducts]	
AS
BEGIN
	SELECT * FROM [dbo].[Product]
END
GO

CREATE PROCEDURE [dbo].[sp_GetProductsById]	
	@Id INT
AS
BEGIN
	SELECT * FROM [dbo].[Product] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_GetProductsBrandId]	
@BrandId INT
AS
BEGIN
	SELECT * FROM [dbo].[Product] WHERE BrandId = @BrandId
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteProducts]	
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Product] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateProducts]	
	@Id INT,	
	@BrandId int,
	@ProductName [varchar](100)
AS
BEGIN
	UPDATE [dbo].[Product] 
    SET
        [BrandId] = @BrandId,
        [ProductName] = @ProductName       
    WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertProducts]	
	@BrandId int,
	@ProductName [varchar](100)
AS
BEGIN
	INSERT INTO [dbo].[Product] 
    (
        [BrandId] ,[ProductName]
    )
    VALUES
    (
        @BrandId,@ProductName
    )   
END
GO

