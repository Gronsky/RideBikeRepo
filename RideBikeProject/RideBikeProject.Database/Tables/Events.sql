CREATE TABLE [dbo].[Events]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(50) NOT NULL,
	[DateTime] DateTime NOT NULL,
	[CreatedBy] bigint NOT NULL,
	[ImageId] bigint,
	[TypeId] bigint NOT NULL,
	[Location] nvarchar(200) NOT NULL,
	[Description] nvarchar(1000),

	CONSTRAINT FK_Events_Teams FOREIGN KEY(CreatedBy) REFERENCES Teams(Id)
	ON DELETE cascade
	ON UPDATE cascade,
	CONSTRAINT FK_Events_Images FOREIGN KEY(ImageId) REFERENCES Images(Id),
	CONSTRAINT FK_Events_EventTypes FOREIGN KEY(TypeId) REFERENCES EventTypes(Id)
);
