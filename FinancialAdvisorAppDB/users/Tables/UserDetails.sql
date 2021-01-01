CREATE TABLE [users].[UserDetails]
(
	Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[UserGuid] NVARCHAR(450) NOT NULL,
	[DateOfBirth] DATE,
	[HighestEducation] Varchar(100),
	[RetirementAge] INT,
	CONSTRAINT [FK_UserDetails_AspNetUsers_UserId] FOREIGN KEY (UserGuid) REFERENCES [dbo].[aspnetusers] ([Id]) ON DELETE CASCADE,
)