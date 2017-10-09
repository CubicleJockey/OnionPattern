CREATE TABLE [dbo].[GamePlatform]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[GameId] INT NOT NULL REFERENCES [dbo].[Game](Id),
	[PlatformId] INT NOT NULL REFERENCES [dbo].[Platform](Id),
	UNIQUE(GameId, PlatformId)
)
GO