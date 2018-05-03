Create table [dbo].[EventUsers]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[EventId] bigint NOT NULL,
	[UserId] bigint NOT NULL,
	[BikeId] bigint NULL,

	CONSTRAINT FK_EventUsers_Events FOREIGN KEY(EventId) REFERENCES [Events](Id),
	CONSTRAINT FK_EventUsers_Users FOREIGN KEY(UserId) REFERENCES [Users](Id),
	CONSTRAINT FK_EventUsers_Bikes FOREIGN KEY(BikeId) REFERENCES [Bikes](Id)
)