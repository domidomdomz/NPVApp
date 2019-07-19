CREATE TABLE [dbo].[CalculateNPVRequests]
(
	[Id] INT IDENTITY NOT NULL CONSTRAINT PK_CalculateNPVRequests PRIMARY KEY, 
    [InitialInvestment] DECIMAL(18, 2) NULL, 
    [LowerBoundDiscountRate] DECIMAL(5, 4) NULL, 
    [UpperBoundDiscountRate] DECIMAL(5, 4) NULL, 
    [DiscountRateIncrement] DECIMAL(5, 4) NULL, 
    [CreateDate] DATETIME2 NOT NULL CONSTRAINT DF_CalculateNPVRequests_CreateDate DEFAULT GETUTCDATE()
)
