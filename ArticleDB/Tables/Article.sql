﻿CREATE TABLE [dbo].[Article]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	Price INT NOT NULL,
	Description VARCHAR(250),
	Category VARCHAR(50)
)