using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class FullOrderDetailsService : IFullOrderDetailsService
    {
        private readonly IFullOrderDetailsRepository _fullOrderDetailsRepository;

        public FullOrderDetailsService(IFullOrderDetailsRepository fullOrderDetailsRepository)
        {
            _fullOrderDetailsRepository = fullOrderDetailsRepository;
        }

        public async Task<IEnumerable<FullOrderDetails>> GetFullOrderDetails()
        {
            return await _fullOrderDetailsRepository.GetFullOrderDetails();
        }

        public async Task<FullOrderDetails> GetFullOrderDetails(int id)
        {
            return await _fullOrderDetailsRepository.GetFullOrderDetails(id);
        }
    }
}
