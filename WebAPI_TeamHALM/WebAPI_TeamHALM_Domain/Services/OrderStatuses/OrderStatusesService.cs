using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class OrderStatusesService : IOrderStatusesService
    {
        private readonly IOrderStatusesRepository _orderStatusesRepository;

        public OrderStatusesService(IOrderStatusesRepository orderStatusesRepository)
        {
            _orderStatusesRepository = orderStatusesRepository;
        }

        public async Task<IEnumerable<OrderStatuses>> GetOrderStatuses()
        {
            return await _orderStatusesRepository.GetOrderStatuses();
        }

        public async Task<OrderStatuses> GetOrderStatus(int id)
        {
            return await _orderStatusesRepository.GetOrderStatus(id);
        }
    }
}
