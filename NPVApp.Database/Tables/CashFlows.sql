CREATE TABLE [dbo].[CashFlows]
(
	[Id] INT IDENTITY NOT NULL CONSTRAINT PK_CashFlows PRIMARY KEY, 
    [RequestId] INT NULL,
	[CashFlowValue] DECIMAL(18, 2) NULL, 
    [CashFlowOrder] INT NULL, 
    [CreateDate] DATETIME2 NULL, 
    -- unique/foreign constraints
	CONSTRAINT FK_CashFlows_RequestId FOREIGN KEY (RequestId) REFERENCES dbo.CalculateNPVRequests(Id)
)
