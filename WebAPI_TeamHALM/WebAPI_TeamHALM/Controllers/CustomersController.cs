using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_TeamHALM_Domain;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Customers customer)
        {
            return Ok(await _customersService.AddCustomer(customer));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customersService.GetCustomers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _customersService.GetCustomer(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Customers customer)
        {
            return Ok(await _customersService.UpdateCustomer(customer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _customersService.DeleteCustomer(id));
        }
    }
}
