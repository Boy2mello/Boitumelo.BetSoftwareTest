CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL,
	[Address1] [varchar](250) NOT NULL,
	[Address2] [varchar](250) NULL,
	[Address3] [varchar](250) NULL,	
	[Country] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[Town] [varchar](100) NULL,
	[AreaCode] [varchar](20) NULL
)
