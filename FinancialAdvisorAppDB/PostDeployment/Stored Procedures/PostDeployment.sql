CREATE PROCEDURE [dbo].[PostDeployment]
AS


MERGE INTO ref.FinanceTypes as TARGET
USING (VALUES
	(1, 'Current Account', 'Stock')
	,(2, 'Pension', 'Stock')
	,(3, 'Savings', 'Stock')
	,(4, 'Expenses', 'Flow')
	,(5, 'Housing Assets', 'Stock')
	,(6, 'Other liquid Investments', 'Stock')
	,(7, 'Other Illiquid Investments', 'Stock')
	,(8, 'Mortgage Monthly Cost', 'Flow')
	,(9, 'Rent Monthly Cost', 'Flow')
	,(10, 'Debt', 'Stock')
	,(11, 'Total Monthly Expenses', 'Flow')
	,(12, 'Necessary Monthly Expenses', 'Flow'))
AS SOURCE ([FinanceTypeId], [FinanceDesc], [StockOrFlow])
ON TARGET.Id = Source.[FinanceTypeId] and TARGET.FinanceDesc = Source.FinanceDesc and TARGET.StockOrFlow = Source.StockOrFlow
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, [FinanceDesc], [StockOrFlow]) 
VALUES ([FinanceTypeId], [FinanceDesc], [StockOrFlow]);