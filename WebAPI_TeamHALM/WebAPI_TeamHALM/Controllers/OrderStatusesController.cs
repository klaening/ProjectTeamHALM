using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_TeamHALM_Domain;

namespace WebAPI_TeamHALM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderStatusesController : Controller
    {
        private readonly IOrderStatusesService _orderStatusesService;

        public OrderStatusesController(IOrderStatusesService orderStatusesService)
        {
            _orderStatusesService = orderStatusesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _orderStatusesService.GetOrderStatuses());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _orderStatusesService.GetOrderStatus(id));
        }
    }
}
