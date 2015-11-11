
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/10/2015 15:27:08
-- Generated from EDMX file: J:\OneDrive\Разработка\C# WPF Наброски\Questionare\QuestionareEntityFramework\Qustionare.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [questionare];
GO
IF SCHEMA_ID(N'questionare') IS NULL EXECUTE(N'CREATE SCHEMA [questionare]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[questionare].[FK_ChapterQuestion]', 'F') IS NOT NULL
    ALTER TABLE [questionare].[QuestItems] DROP CONSTRAINT [FK_ChapterQuestion];
GO
IF OBJECT_ID(N'[questionare].[FK_ChapterVariant]', 'F') IS NOT NULL
    ALTER TABLE [questionare].[Variants] DROP CONSTRAINT [FK_ChapterVariant];
GO
IF OBJECT_ID(N'[questionare].[FK_QuestQuestion]', 'F') IS NOT NULL
    ALTER TABLE [questionare].[QuestItems] DROP CONSTRAINT [FK_QuestQuestion];
GO
IF OBJECT_ID(N'[questionare].[FK_VariantQuestion]', 'F') IS NOT NULL
    ALTER TABLE [questionare].[QuestItems] DROP CONSTRAINT [FK_VariantQuestion];
GO
IF OBJECT_ID(N'[questionare].[FK_QuestAnswer]', 'F') IS NOT NULL
    ALTER TABLE [questionare].[Answers] DROP CONSTRAINT [FK_QuestAnswer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[questionare].[Answers]', 'U') IS NOT NULL
    DROP TABLE [questionare].[Answers];
GO
IF OBJECT_ID(N'[questionare].[Chapters]', 'U') IS NOT NULL
    DROP TABLE [questionare].[Chapters];
GO
IF OBJECT_ID(N'[questionare].[QuestItems]', 'U') IS NOT NULL
    DROP TABLE [questionare].[QuestItems];
GO
IF OBJECT_ID(N'[questionare].[Quests]', 'U') IS NOT NULL
    DROP TABLE [questionare].[Quests];
GO
IF OBJECT_ID(N'[questionare].[Variants]', 'U') IS NOT NULL
    DROP TABLE [questionare].[Variants];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Answers'
CREATE TABLE [questionare].[Answers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Sorted] int  NOT NULL,
    [Correct] bit  NOT NULL,
    [ModifyBy] int  NOT NULL,
    [ModifyAt] datetime  NOT NULL,
    [QuestId] int  NOT NULL
);
GO

-- Creating table 'Chapters'
CREATE TABLE [questionare].[Chapters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [DateCreated] datetime  NOT NULL,
    [ModifyBy] int  NOT NULL,
    [ModifyAt] datetime  NOT NULL
);
GO

-- Creating table 'QuestItems'
CREATE TABLE [questionare].[QuestItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sorted] int  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [ModifyBy] int  NOT NULL,
    [ModifyAt] datetime  NOT NULL,
    [ChapterId] int  NOT NULL,
    [VariantId] int  NOT NULL,
    [QuestId] int  NOT NULL
);
GO

-- Creating table 'Quests'
CREATE TABLE [questionare].[Quests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [ModifyBy] int  NOT NULL,
    [ModifyAt] datetime  NOT NULL
);
GO

-- Creating table 'Variants'
CREATE TABLE [questionare].[Variants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [DateCreated] datetime  NOT NULL,
    [ModifyBy] int  NOT NULL,
    [ModifyAt] datetime  NOT NULL,
    [ChapterId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Answers'
ALTER TABLE [questionare].[Answers]
ADD CONSTRAINT [PK_Answers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Chapters'
ALTER TABLE [questionare].[Chapters]
ADD CONSTRAINT [PK_Chapters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QuestItems'
ALTER TABLE [questionare].[QuestItems]
ADD CONSTRAINT [PK_QuestItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Quests'
ALTER TABLE [questionare].[Quests]
ADD CONSTRAINT [PK_Quests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Variants'
ALTER TABLE [questionare].[Variants]
ADD CONSTRAINT [PK_Variants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ChapterId] in table 'QuestItems'
ALTER TABLE [questionare].[QuestItems]
ADD CONSTRAINT [FK_ChapterQuestion]
    FOREIGN KEY ([ChapterId])
    REFERENCES [questionare].[Chapters]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChapterQuestion'
CREATE INDEX [IX_FK_ChapterQuestion]
ON [questionare].[QuestItems]
    ([ChapterId]);
GO

-- Creating foreign key on [ChapterId] in table 'Variants'
ALTER TABLE [questionare].[Variants]
ADD CONSTRAINT [FK_ChapterVariant]
    FOREIGN KEY ([ChapterId])
    REFERENCES [questionare].[Chapters]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChapterVariant'
CREATE INDEX [IX_FK_ChapterVariant]
ON [questionare].[Variants]
    ([ChapterId]);
GO

-- Creating foreign key on [QuestId] in table 'QuestItems'
ALTER TABLE [questionare].[QuestItems]
ADD CONSTRAINT [FK_QuestQuestion]
    FOREIGN KEY ([QuestId])
    REFERENCES [questionare].[Quests]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestQuestion'
CREATE INDEX [IX_FK_QuestQuestion]
ON [questionare].[QuestItems]
    ([QuestId]);
GO

-- Creating foreign key on [VariantId] in table 'QuestItems'
ALTER TABLE [questionare].[QuestItems]
ADD CONSTRAINT [FK_VariantQuestion]
    FOREIGN KEY ([VariantId])
    REFERENCES [questionare].[Variants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VariantQuestion'
CREATE INDEX [IX_FK_VariantQuestion]
ON [questionare].[QuestItems]
    ([VariantId]);
GO

-- Creating foreign key on [QuestId] in table 'Answers'
ALTER TABLE [questionare].[Answers]
ADD CONSTRAINT [FK_QuestAnswer]
    FOREIGN KEY ([QuestId])
    REFERENCES [questionare].[Quests]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestAnswer'
CREATE INDEX [IX_FK_QuestAnswer]
ON [questionare].[Answers]
    ([QuestId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------