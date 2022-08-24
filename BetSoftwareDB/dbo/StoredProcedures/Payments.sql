CREATE PROCEDURE [dbo].[sp_GetPayments]
AS
BEGIN
	SELECT * FROM [dbo].[Payment]
END
GO

CREATE PROCEDURE [dbo].[sp_GetPaymentsById]
    @Id INT
AS
BEGIN
	SELECT * FROM [dbo].[Payment] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_GetPaymentsByOrderId]
    @OrderId INT
AS
BEGIN
	SELECT * FROM [dbo].[Payment] WHERE OrderId = @OrderId
END
GO

CREATE PROCEDURE [dbo].[sp_GetPaymentsByPaymentId]
    @PaymentId INT
AS
BEGIN
	SELECT * FROM [dbo].[Payment] WHERE PaymentId = @PaymentId
END
GO

CREATE PROCEDURE [dbo].[sp_DeletePayments]
    @Id INT
AS
BEGIN
	DELETE FROM [dbo].[Payment] WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_UpdatePayments]
    @Id INT, 
    @OrderId INT, 
    @PaymentId INT, 
    @PaymentAmount FLOAT, 
    @PaymentDate DATE, 
    @CardNumber [varchar](10),
    @CardExpiryDate DATE, 
    @CardHolderName [varchar](100)

AS
BEGIN
	UPDATE [dbo].[Payment] 
    SET
        [OrderId] = @OrderId,
        [PaymentId] = @PaymentId,
        [PaymentAmount] = @PaymentAmount,
        [PaymentDate] = @PaymentDate,
        [CardNumber] = @CardNumber,
        [CardExpiryDate] = @CardExpiryDate,
        [CardHolderName] = @CardHolderName
    WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[sp_InsertPayments]  
    @OrderId INT, 
    @PaymentId INT, 
    @PaymentAmount FLOAT, 
    @PaymentDate DATE, 
    @CardNumber [varchar](10),
    @CardExpiryDate DATE, 
    @CardHolderName [varchar](100)

AS
BEGIN
	INSERT INTO [dbo].[Payment] 
    (
        [OrderId],[PaymentId],[PaymentAmount],[PaymentDate],[CardNumber],[CardExpiryDate],[CardHolderName]
    )
    VALUES
    (
        @OrderId, @PaymentId, @PaymentAmount, @PaymentDate, @CardNumber, @CardExpiryDate, @CardHolderName
    )   
END
GO

