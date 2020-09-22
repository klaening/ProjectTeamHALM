using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class WorkOrdersRepository : IWorkOrdersRepository
    {
        private readonly string _connectionString;

        public WorkOrdersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> AddWorkOrder(WorkOrders workOrder)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("INSERT INTO WorkOrders( OrderDescription, StartingDate, Commentary, HoursSpent, TravelTime, ExtraCosts, StaffID, OrderStatusesID, CustomersID, OrderTitle ) " +
                        "VALUES (@orderDescription, @startingDate, @commentary, @hoursSpent, @travelTime, @extraCosts, @staffID, @orderStatusesID, @customersID, @orderTitle) ",
                        new { workOrder.OrderDescription, workOrder.StartingDate, workOrder.Commentary, workOrder.HoursSpent, workOrder.TravelTime, workOrder.ExtraCosts, 
                            workOrder.StaffID, workOrder.OrderStatusesID, workOrder.CustomersID, workOrder.OrderTitle });

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteWorkOrder(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("DELETE FROM WorkOrders WHERE ID = @id", new { id });
                    
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            } 
        }

        public async Task<IEnumerable<WorkOrders>> GetWorkOrders()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<WorkOrders>("SELECT * FROM WorkOrders");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<WorkOrders> GetWorkOrder(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryFirstOrDefaultAsync<WorkOrders>("SELECT * FROM WorkOrders WHERE ID = @id", new { id });
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<bool> UpdateWorkOrder(WorkOrders workOrder)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("UPDATE WorkOrders SET OrderDescription = @orderDescription, StartingDate = @startingDate, Commentary = @commentary, " +
                        "HoursSpent = @hoursSpent, TravelTime = @travelTime, ExtraCosts = @extraCosts, StaffID = @staffID, OrderStatusesID = @orderStatusesID, " +
                        "CustomersID = @customersID, OrderTitle = @orderTitle WHERE ID = @ID", 
                        new { workOrder.OrderDescription, workOrder.StartingDate, workOrder.Commentary, workOrder.HoursSpent, workOrder.TravelTime, workOrder.ExtraCosts, 
                            workOrder.StaffID, workOrder.OrderStatusesID, workOrder.CustomersID, workOrder.OrderTitle, workOrder.ID });

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<object> UpdateWorkOrder(FullOrderDetails order, int statusId)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("UPDATE WorkOrders SET OrderStatusesID = @statusId WHERE ID = @id", new { statusId, order.ID });

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
