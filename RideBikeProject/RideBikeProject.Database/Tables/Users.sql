CREATE TABLE [dbo].[Users]
(
	[Id] bigint NOT NULL Primary key IDENTITY,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Email] varchar(50) NOT NULL UNIQUE,
	[Password] nvarchar(50) NOT NULL,
	[BirthDate] Date NOT NULL,
	[ImageId] bigint NULL,
	[TeamId] bigint NULL,
	[RoleId] bigint DEFAULT 2 NOT NULL,

	CONSTRAINT FK_Users_Images FOREIGN KEY(ImageId) REFERENCES Images(Id),
	Constraint FK_Users_Roles Foreign Key(RoleId) References Roles(Id),
	CONSTRAINT FK_Users_Teams FOREIGN KEY(TeamId) REFERENCES Teams(Id)
);
