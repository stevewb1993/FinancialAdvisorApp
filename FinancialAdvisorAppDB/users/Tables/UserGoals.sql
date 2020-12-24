CREATE TABLE [users].[UserGoals]
(
	Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[UserId] NVARCHAR (450) NOT NULL,
	[DueDate] DATE NOT NULL,
	[FinanceTypeId] INT NOT NULL,
	[GoalValue] MONEY NOT NULL,
	[GoalStartDate] DATE NOT NULL,
	CONSTRAINT [FK_UserGoals_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_UserGoals_FinancialTypes_FinanceTypeId] FOREIGN KEY ([FinanceTypeId]) REFERENCES [ref].[FinanceTypes] (Id) ON DELETE CASCADE
)
