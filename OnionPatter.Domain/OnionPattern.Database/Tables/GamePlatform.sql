CREATE TABLE [dbo].[GamePlatform]
(
	[GameId] INT NOT NULL REFERENCES [dbo].[Game](Id),
	[PlatformId] INT NOT NULL REFERENCES [dbo].[Platform](Id),
	UNIQUE(GameId, PlatformId)
)
GO

ALTER TABLE [dbo].[GamePlatform]
    ADD CONSTRAINT pk_GamePlatform PRIMARY KEY ([GameId], [PlatformId])
GO
