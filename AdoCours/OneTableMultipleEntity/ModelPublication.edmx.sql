
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/21/2013 13:55:16
-- Generated from EDMX file: C:\Users\Administrateur\Documents\Visual Studio 2012\Projects\ADO\AdoCours\OneTableMultipleEntity\ModelPublication.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBPublication];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AuteurPublication]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publication] DROP CONSTRAINT [FK_AuteurPublication];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Auteur]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Auteur];
GO
IF OBJECT_ID(N'[dbo].[Publication]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publication];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Auteur'
CREATE TABLE [dbo].[Auteur] (
    [IdAuteur] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Prenom] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Publication'
CREATE TABLE [dbo].[Publication] (
    [IdPublication] int IDENTITY(1,1) NOT NULL,
    [IdAuteur] int  NOT NULL,
    [Titre] nchar(10)  NULL,
    [Type] nchar(10)  NULL,
    [Url] nchar(10)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAuteur] in table 'Auteur'
ALTER TABLE [dbo].[Auteur]
ADD CONSTRAINT [PK_Auteur]
    PRIMARY KEY CLUSTERED ([IdAuteur] ASC);
GO

-- Creating primary key on [IdPublication] in table 'Publication'
ALTER TABLE [dbo].[Publication]
ADD CONSTRAINT [PK_Publication]
    PRIMARY KEY CLUSTERED ([IdPublication] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdAuteur] in table 'Publication'
ALTER TABLE [dbo].[Publication]
ADD CONSTRAINT [FK_AuteurPublication]
    FOREIGN KEY ([IdAuteur])
    REFERENCES [dbo].[Auteur]
        ([IdAuteur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AuteurPublication'
CREATE INDEX [IX_FK_AuteurPublication]
ON [dbo].[Publication]
    ([IdAuteur]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------