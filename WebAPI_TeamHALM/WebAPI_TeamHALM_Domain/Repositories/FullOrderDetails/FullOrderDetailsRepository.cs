using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class FullOrderDetailsRepository : IFullOrderDetailsRepository
    {
        private readonly string _connectionString;

        public FullOrderDetailsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<FullOrderDetails>> GetFullOrderDetails()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<FullOrderDetails>("SELECT * FROM vw_FullOrderDetails");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<FullOrderDetails> GetFullOrderDetails(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryFirstOrDefaultAsync<FullOrderDetails>("SELECT * FROM vw_FullOrderDetails WHERE ID = @id", new { id });
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
