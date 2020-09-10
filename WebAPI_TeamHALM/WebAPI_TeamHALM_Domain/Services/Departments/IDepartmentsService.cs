using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public interface IDepartmentsService
    {
        Task<IEnumerable<Departments>> GetDepartments();
        Task<Departments> GetDepartment(int id);
    }
}
