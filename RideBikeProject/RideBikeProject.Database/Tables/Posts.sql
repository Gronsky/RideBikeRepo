CREATE TABLE [dbo].[Posts]
(
	[Id] BIGINT NOT NULL PRIMARY KEY,
	Title Nvarchar(50) NOT NULL,
	Preface Nvarchar(200) NOT NULL,
	[Text] NVArchar(2000) NOT NULL,
	[Image] BIGINT NULL,
	Video varchar(2000) NULL,
	OwnerId BIGINT NOT NULL
)
