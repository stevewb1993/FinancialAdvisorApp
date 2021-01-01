CREATE TABLE [users].[UserDetails]
(
	Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[UserGuid] NVARCHAR(450) NOT NULL,
	[DateOfBirth] DATE NOT NULL,
	[HighestEducation] Varchar(100) NOT NULL,
	[RetirementAge] INT NOT NULL,
	CONSTRAINT [FK_UserDetails_AspNetUsers_UserId] FOREIGN KEY (UserGuid) REFERENCES [dbo].[aspnetusers] ([Id]) ON DELETE CASCADE,
)