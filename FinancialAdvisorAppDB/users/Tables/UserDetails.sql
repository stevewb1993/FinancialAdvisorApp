CREATE TABLE [users].[UserDetails]
(
	[UserId] NVARCHAR (450) NOT NULL PRIMARY KEY,
	[DateOfBirth] DATE NOT NULL,
	[HighestEducation] Varchar(100) NOT NULL,
	[RetirementAge] INT NOT NULL,
	CONSTRAINT [FK_UserDetails_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
)