
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/21/2013 11:47:58
-- Generated from EDMX file: C:\Users\Administrateur\Documents\Visual Studio 2012\Projects\ADO\AdoCours\ModelHeritage\ModelEditeur.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBEditeur];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EditeurDB_inherits_Editeur]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Editeur_EditeurDB] DROP CONSTRAINT [FK_EditeurDB_inherits_Editeur];
GO
IF OBJECT_ID(N'[dbo].[FK_EditeurInfo_inherits_Editeur]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Editeur_EditeurInfo] DROP CONSTRAINT [FK_EditeurInfo_inherits_Editeur];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Editeur]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Editeur];
GO
IF OBJECT_ID(N'[dbo].[Editeur_EditeurDB]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Editeur_EditeurDB];
GO
IF OBJECT_ID(N'[dbo].[Editeur_EditeurInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Editeur_EditeurInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Editeur'
CREATE TABLE [dbo].[Editeur] (
    [IdEditeur] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Editeur_EditeurDB'
CREATE TABLE [dbo].[Editeur_EditeurDB] (
    [IdEditeurDB] int IDENTITY(1,1) NOT NULL,
    [NbDB] int  NOT NULL,
    [IdEditeur] int  NOT NULL
);
GO

-- Creating table 'Editeur_EditeurInfo'
CREATE TABLE [dbo].[Editeur_EditeurInfo] (
    [NbLivre] nvarchar(max)  NOT NULL,
    [IdEditeur] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdEditeur] in table 'Editeur'
ALTER TABLE [dbo].[Editeur]
ADD CONSTRAINT [PK_Editeur]
    PRIMARY KEY CLUSTERED ([IdEditeur] ASC);
GO

-- Creating primary key on [IdEditeur] in table 'Editeur_EditeurDB'
ALTER TABLE [dbo].[Editeur_EditeurDB]
ADD CONSTRAINT [PK_Editeur_EditeurDB]
    PRIMARY KEY CLUSTERED ([IdEditeur] ASC);
GO

-- Creating primary key on [IdEditeur] in table 'Editeur_EditeurInfo'
ALTER TABLE [dbo].[Editeur_EditeurInfo]
ADD CONSTRAINT [PK_Editeur_EditeurInfo]
    PRIMARY KEY CLUSTERED ([IdEditeur] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdEditeur] in table 'Editeur_EditeurDB'
ALTER TABLE [dbo].[Editeur_EditeurDB]
ADD CONSTRAINT [FK_EditeurDB_inherits_Editeur]
    FOREIGN KEY ([IdEditeur])
    REFERENCES [dbo].[Editeur]
        ([IdEditeur])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdEditeur] in table 'Editeur_EditeurInfo'
ALTER TABLE [dbo].[Editeur_EditeurInfo]
ADD CONSTRAINT [FK_EditeurInfo_inherits_Editeur]
    FOREIGN KEY ([IdEditeur])
    REFERENCES [dbo].[Editeur]
        ([IdEditeur])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------