using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<bool> AddCustomer(Customers customer)
        {
            return await _customersRepository.AddCustomer(customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customersRepository.DeleteCustomer(id);
        }

        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            return await _customersRepository.GetCustomers();
        }

        public async Task<Customers> GetCustomer(int id)
        {
            return await _customersRepository.GetCustomer(id);
        }

        public async Task<bool> UpdateCustomer(Customers customer)
        {
            return await _customersRepository.UpdateCustomer(customer);
        }
    }
}
