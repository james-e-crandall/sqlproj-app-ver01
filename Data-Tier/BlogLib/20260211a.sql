IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

--BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    CREATE TABLE [Blogs] (
        [Id] int NOT NULL IDENTITY,
        CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id])
    );
END;
GO
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    CREATE TABLE [Tags] (
        [Id] int NOT NULL IDENTITY,
        CONSTRAINT [PK_Tags] PRIMARY KEY ([Id])
    );
END;
GO
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    CREATE TABLE [BlogFooters] (
        [Id] int NOT NULL IDENTITY,
        [BlogId] int NULL,
        CONSTRAINT [PK_BlogFooters] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BlogFooters_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id])
    );
END;
GO
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    CREATE TABLE [BlogHeaders] (
        [Id] int NOT NULL IDENTITY,
        [BlogId] int NOT NULL,
        CONSTRAINT [PK_BlogHeaders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BlogHeaders_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE
    );
END;
GO
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    CREATE TABLE [Posts] (
        [Id] int NOT NULL IDENTITY,
        [BlogId] int NOT NULL,
        CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Posts_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE
    );
END;
GO
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    CREATE TABLE [PostTags] (
        [PostsId] int NOT NULL,
        [TagsId] int NOT NULL,
        CONSTRAINT [PK_PostTags] PRIMARY KEY ([PostsId], [TagsId]),
        CONSTRAINT [FK_PostTags_Posts_PostsId] FOREIGN KEY ([PostsId]) REFERENCES [Posts] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_PostTags_Tags_TagsId] FOREIGN KEY ([TagsId]) REFERENCES [Tags] ([Id]) ON DELETE CASCADE
    );
END;
GO
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_BlogFooters_BlogId] ON [BlogFooters] ([BlogId]) WHERE [BlogId] IS NOT NULL');
END;
GO
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    CREATE UNIQUE INDEX [IX_BlogHeaders_BlogId] ON [BlogHeaders] ([BlogId]);
END;
GO
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    CREATE INDEX [IX_Posts_BlogId] ON [Posts] ([BlogId]);
END;
GO
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    CREATE INDEX [IX_PostTags_TagsId] ON [PostTags] ([TagsId]);
END;
GO
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20261102220847_20261102a'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20261102220847_20261102a', N'10.0.14');
END;
GO
--COMMIT;
--GO

