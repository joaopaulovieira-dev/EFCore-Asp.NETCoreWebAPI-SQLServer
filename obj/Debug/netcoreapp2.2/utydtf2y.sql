IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Battles] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataFim] datetime2 NOT NULL,
    CONSTRAINT [PK_Battles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Heroes] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [BatalhaId] int NOT NULL,
    CONSTRAINT [PK_Heroes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Heroes_Battles_BatalhaId] FOREIGN KEY ([BatalhaId]) REFERENCES [Battles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Weapons] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [HeroiId] int NOT NULL,
    CONSTRAINT [PK_Weapons] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Weapons_Heroes_HeroiId] FOREIGN KEY ([HeroiId]) REFERENCES [Heroes] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Heroes_BatalhaId] ON [Heroes] ([BatalhaId]);

GO

CREATE INDEX [IX_Weapons_HeroiId] ON [Weapons] ([HeroiId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220917230533_initial', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Heroes] DROP CONSTRAINT [FK_Heroes_Battles_BatalhaId];

GO

DROP INDEX [IX_Heroes_BatalhaId] ON [Heroes];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Heroes]') AND [c].[name] = N'BatalhaId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Heroes] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Heroes] DROP COLUMN [BatalhaId];

GO

CREATE TABLE [HeroBattles] (
    [HeroId] int NOT NULL,
    [BatalhaId] int NOT NULL,
    [BattleId] int NULL,
    CONSTRAINT [PK_HeroBattles] PRIMARY KEY ([BatalhaId], [HeroId]),
    CONSTRAINT [FK_HeroBattles_Battles_BattleId] FOREIGN KEY ([BattleId]) REFERENCES [Battles] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HeroBattles_Heroes_HeroId] FOREIGN KEY ([HeroId]) REFERENCES [Heroes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [SecretIdentities] (
    [Id] int NOT NULL IDENTITY,
    [Nomereal] int NOT NULL,
    [HeroId] int NOT NULL,
    CONSTRAINT [PK_SecretIdentities] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SecretIdentities_Heroes_HeroId] FOREIGN KEY ([HeroId]) REFERENCES [Heroes] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_HeroBattles_BattleId] ON [HeroBattles] ([BattleId]);

GO

CREATE INDEX [IX_HeroBattles_HeroId] ON [HeroBattles] ([HeroId]);

GO

CREATE UNIQUE INDEX [IX_SecretIdentities_HeroId] ON [SecretIdentities] ([HeroId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220918003334_HeroesBattles_Identities', N'2.2.6-servicing-10079');

GO

