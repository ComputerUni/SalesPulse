using Dapper;
using SalesPulse.Core.DTOs.Common;
using SalesPulse.Core.DTOs.OrderExplorerDtos;
using SalesPulse.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.DataAccess.Repositories.OrderExplorers
{
    public class OrderExplorerRepository(AppDbContext _context) : IOrderExplorerRepository
    {
        public async Task<OrderExplorerDetailItemDto> GetOrderDetailItemAsync(string orderCode)
        {
            using var connection = _context.CreateConnection();
            OrderExplorerDetailItemDto? detail = null;
            await connection.QueryAsync<OrderExplorerDetailItemDto, OrderExplorerDetailProductItemDto, OrderExplorerDetailItemDto>(
                "sp_GetOrderDetailByOrderCode",
                (order, product) =>
                {
                    if (detail == null)
                    {
                        detail = order;
                        detail.OrderCode = orderCode;
                    }

                    if (product != null && !string.IsNullOrEmpty(product.ProductName))
                    {
                        detail.OrderItems.Add(product);
                    }

                    return order;
                },
                new {OrderCode = orderCode},
                splitOn: "ProductName",
                commandType: CommandType.StoredProcedure
            );

            if (detail != null)
            {
                detail.TotalAmount = detail.OrderItems.Sum(x => x.LineTotal);
            }
            return detail;
        }

        public async Task<PagedResult<OrderExplorerListItemDto>> OrderExplorerListItemAsync(OrderExplorerFilterDto filter)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Page", filter.Page, DbType.Int32);
            parameters.Add("@PageSize", filter.PageSize, DbType.Int32);
            parameters.Add("@SearchTerm", string.IsNullOrWhiteSpace(filter.SearchTerm) ? null : filter.SearchTerm.Trim(), DbType.String);
            parameters.Add("@StartDate", filter.StartDate, DbType.DateTime);
            parameters.Add("@EndDate", filter.EndDate, DbType.DateTime);
            parameters.Add("@CityId", filter.CityId, DbType.Int32);
            parameters.Add("@Status", string.IsNullOrWhiteSpace(filter.Status) ? null : filter.Status.Trim(), DbType.String);
            parameters.Add("@PaymentMethod", string.IsNullOrWhiteSpace(filter.PaymentMethod) ? null : filter.PaymentMethod.Trim(), DbType.String);
            parameters.Add("@MinAmount", filter.MinAmount, DbType.Decimal);
            parameters.Add("@MaxAmount", filter.MaxAmount, DbType.Decimal);


            using var multi = await connection.QueryMultipleAsync(
                "sp_GetOrderExplorerPagedList",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60
            );

            int totalCount = await multi.ReadFirstAsync<int>();
            var items = (await multi.ReadAsync<OrderExplorerListItemDto>()).ToList();
            return new PagedResult<OrderExplorerListItemDto>
            {
                Items = items,
                TotalCount = totalCount,
                Page = filter.Page,
                PageSize = filter.PageSize,
            };
        }
    }
}
