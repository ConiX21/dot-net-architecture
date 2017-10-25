
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/27/2013 09:57:22
-- Generated from EDMX file: C:\Users\coni\Desktop\AdoCours\Navigation\Data\ModelContact.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBContact];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Telephone_Contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Telephone] DROP CONSTRAINT [FK_Telephone_Contact];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact];
GO
IF OBJECT_ID(N'[dbo].[Telephone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Telephone];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contact'
CREATE TABLE [dbo].[Contact] (
    [IdContact] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(45)  NOT NULL,
    [Prenom] nvarchar(45)  NOT NULL,
    [Adresse] nvarchar(100)  NULL,
    [Cp] nvarchar(5)  NULL,
    [Ville] nvarchar(40)  NULL,
    [Email] nvarchar(150)  NULL,
    [DateNaiss] datetime  NOT NULL
);
GO

-- Creating table 'Telephone'
CREATE TABLE [dbo].[Telephone] (
    [IdTelephone] int IDENTITY(1,1) NOT NULL,
    [idContact] int  NULL,
    [numero] nchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdContact] in table 'Contact'
ALTER TABLE [dbo].[Contact]
ADD CONSTRAINT [PK_Contact]
    PRIMARY KEY CLUSTERED ([IdContact] ASC);
GO

-- Creating primary key on [IdTelephone] in table 'Telephone'
ALTER TABLE [dbo].[Telephone]
ADD CONSTRAINT [PK_Telephone]
    PRIMARY KEY CLUSTERED ([IdTelephone] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idContact] in table 'Telephone'
ALTER TABLE [dbo].[Telephone]
ADD CONSTRAINT [FK_Telephone_Contact]
    FOREIGN KEY ([idContact])
    REFERENCES [dbo].[Contact]
        ([IdContact])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Telephone_Contact'
CREATE INDEX [IX_FK_Telephone_Contact]
ON [dbo].[Telephone]
    ([idContact]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------