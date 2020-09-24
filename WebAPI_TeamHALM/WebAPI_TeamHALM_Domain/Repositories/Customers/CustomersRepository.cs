using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly string _connectionString;

        public CustomersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> AddCustomer(Customers customer)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("INSERT INTO Customers (CustomerName, CustomerAddress, CustomerPhoneNo) VALUES (@customerName, @customerAddress, @customerPhoneNo)", 
                        new { customer.CustomerName, customer.CustomerAddress, customer.CustomerPhoneNo});

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<Customers>("SELECT * FROM Customers");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<Customers> GetCustomer(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryFirstOrDefaultAsync<Customers>("SELECT * FROM Customers WHERE ID = @id", new { id });
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<bool> UpdateCustomer(Customers customer)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("UPDATE Customers SET CustomerName = @customerName, CustomerAddress = @customerAddress, CustomerPhoneNo = @customerPhoneNo WHERE ID = @id", 
                        new { customer.CustomerName, customer.CustomerAddress, customer.CustomerPhoneNo, customer.ID});

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("DELETE FROM Customers WHERE ID = @id", new { id });

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
