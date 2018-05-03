CREATE TABLE [dbo].[BikeTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Type] nvarchar(30) NOT NULL UNIQUE
);
