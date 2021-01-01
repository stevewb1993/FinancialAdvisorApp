CREATE TABLE [users].[FinancialStats]
(
	Id INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[UserId] INT NOT NULL,
	[FinanceDate] DATE NOT NULL,
	[UserFriendlyName] VARCHAR(100) NULL,
	[FinanceTypeId] INT NOT NULL,
	[FinanceValue] MONEY NOT NULL,
	[InterestRate] DECIMAL(6,3) NULL,
	CONSTRAINT [FK_FinancialStats_UserDetails_UserId] FOREIGN KEY ([UserId]) REFERENCES [users].[userdetails] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_FinancialStats_FinancialTypes_FinanceTypeId] FOREIGN KEY ([FinanceTypeId]) REFERENCES [ref].[FinanceTypes] (Id) ON DELETE CASCADE
)
