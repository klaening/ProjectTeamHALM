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
    public class FullOrderDetailsController : Controller
    {
        private readonly IFullOrderDetailsService _fullOrderDetailsService;

        public FullOrderDetailsController(IFullOrderDetailsService fullOrderDetailsService)
        {
            _fullOrderDetailsService = fullOrderDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _fullOrderDetailsService.GetFullOrderDetails());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _fullOrderDetailsService.GetFullOrderDetails(id));
        }
    }
}
