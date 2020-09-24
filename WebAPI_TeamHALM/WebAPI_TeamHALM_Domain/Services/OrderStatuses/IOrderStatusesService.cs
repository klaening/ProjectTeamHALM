using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public interface IOrderStatusesService
    {
        Task<IEnumerable<OrderStatuses>> GetOrderStatuses();
        Task<OrderStatuses> GetOrderStatus(int id);
    }
}
