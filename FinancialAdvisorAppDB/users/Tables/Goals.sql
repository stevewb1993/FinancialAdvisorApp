CREATE TABLE [users].[Goals]
(
	Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[UserId] INT NOT NULL,
	[DueDate] DATE NOT NULL,
	[FinanceTypeId] INT NOT NULL,
	[GoalValue] MONEY NOT NULL,
	[GoalStartDate] DATE NOT NULL,
	[Justification] NVARCHAR(500) NULL,
	CONSTRAINT [FK_UserGoals_UserDetails_UserId] FOREIGN KEY ([UserId]) REFERENCES [users].[userdetails] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_UserGoals_FinancialTypes_FinanceTypeId] FOREIGN KEY ([FinanceTypeId]) REFERENCES [ref].[FinanceTypes] (Id) ON DELETE CASCADE
)
