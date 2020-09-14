using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_TeamHALM_Domain;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderHistoryController : Controller
    {
        private readonly IOrderHistoryService _orderHistoryService;

        public OrderHistoryController(IOrderHistoryService orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }

        public async Task<IActionResult> Get()
        {
            return Ok(await _orderHistoryService.GetOrderHistory());
        }

        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _orderHistoryService.GetOrderHistory(id));
        }
    }
}
