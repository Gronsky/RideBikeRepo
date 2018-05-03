CREATE TABLE [dbo].[Roles]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(30) NOT NULL UNIQUE
);
