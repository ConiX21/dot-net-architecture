CREATE TABLE [dbo].[Person]
(
	[IdPerson] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Lastname] VARCHAR(50) NOT NULL, 
    [Firstname] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(200) NULL, 
    [Zipcode] VARCHAR(5) NULL, 
    [City] VARCHAR(50) NULL, 
    [Email] VARCHAR(150) NOT NULL, 
    [Gender] CHAR NOT NULL 
)

GO

