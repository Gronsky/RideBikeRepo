CREATE TABLE [dbo].[BikeSubtypes]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Subtype] nvarchar(30) NOT NULL,
	[TypeId] bigint NOT NULL,

	CONSTRAINT FK_BikeSubtypes_BikeTypes FOREIGN KEY(TypeId) REFERENCES BikeTypes(Id)
);
