CREATE TABLE [dbo].[CalculateNPVResults]
(
	[Id] INT IDENTITY NOT NULL CONSTRAINT PK_CalculateNPVResults PRIMARY KEY, 
    [RequestId] INT NULL,
	[DiscountRate] DECIMAL(5, 4) NULL, 
    [NetPresentValue] DECIMAL(18, 2) NULL, 
    [CreateDate] DATETIME2 NOT NULL CONSTRAINT DF_CalculateNPVResults_CreateDate DEFAULT GETUTCDATE(), 
    -- unique/foreign constraints
	CONSTRAINT FK_CalculateNPVResults_RequestId FOREIGN KEY (RequestId) REFERENCES dbo.CalculateNPVRequests(Id)
)
