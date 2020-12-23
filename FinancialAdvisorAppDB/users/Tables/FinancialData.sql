CREATE TABLE [users].[FinancialData]
(
	[FinanceId] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[UserId] NVARCHAR (450) NOT NULL,
	[FinanceDate] DATE NOT NULL,
	[FinanceTypeId] INT NOT NULL,
	[DueDate] DATE NOT NULL,
	[GoalType] NVARCHAR(100) NOT NULL,
	[GoalValue] MONEY NOT NULL,
	[GoalStartDate] DATE NOT NULL,
	CONSTRAINT [FK_FinancialData_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_FinancialData_FinancialTypes_FinanceTypeId] FOREIGN KEY ([FinanceTypeId]) REFERENCES [ref].[FinanceTypes] ([FinanceTypeId]) ON DELETE CASCADE
)
