-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/26/2017 09:44:26
-- Generated from EDMX file: C:\MyWorks\UnitAndIntegratedTest\UnitAndIntegratedTest\DbLayer\PersonModel.edmx
-- --------------------------------------------------
SET QUOTED_IDENTIFIER OFF;
GO
USE [IntegrationTestSample];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO
-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------
IF OBJECT_ID(N'[dbo].[FK_MessageFromPerson_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageFromPerson] DROP CONSTRAINT [FK_MessageFromPerson_Person];
GO
-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
IF OBJECT_ID(N'[dbo].[MessageFromPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageFromPerson];
GO
IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO
-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------
-- Creating table 'MessageFromPerson'
CREATE TABLE [dbo].[MessageFromPerson] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PersonId] int  NOT NULL,
    [Message] nvarchar(500)  NULL
);
GO
-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Surname] nvarchar(50)  NOT NULL
);
GO
-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------
-- Creating primary key on [Id] in table 'MessageFromPerson'
ALTER TABLE [dbo].[MessageFromPerson]
ADD CONSTRAINT [PK_MessageFromPerson]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating primary key on [Id] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------
-- Creating foreign key on [PersonId] in table 'MessageFromPerson'
ALTER TABLE [dbo].[MessageFromPerson]
ADD CONSTRAINT [FK_MessageFromPerson_Person]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_MessageFromPerson_Person'
CREATE INDEX [IX_FK_MessageFromPerson_Person]
ON [dbo].[MessageFromPerson]
    ([PersonId]);
GO
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------