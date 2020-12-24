﻿CREATE TABLE [users].[FinancialStats]
(
	Id INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[UserId] NVARCHAR (450) NOT NULL,
	[FinanceDate] DATE NOT NULL,
	[FinanceTypeId] INT NOT NULL,
	[FinanceValue] MONEY NOT NULL,
	CONSTRAINT [FK_FinancialStats_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_FinancialStats_FinancialTypes_FinanceTypeId] FOREIGN KEY ([FinanceTypeId]) REFERENCES [ref].[FinanceTypes] (Id) ON DELETE CASCADE
)
