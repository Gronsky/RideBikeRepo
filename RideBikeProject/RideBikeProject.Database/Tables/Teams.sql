CREATE TABLE [dbo].[Teams]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(50) NOT NULL UNIQUE,
	[ImageId] bigint NULL,
	[Location] nvarchar(200),
	[Description] nvarchar(1000),
	[ChiefId] bigint NOT NULL UNIQUE

	CONSTRAINT FK_Teams_Images FOREIGN KEY(ImageId) REFERENCES Images(Id),
	Constraint FK_Teams_Users Foreign key(ChiefId) References Users(Id)
);