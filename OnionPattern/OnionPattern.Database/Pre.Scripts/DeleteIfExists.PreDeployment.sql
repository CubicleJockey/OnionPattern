﻿/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE [master]
GO

IF EXISTS(SELECT * FROM [sys].[databases] WHERE name = 'VideoGames')
BEGIN
	DROP DATABASE VideoGames
END

CREATE DATABASE VideoGames

USE [VideoGames]
GO