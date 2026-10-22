CREATE PROCEDURE [dbo].[GetTopSellingProducts]
    @Offset INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Name AS ProductName,
        c.Name AS CategoryName,
        p.Price AS Price,
        p.Stock AS Stock,
        SUM(od.Quantity) AS SalesVolume,
        SUM(od.Quantity * od.UnitPrice) AS TotalRevenue
    FROM OrderDetails od
    INNER JOIN Products p ON od.ProductId = p.Id
    INNER JOIN Categories c ON p.CategoryId = c.Id
    GROUP BY od.ProductId, p.Name, c.Name, p.Price, p.Stock
    ORDER BY TotalRevenue DESC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
END