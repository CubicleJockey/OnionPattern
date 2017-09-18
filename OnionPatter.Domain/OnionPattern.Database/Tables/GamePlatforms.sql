CREATE TABLE [dbo].[GamePlatforms]
(
	[GameId] INT NOT NULL REFERENCES [dbo].[Game](Id),
	[PlatformId] INT NOT NULL REFERENCES [dbo].[Platform](Id),
	UNIQUE(GameId, PlatformId)
)
