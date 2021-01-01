CREATE TABLE [ref].[FinanceTypes]
(
	Id INT PRIMARY KEY,
	[FinanceDesc] NVARCHAR (200) NOT NULL,
	[StockOrFlow] NVARCHAR(5) NOT NULL,
	[Category] NVARCHAR(50) NOT NULL,
	[Liquidity] varchar(10) NULL
)
