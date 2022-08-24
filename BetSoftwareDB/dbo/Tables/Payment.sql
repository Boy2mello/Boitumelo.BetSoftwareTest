CREATE TABLE [dbo].[Payment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [PaymentId] INT NOT NULL, 
    [PaymentAmount] FLOAT NOT NULL, 
    [PaymentDate] DATETIME NOT NULL, 
    [CardNumber] [varchar](10) NOT NULL,
    [CardExpiryDate] DATE NOT NULL, 
    [CardHolderName] [varchar](100) NOT NULL,
)
