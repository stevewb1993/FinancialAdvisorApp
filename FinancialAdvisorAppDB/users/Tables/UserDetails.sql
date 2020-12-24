CREATE TABLE [users].[UserDetails]
(
	Id NVARCHAR (450) NOT NULL PRIMARY KEY,
	[DateOfBirth] DATE NOT NULL,
	[HighestEducation] Varchar(100) NOT NULL,
	[RetirementAge] INT NOT NULL,
	CONSTRAINT [FK_UserDetails_AspNetUsers_UserId] FOREIGN KEY (Id) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
)