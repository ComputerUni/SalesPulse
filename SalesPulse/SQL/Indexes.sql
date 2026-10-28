IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Customers_Email' AND object_id = OBJECT_ID('dbo.Customers'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Customers_Email] ON [dbo].[Customers] ([Email] ASC);
END;
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Customers_FirstName' AND object_id = OBJECT_ID('dbo.Customers'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Customers_FirstName] ON [dbo].[Customers] ([FirstName] ASC) INCLUDE ([LastName], [Email], [
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Customers_LastName' AND object_id = OBJECT_ID('dbo.Customers'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Customers_LastName] ON [dbo].[Customers] ([LastName] ASC);
END;
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_OrderDetails_OrderId_Covering' AND object_id = OBJECT_ID('dbo.OrderDetails'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId_Covering] ON [dbo].[OrderDetails] ([OrderId] ASC) INCLUDE
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_OrderDetails_OrderId_ProductId' AND object_id = OBJECT_ID('dbo.OrderDetails'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_OrderDetails_OrderId_ProductId] ON [dbo].[OrderDetails] ([OrderId] ASC) INCLU
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_OrderDetails_ProductId' AND object_id = OBJECT_ID('dbo.OrderDetails'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId] ON [dbo].[OrderDetails] ([ProductId] ASC) INCLUDE ([Quantity]
NULL
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CityId_CreatedAt_Id' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_CityId_CreatedAt_Id] ON [dbo].[Orders] ([CityId] ASC, [CreatedAt] DESC, [Id] DES
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CreatedAt' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_CreatedAt] ON [dbo].[Orders] ([CreatedAt] ASC) INCLUDE ([Id]);
END;
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CreatedAt_CityId' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_CreatedAt_CityId] ON [dbo].[Orders] ([CreatedAt] ASC) INCLUDE ([Id], [CityId], [Tot
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CreatedAt_Covering' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_CreatedAt_Covering] ON [dbo].[Orders] ([CreatedAt] ASC) INCLUDE ([CustomerId], [T
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CreatedAt_Id' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_CreatedAt_Id] ON [dbo].[Orders] ([CreatedAt] DESC, [Id] DESC);
END;
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CreatedAt_Kpi' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_CreatedAt_Kpi] ON [dbo].[Orders] ([CreatedAt] ASC) INCLUDE ([Id], [CustomerId], [Total
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CreatedAt_Status' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_CreatedAt_Status] ON [dbo].[Orders] ([CreatedAt] ASC, [Status] ASC) INCLUDE ([Id]);
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CreatedAt_TotalAmount' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_CreatedAt_TotalAmount] ON [dbo].[Orders] ([CreatedAt] ASC) INCLUDE ([TotalAmou
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CustomerId' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_CustomerId] ON [dbo].[Orders] ([CustomerId] ASC) INCLUDE ([CreatedAt], [Status], [CityId]
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CustomerId_CreatedAt' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_CustomerId_CreatedAt] ON [dbo].[Orders] ([CustomerId] ASC, [CreatedAt] ASC) INC
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_OrderCode' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE UNIQUE NONCLUSTERED INDEX [IX_Orders_OrderCode] ON [dbo].[Orders] ([OrderCode] ASC);
END;
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_Status_CreatedAt_Id' AND object_id = OBJECT_ID('dbo.Orders'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Orders_Status_CreatedAt_Id] ON [dbo].[Orders] ([Status] ASC, [CreatedAt] DESC, [Id] DES
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Payments_OrderId' AND object_id = OBJECT_ID('dbo.Payments'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Payments_OrderId] ON [dbo].[Payments] ([OrderId] ASC) INCLUDE ([PaymentMethod]);
END;
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Payments_PaymentMethod_OrderId' AND object_id = OBJECT_ID('dbo.Payments'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Payments_PaymentMethod_OrderId] ON [dbo].[Payments] ([PaymentMethod] ASC) INCLUDE
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Products_CategoryId' AND object_id = OBJECT_ID('dbo.Products'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products] ([CategoryId] ASC) INCLUDE ([Name], [Price], [Stock

