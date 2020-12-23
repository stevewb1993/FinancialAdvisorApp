CREATE PROCEDURE [dbo].[PostDeployment]
AS

MERGE INTO ref.FinanceTypes as TARGET
USING (VALUES
	(1, 'Current Account')
	,(2, 'Pension')
	,(3, 'Savings')
	,(4, 'Expenses')
	,(5, 'Housing Assets')
	,(6, 'Other liquid Investments')
	,(7, 'Other Illiquid Investments')
	,(8, 'Mortgage Monthly Cost')
	,(9, 'Rent Monthly Cost')
	,(10, 'Debt')
	,(11, 'Total Monthly Expenses')
	,(12, 'Necessary Monthly Expenses'))
AS SOURCE ([FinanceTypeId], [FinanceDesc])
ON TARGET.[FinanceTypeId] = Source.[FinanceTypeId]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([FinanceTypeId], [FinanceDesc]) 
VALUES ([FinanceTypeId], [FinanceDesc]);
