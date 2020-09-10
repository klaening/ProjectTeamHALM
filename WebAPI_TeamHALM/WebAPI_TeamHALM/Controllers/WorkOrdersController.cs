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
    public class WorkOrdersController : Controller
    {
        private IWorkOrdersService _workOrdersService;

        public WorkOrdersController(IWorkOrdersService workOrdersService)
        {
            _workOrdersService = workOrdersService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] WorkOrders workOrders)
        {
            return Ok(await _workOrdersService.AddWorkOrder(workOrders));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _workOrdersService.GetWorkOrders());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _workOrdersService.GetWorkOrder(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WorkOrders workOrder)
        {
            return Ok(await _workOrdersService.UpdateWorkOrder(workOrder));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _workOrdersService.DeleteWorkOrder(id));
        }
    }
}
