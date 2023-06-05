IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Actors] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Age] int NOT NULL,
    [AcademicWinner] bit NOT NULL,
    CONSTRAINT [PK_Actors] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230530121917_actor', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Films] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Author] nvarchar(max) NOT NULL,
    [ParentId] int NOT NULL,
    CONSTRAINT [PK_Films] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230601054517_createFileTable', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Actors] ADD [FilmsId] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Details] (
    [Id] int NOT NULL IDENTITY,
    [FilmName] nvarchar(max) NOT NULL,
    [Country] nvarchar(max) NOT NULL,
    [Year] int NOT NULL,
    CONSTRAINT [PK_Details] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Actors_FilmsId] ON [Actors] ([FilmsId]);
GO

ALTER TABLE [Actors] ADD CONSTRAINT [FK_Actors_Films_FilmsId] FOREIGN KEY ([FilmsId]) REFERENCES [Films] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230601122233_createDetailsTable', N'7.0.5');
GO

COMMIT;
GO

