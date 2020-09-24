using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public interface ICustomersService
    {
        Task<bool> AddCustomer(Customers customer);
        Task<IEnumerable<Customers>> GetCustomers();
        Task<Customers> GetCustomer(int id);
        Task<bool> UpdateCustomer(Customers customer);
        Task<bool> DeleteCustomer(int id);
    }
}
