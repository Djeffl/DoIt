IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507221719_Add_TodoAndGoalTable')
BEGIN
    CREATE TABLE [Goals] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [DueAt] datetime2 NULL,
        [CreatedAt] datetime2 NOT NULL,
        [FinishedAt] datetime2 NULL,
        [IsFinished] bit NOT NULL,
        CONSTRAINT [PK_Goals] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507221719_Add_TodoAndGoalTable')
BEGIN
    CREATE TABLE [Todo] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [StartTime] datetime2 NULL,
        [EndTime] datetime2 NULL,
        [CreatedAt] datetime2 NOT NULL,
        [FinishedAt] datetime2 NULL,
        [IsFinished] bit NOT NULL,
        [GoalId] int NULL,
        CONSTRAINT [PK_Todo] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Todo_Goals_GoalId] FOREIGN KEY ([GoalId]) REFERENCES [Goals] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507221719_Add_TodoAndGoalTable')
BEGIN
    CREATE INDEX [IX_Todo_GoalId] ON [Todo] ([GoalId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507221719_Add_TodoAndGoalTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210507221719_Add_TodoAndGoalTable', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210610174755_Add_IdeaTable')
BEGIN
    ALTER SCHEMA [dbo] TRANSFER [Todo];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210610174755_Add_IdeaTable')
BEGIN
    ALTER SCHEMA [dbo] TRANSFER [Goals];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210610174755_Add_IdeaTable')
BEGIN
    CREATE TABLE [dbo].[Ideas] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [CreatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Ideas] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210610174755_Add_IdeaTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210610174755_Add_IdeaTable', N'3.1.6');
END;

GO

