using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_TeamHALM.Data;
using WebAPI_TeamHALM_Domain;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentsController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _departmentsService.GetDepartments());
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _departmentsService.GetDepartment(id));
        }
    }
}
