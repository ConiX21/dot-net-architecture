CREATE TABLE [dbo].[Phone]
(
	[IdPhone] TINYINT NOT NULL PRIMARY KEY IDENTITY, 
    [PhoneNumber] VARCHAR(10) NOT NULL, 
    [IdPerson] INT NULL, 
    CONSTRAINT [FK_Phone_ToTable] FOREIGN KEY (IdPerson) REFERENCES Person(IdPerson)
)
