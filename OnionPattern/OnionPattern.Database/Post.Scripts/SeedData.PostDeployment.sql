/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE [VideoGames]
GO

--Insert Platforms
SET IDENTITY_INSERT [dbo].[Platform] ON 
GO

INSERT INTO [dbo].[Platform](Id, [Name], ReleaseDate) VALUES(1, 'Nintendo', '07/15/1983')
INSERT INTO [dbo].[Platform](Id, [Name], ReleaseDate) VALUES(2, 'Super Nintendo', '11/21/1990')
INSERT INTO [dbo].[Platform](Id, [Name], ReleaseDate) VALUES(3, 'Nintendo 64', '06/23/1996')
INSERT INTO [dbo].[Platform](Id, [Name], ReleaseDate) VALUES(4, 'Nintendo Game Cube', '11/18/2001')
INSERT INTO [dbo].[Platform](Id, [Name], ReleaseDate) VALUES(5, 'Nintendo Wii', '11/19/2006')
INSERT INTO [dbo].[Platform](Id, [Name], ReleaseDate) VALUES(6, 'Nintendo Wii U', '11/18/2012')
INSERT INTO [dbo].[Platform](Id, [Name], ReleaseDate) VALUES(7, 'Nintendo Switch', '03/03/2017')

SET IDENTITY_INSERT [dbo].[Platform] OFF
GO

--Insert Games
SET IDENTITY_INSERT [dbo].[Game] ON 
GO

INSERT INTO [dbo].[Game](Id, [Name], Genre, Price, ReleaseDate) VALUES(1, 'The Legend of Zelda', 'Adventure|RPG', 24.99, '08/22/1987')
INSERT INTO [dbo].[Game](Id, [Name], Genre, Price, ReleaseDate) VALUES(2, 'Zelda II: The Adventure of Link', 'Adventure|RPG', 30.16, '09/26/1988')
INSERT INTO [dbo].[Game](Id, [Name], Genre, Price, ReleaseDate) VALUES(3, 'The Legend of Zelda: A Link To The Past', 'Adventure|RPG', 40.13, '11/21/1991')
INSERT INTO [dbo].[Game](Id, [Name], Genre, Price, ReleaseDate) VALUES(4, 'The Legend of Zelda: Ocarina of Time', 'Adventure|RPG', 69.69, '11/21/1998')
INSERT INTO [dbo].[Game](Id, [Name], Genre, Price, ReleaseDate) VALUES(5, 'The Legend of Zelda: Majora''s Mask', 'Adventure|RPG', 120.56, '04/27/2000')
INSERT INTO [dbo].[Game](Id, [Name], Genre, Price, ReleaseDate) VALUES(6, 'The Legend of Zelda: The Wind Waker', 'Adventure|RPG', 13.13, '12/13/2002')
INSERT INTO [dbo].[Game](Id, [Name], Genre, Price, ReleaseDate) VALUES(7, 'The Legend of Zelda: Twilight Princess', 'Adventure|RPG', 10000.12, '12/02/2006')
INSERT INTO [dbo].[Game](Id, [Name], Genre, Price, ReleaseDate) VALUES(8, 'The Legend of Zelda: Skyward Sword', 'Adventure|RPG', 10000.12, '11/18/2011')
INSERT INTO [dbo].[Game](Id, [Name], Genre, Price, ReleaseDate) VALUES(9, 'The Legend of Zelda: Breath of the Wild', 'Adventure|RPG', 10000.12, '03/03/2017')

SET IDENTITY_INSERT [dbo].[Game] OFF
GO

--Insert GamePlatforms
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(1, 1)
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(2, 1)
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(3, 2)
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(4, 3)
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(5, 3)
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(6, 4)
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(7, 4)
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(7, 5)
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(8, 5)
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(9, 6)
INSERT INTO [dbo].[GamePlatform](GameId, PlatformId) VALUES(9, 7)
