CREATE TABLE [dbo].[ContactDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NULL,
	[ContactTypeId] INT NULL,
	[Contact] [varchar](250) NULL
)
