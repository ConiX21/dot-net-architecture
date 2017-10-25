
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/18/2013 12:03:20
-- Generated from EDMX file: c:\users\administrateur\documents\visual studio 2010\Projects\AdoCours\AdoCours\Data\ModelCours.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contact];
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

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdContact] in table 'Contact'
ALTER TABLE [dbo].[Contact]
ADD CONSTRAINT [PK_Contact]
    PRIMARY KEY CLUSTERED ([IdContact] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------