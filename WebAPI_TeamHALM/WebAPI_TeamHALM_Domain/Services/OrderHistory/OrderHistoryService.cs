using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;

        public OrderHistoryService(IOrderHistoryRepository orderHistoryRepository)
        {
            _orderHistoryRepository = orderHistoryRepository;
        }

        public async Task<IEnumerable<OrderHistory>> GetOrderHistory()
        {
            return await _orderHistoryRepository.GetOrderHistory();
        }

        public async Task<OrderHistory> GetOrderHistory(int id)
        {
            return await _orderHistoryRepository.GetOrderHistory(id);
        }
    }
}
