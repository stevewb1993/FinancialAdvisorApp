CREATE TABLE [ref].[FinanceTypes]
(
	Id INT IDENTITY (1,1) PRIMARY KEY,
	[FinanceDesc] NVARCHAR (200) NOT NULL,
	[StockOrFlow] NVARCHAR(5) NOT NULL,
	[Category] NVARCHAR(5) NOT NULL,
	[Liquidity] [varchar](10) NULL
)
