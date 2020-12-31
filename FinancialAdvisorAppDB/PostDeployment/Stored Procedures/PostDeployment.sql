CREATE PROCEDURE [dbo].[PostDeployment]
AS

MERGE INTO ref.FinanceTypes as TARGET
USING (VALUES
	(1, 'Current Account', 'Stock', 'Asset', 'Liquid')
	,(2, 'Pension', 'Stock', 'Asset','Illiquid')
	,(3, 'Savings', 'Stock', 'Asset','Liquid')
	,(4, 'Total Monthly Expenses', 'Flow', 'Outgoings', null)
	,(5, 'Housing Assets', 'Stock', 'Asset', 'Illiquid')
	,(6, 'Other liquid Investments', 'Stock', 'Asset', 'Liquid')
	,(7, 'Other Illiquid Investments', 'Stock', 'Asset', 'Illiquid')
	,(8, 'Mortgage Monthly Cost', 'Flow', 'Outgoings', null)
	,(9, 'Rent Monthly Cost', 'Flow', 'Outgoings', null)
	,(10, 'Debt', 'Stock', 'Liability', null)
	,(11, 'Monthly Salary Income Post-Tax', 'Flow', 'Incomings', null)
	,(12, 'Other Necessary Monthly Expenses', 'Flow', 'Outgoings', null))
AS SOURCE ([FinanceTypeId], [FinanceDesc], [StockOrFlow], [Category], [Liquidity])
ON TARGET.Id = Source.[FinanceTypeId] and TARGET.FinanceDesc = Source.FinanceDesc and TARGET.StockOrFlow = Source.StockOrFlow AND TARGET.[Category] = SOURCE.[Category] AND (TARGET.[Liquidity] = SOURCE.[Liquidity] or source.[Liquidity] is null)
WHEN NOT MATCHED BY SOURCE THEN DELETE
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, [FinanceDesc], [StockOrFlow], [Category], [Liquidity]) 
VALUES ([FinanceTypeId], [FinanceDesc], [StockOrFlow], [Category], [Liquidity]);
