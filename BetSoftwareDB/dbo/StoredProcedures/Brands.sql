CREATE PROCEDURE [dbo].[sp_GetBrands]
AS
BEGIN
	SELECT * FROM [dbo].[Brand]
END
GO

CREATE PROCEDURE [dbo].[sp_GetBrandsById]
	@Id int
AS
BEGIN
	SELECT * FROM [dbo].[Brand] where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteBrands]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[Brand] where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_UpdateBrands]
	@Id int,
	@BrandDescription [varchar](100)
AS
BEGIN
	UPDATE [dbo].[Brand] 
		SET [BrandDescription] = @BrandDescription
	where Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertBrands]	
	@BrandDescription [varchar](100)
AS
BEGIN
	INSERT INTO [dbo].[Brand]
	( [BrandDescription]) VALUES ( @BrandDescription)	
END
GO
