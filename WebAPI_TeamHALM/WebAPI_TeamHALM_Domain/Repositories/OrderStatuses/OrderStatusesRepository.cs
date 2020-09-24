using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class OrderStatusesRepository : IOrderStatusesRepository
    {
        private readonly string _connectionString;

        public OrderStatusesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<OrderStatuses>> GetOrderStatuses()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<OrderStatuses>("SELECT * FROM OrderStatuses");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<OrderStatuses> GetOrderStatus(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryFirstOrDefaultAsync<OrderStatuses>("SELECT * FROM OrderStatuses WHERE ID = @id", new { id });
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
