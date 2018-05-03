CREATE TABLE [dbo].[Bikes]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(50) NOT NULL,
	[OwnerId] bigint NOT NULL,
	[TypeId] bigint NOT NULL,
	[ProducerId] bigint NOT NULL,
	[Model] nvarchar(50),
	[Description] nvarchar(1000),
	
	CONSTRAINT FK_Bikes_Users FOREIGN KEY(OwnerId) REFERENCES Users(Id),
	Constraint FK_Bikes_BikeSubtypes Foreign Key(TypeId) References BikeSubtypes(Id),
	CONSTRAINT FK_Bikes_Producers Foreign Key(ProducerId) References Producers(Id)
);