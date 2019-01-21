
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/11/2019 21:04:36
-- Generated from EDMX file: C:\Users\thedr\source\repos\EventPlanning\EventPlanning\EventPlanning.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EventPlanning];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FullNames'
CREATE TABLE [dbo].[FullNames] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [SureName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Positions'
CREATE TABLE [dbo].[Positions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullNameId] int  NOT NULL,
    [PositionId] int  NOT NULL,
    [GroupId] int  NOT NULL,
    [Birthday] datetime  NOT NULL,
    [Male] bit  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FullNames'
ALTER TABLE [dbo].[FullNames]
ADD CONSTRAINT [PK_FullNames]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [PK_Positions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FullNameId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_FullNameEmployee]
    FOREIGN KEY ([FullNameId])
    REFERENCES [dbo].[FullNames]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FullNameEmployee'
CREATE INDEX [IX_FK_FullNameEmployee]
ON [dbo].[Employees]
    ([FullNameId]);
GO

-- Creating foreign key on [PositionId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_PositionEmployee]
    FOREIGN KEY ([PositionId])
    REFERENCES [dbo].[Positions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionEmployee'
CREATE INDEX [IX_FK_PositionEmployee]
ON [dbo].[Employees]
    ([PositionId]);
GO

-- Creating foreign key on [GroupId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_GroupEmployee]
    FOREIGN KEY ([GroupId])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupEmployee'
CREATE INDEX [IX_FK_GroupEmployee]
ON [dbo].[Employees]
    ([GroupId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------