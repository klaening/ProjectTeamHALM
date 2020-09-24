using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public interface IFullOrderDetailsService
    {
        Task<IEnumerable<FullOrderDetails>> GetFullOrderDetails();
        Task<FullOrderDetails> GetFullOrderDetails(int id);
    }
}
