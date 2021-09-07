CREATE TABLE [dbo].[Books]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	[Title] nchar(100) not null,
	[Author] nchar(100) NULL,
	[Publisher] nchar(100) null,
	[Pages] int not null,
	[Year] int NULL,
	[Language] nchar(20) NOT NULL,
	[Image] nvarchar(2083)
	)



