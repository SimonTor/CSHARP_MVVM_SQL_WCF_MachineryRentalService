
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/08/2015 16:19:36
-- Generated from EDMX file: C:\Softwareprojekte\Baumaschinenverleih\Software\CrossCutting\Mietmaschinendatenbank_DataClasses\MietmaschinendatenbankModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [mietdatenbank];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MaschinenartenlisteMaschinenkaufliste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaschinenkauflisteSatz] DROP CONSTRAINT [FK_MaschinenartenlisteMaschinenkaufliste];
GO
IF OBJECT_ID(N'[dbo].[FK_VermietungMaschinenart_Vermietung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VermietungMaschinenart] DROP CONSTRAINT [FK_VermietungMaschinenart_Vermietung];
GO
IF OBJECT_ID(N'[dbo].[FK_VermietungMaschinenart_Maschinenart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VermietungMaschinenart] DROP CONSTRAINT [FK_VermietungMaschinenart_Maschinenart];
GO
IF OBJECT_ID(N'[dbo].[FK_MaschinenartLagerbestand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaschinenartenlisteSatz] DROP CONSTRAINT [FK_MaschinenartLagerbestand];
GO
IF OBJECT_ID(N'[dbo].[FK_KundeVermietung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VermietungslisteSatz] DROP CONSTRAINT [FK_KundeVermietung];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MaschinenkauflisteSatz]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaschinenkauflisteSatz];
GO
IF OBJECT_ID(N'[dbo].[LagerbestandSatz]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LagerbestandSatz];
GO
IF OBJECT_ID(N'[dbo].[KundenlisteSatz]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KundenlisteSatz];
GO
IF OBJECT_ID(N'[dbo].[VermietungslisteSatz]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VermietungslisteSatz];
GO
IF OBJECT_ID(N'[dbo].[MaschinenartenlisteSatz]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaschinenartenlisteSatz];
GO
IF OBJECT_ID(N'[dbo].[VermietungMaschinenart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VermietungMaschinenart];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MaschinenkauflisteSatz'
CREATE TABLE [dbo].[MaschinenkauflisteSatz] (
    [Maschinenkauf_ID] int IDENTITY(1,1) NOT NULL,
    [Anzahl] int  NOT NULL,
    [Einzelpreis] int  NOT NULL,
    [Rechnungspreis] float  NOT NULL,
    [Kaufdatum] datetime  NOT NULL,
    [Maschinenart_ID] int  NOT NULL
);
GO

-- Creating table 'LagerbestandSatz'
CREATE TABLE [dbo].[LagerbestandSatz] (
    [Lagerbestand_ID] int IDENTITY(1,1) NOT NULL,
    [Maschinenart_ID] int  NOT NULL,
    [Gesamtanzahl] int  NOT NULL,
    [Lagermenge] int  NOT NULL,
    [VermietetMenge] int  NOT NULL
);
GO

-- Creating table 'KundenlisteSatz'
CREATE TABLE [dbo].[KundenlisteSatz] (
    [Kunden_ID] int IDENTITY(1,1) NOT NULL,
    [Kundenname] nvarchar(max)  NOT NULL,
    [Kundengesamtumsatz] float  NOT NULL
);
GO

-- Creating table 'VermietungslisteSatz'
CREATE TABLE [dbo].[VermietungslisteSatz] (
    [Vermiet_ID] int IDENTITY(1,1) NOT NULL,
    [Vermietbegin] datetime  NOT NULL,
    [Vermietende] datetime  NOT NULL,
    [Gesamtpreis] float  NOT NULL,
    [Kunden_ID] int  NOT NULL
);
GO

-- Creating table 'MaschinenartenlisteSatz'
CREATE TABLE [dbo].[MaschinenartenlisteSatz] (
    [Maschinenart_ID] int IDENTITY(1,1) NOT NULL,
    [Gesamtkosten] int  NOT NULL,
    [Gesamteinnahmen] int  NOT NULL,
    [Vermietfaktor] int  NOT NULL,
    [Tagessatz] float  NOT NULL,
    [Rentabilität] float  NOT NULL,
    [Maschinenartbezeichnung] nvarchar(max)  NOT NULL,
    [Lagerbestand_Lagerbestand_ID] int  NOT NULL
);
GO

-- Creating table 'VermietungMaschinenart'
CREATE TABLE [dbo].[VermietungMaschinenart] (
    [Vermietung_Vermiet_ID] int  NOT NULL,
    [Maschinenart_Maschinenart_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Maschinenkauf_ID] in table 'MaschinenkauflisteSatz'
ALTER TABLE [dbo].[MaschinenkauflisteSatz]
ADD CONSTRAINT [PK_MaschinenkauflisteSatz]
    PRIMARY KEY CLUSTERED ([Maschinenkauf_ID] ASC);
GO

-- Creating primary key on [Lagerbestand_ID] in table 'LagerbestandSatz'
ALTER TABLE [dbo].[LagerbestandSatz]
ADD CONSTRAINT [PK_LagerbestandSatz]
    PRIMARY KEY CLUSTERED ([Lagerbestand_ID] ASC);
GO

-- Creating primary key on [Kunden_ID] in table 'KundenlisteSatz'
ALTER TABLE [dbo].[KundenlisteSatz]
ADD CONSTRAINT [PK_KundenlisteSatz]
    PRIMARY KEY CLUSTERED ([Kunden_ID] ASC);
GO

-- Creating primary key on [Vermiet_ID] in table 'VermietungslisteSatz'
ALTER TABLE [dbo].[VermietungslisteSatz]
ADD CONSTRAINT [PK_VermietungslisteSatz]
    PRIMARY KEY CLUSTERED ([Vermiet_ID] ASC);
GO

-- Creating primary key on [Maschinenart_ID] in table 'MaschinenartenlisteSatz'
ALTER TABLE [dbo].[MaschinenartenlisteSatz]
ADD CONSTRAINT [PK_MaschinenartenlisteSatz]
    PRIMARY KEY CLUSTERED ([Maschinenart_ID] ASC);
GO

-- Creating primary key on [Vermietung_Vermiet_ID], [Maschinenart_Maschinenart_ID] in table 'VermietungMaschinenart'
ALTER TABLE [dbo].[VermietungMaschinenart]
ADD CONSTRAINT [PK_VermietungMaschinenart]
    PRIMARY KEY NONCLUSTERED ([Vermietung_Vermiet_ID], [Maschinenart_Maschinenart_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Maschinenart_ID] in table 'MaschinenkauflisteSatz'
ALTER TABLE [dbo].[MaschinenkauflisteSatz]
ADD CONSTRAINT [FK_MaschinenartenlisteMaschinenkaufliste]
    FOREIGN KEY ([Maschinenart_ID])
    REFERENCES [dbo].[MaschinenartenlisteSatz]
        ([Maschinenart_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MaschinenartenlisteMaschinenkaufliste'
CREATE INDEX [IX_FK_MaschinenartenlisteMaschinenkaufliste]
ON [dbo].[MaschinenkauflisteSatz]
    ([Maschinenart_ID]);
GO

-- Creating foreign key on [Vermietung_Vermiet_ID] in table 'VermietungMaschinenart'
ALTER TABLE [dbo].[VermietungMaschinenart]
ADD CONSTRAINT [FK_VermietungMaschinenart_Vermietung]
    FOREIGN KEY ([Vermietung_Vermiet_ID])
    REFERENCES [dbo].[VermietungslisteSatz]
        ([Vermiet_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Maschinenart_Maschinenart_ID] in table 'VermietungMaschinenart'
ALTER TABLE [dbo].[VermietungMaschinenart]
ADD CONSTRAINT [FK_VermietungMaschinenart_Maschinenart]
    FOREIGN KEY ([Maschinenart_Maschinenart_ID])
    REFERENCES [dbo].[MaschinenartenlisteSatz]
        ([Maschinenart_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VermietungMaschinenart_Maschinenart'
CREATE INDEX [IX_FK_VermietungMaschinenart_Maschinenart]
ON [dbo].[VermietungMaschinenart]
    ([Maschinenart_Maschinenart_ID]);
GO

-- Creating foreign key on [Lagerbestand_Lagerbestand_ID] in table 'MaschinenartenlisteSatz'
ALTER TABLE [dbo].[MaschinenartenlisteSatz]
ADD CONSTRAINT [FK_MaschinenartLagerbestand]
    FOREIGN KEY ([Lagerbestand_Lagerbestand_ID])
    REFERENCES [dbo].[LagerbestandSatz]
        ([Lagerbestand_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MaschinenartLagerbestand'
CREATE INDEX [IX_FK_MaschinenartLagerbestand]
ON [dbo].[MaschinenartenlisteSatz]
    ([Lagerbestand_Lagerbestand_ID]);
GO

-- Creating foreign key on [Kunden_ID] in table 'VermietungslisteSatz'
ALTER TABLE [dbo].[VermietungslisteSatz]
ADD CONSTRAINT [FK_KundeVermietung]
    FOREIGN KEY ([Kunden_ID])
    REFERENCES [dbo].[KundenlisteSatz]
        ([Kunden_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KundeVermietung'
CREATE INDEX [IX_FK_KundeVermietung]
ON [dbo].[VermietungslisteSatz]
    ([Kunden_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------