CREATE TABLE [users].[FinancialStats]
(
	Id NVARCHAR (450) NOT NULL PRIMARY KEY,
	[UserId] NVARCHAR (450) NOT NULL,
	[FinanceDate] DATE NOT NULL,
	[FinanceTypeId] NVARCHAR (450) NOT NULL,
	[FinanceValue] MONEY NOT NULL,
	CONSTRAINT [FK_FinancialStats_UserDetails_UserId] FOREIGN KEY ([UserId]) REFERENCES [users].[userdetails] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_FinancialStats_FinancialTypes_FinanceTypeId] FOREIGN KEY ([FinanceTypeId]) REFERENCES [ref].[FinanceTypes] (Id) ON DELETE CASCADE
)
GO
CREATE UNIQUE INDEX NCI_uq_FinancialStats
  ON [users].[FinancialStats](UserId, FinanceDate, FinanceTypeId);
