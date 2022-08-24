/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
 

 IF EXISTS (SELECT 1 FROM [dbo].Brand)
 BEGIN
	INSERT INTO [dbo].[Brand]	
	( [BrandDescription]) 
	VALUES	( 'Nike'),	
			( 'Puma'),
			( 'Polo'),
			( 'Adidas'),
			( 'Asics')
 END
 GO


 IF EXISTS (SELECT 1 FROM [dbo].[ContactType])
 BEGIN
 INSERT INTO [dbo].[ContactType] 
		(  [ContactType]) 
	VALUES 
		( 'Email'),
		( 'Mobile'),
		( 'Landline'),
		( 'Fax')
 END
 GO

  IF EXISTS (SELECT 1 FROM [dbo].[ShippingMethod])
 BEGIN
  INSERT INTO [dbo].[ShippingMethod] 
		(  [ShippingMethod]) 
	VALUES 
		( 'Real-Time'),
		( 'Local Shipping'),
		( 'International Shipping'),
		( 'Same Day Delivery'),
		( 'Overnight Delivery')
 END
 GO

  IF EXISTS (SELECT 1 FROM [dbo].[UserType])
 BEGIN
   INSERT INTO [dbo].[UserType] 
		(  [UserType]) 
	VALUES 
		( 'Employee'),
		( 'Customer')
		
 END
 GO
