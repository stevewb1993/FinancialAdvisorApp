CREATE TABLE [users].[Goals]
(
	Id NVARCHAR (450) NOT NULL PRIMARY KEY,
	[UserId] NVARCHAR (450) NOT NULL,
	[DueDate] DATE NOT NULL,
	[FinanceTypeId] NVARCHAR (450) NOT NULL,
	[GoalValue] MONEY NOT NULL,
	[GoalStartDate] DATE NOT NULL,
	[UserOrSystemGenerated] NVARCHAR(20) NOT NULL,
	CHECK ([UserOrSystemGenerated] in ('User', 'System')),
	CONSTRAINT [FK_UserGoals_UserDetails_UserId] FOREIGN KEY ([UserId]) REFERENCES [users].[userdetails] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_UserGoals_FinancialTypes_FinanceTypeId] FOREIGN KEY ([FinanceTypeId]) REFERENCES [ref].[FinanceTypes] (Id) ON DELETE CASCADE
)
