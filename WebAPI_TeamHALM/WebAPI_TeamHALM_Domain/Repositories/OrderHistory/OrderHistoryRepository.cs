using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly string _connectionString;

        public OrderHistoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> AddOrderHistory(OrderHistory orderHistory)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("INSERT INTO OrderHistory( ID, OrderDescription, StartingDate, Commentary, HoursSpent, TravelTime, ExtraCosts, StaffID, OrderStatusesID, CustomersID ) " +
                        "VALUES (@id, @orderDescription, @startingDate, @commentary, @hoursSpent, @travelTime, @extraCosts, @staffID, @orderStatusesID, @customersID) ",
                        new { orderHistory.ID, orderHistory.OrderDescription, orderHistory.StartingDate, orderHistory.Commentary, orderHistory.HoursSpent, 
                            orderHistory.TravelTime, orderHistory.ExtraCosts, orderHistory.StaffID, orderHistory.OrderStatusesID, orderHistory.CustomersID });

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteOrderHistory(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("DELETE FROM OrderHistory WHERE ID = @id", new { id });

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<IEnumerable<OrderHistory>> GetOrderHistory()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<OrderHistory>("SELECT * FROM OrderHistory");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<OrderHistory> GetOrderHistory(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryFirstOrDefaultAsync<OrderHistory>("SELECT * FROM OrderHistory WHERE ID = @id", new { id });
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<bool> UpdateOrderHistory(OrderHistory orderHistory)
        {
            using (var c = new SqlConnection())
            {
                try
                {
                    await c.ExecuteAsync("UPDATE OrderHistory SET OrderDescription = @orderDescription, StartingDate = @startingDate, Commentary = @commentary, " +
                        "HoursSpent = @hoursSpent, TravelTime = @travelTime, ExtraCosts = @extraCosts, StaffID = @staffID, OrderStatusesID = @orderStatusesID, " +
                        "CustomersID = @customersID WHERE ID = @ID",
                        new { orderHistory.OrderDescription, orderHistory.StartingDate, orderHistory.Commentary, orderHistory.HoursSpent, orderHistory.TravelTime, 
                            orderHistory.ExtraCosts, orderHistory.StaffID, orderHistory.OrderStatusesID, orderHistory.CustomersID, orderHistory.ID });

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
