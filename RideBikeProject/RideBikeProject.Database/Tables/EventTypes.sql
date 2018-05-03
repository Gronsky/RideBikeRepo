CREATE TABLE [dbo].[EventTypes]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Type] nvarchar(30) NOT NULL,
	[LongType] nvarchar(100) NOT NULL,
	[Description] nvarchar(1000) 
);
