CREATE PROCEDURE [dbo].[PostDeployment]
AS


MERGE INTO ref.FinanceTypes as TARGET
USING (VALUES
	( 'Current Account', 'Stock')
	,('Pension', 'Stock')
	,('Savings', 'Stock')
	,('Expenses', 'Flow')
	,('Housing Assets', 'Stock')
	,('Other liquid Investments', 'Stock')
	,('Other Illiquid Investments', 'Stock')
	,('Mortgage Monthly Cost', 'Flow')
	,('Rent Monthly Cost', 'Flow')
	,( 'Debt', 'Stock')
	,( 'Total Monthly Expenses', 'Flow')
	,( 'Necessary Monthly Expenses', 'Flow'))
AS SOURCE ([FinanceDesc], [StockOrFlow])
ON TARGET.FinanceDesc = Source.FinanceDesc and TARGET.StockOrFlow = Source.StockOrFlow
WHEN NOT MATCHED BY TARGET THEN
INSERT ([FinanceDesc], [StockOrFlow]) 
VALUES ([FinanceDesc], [StockOrFlow]);