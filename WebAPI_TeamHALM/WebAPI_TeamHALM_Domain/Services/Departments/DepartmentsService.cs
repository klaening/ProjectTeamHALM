using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDepartmentsRepository _departmentsRepository;

        public DepartmentsService(IDepartmentsRepository departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }

        public async Task<IEnumerable<Departments>> GetDepartments()
        {
            return await _departmentsRepository.GetDepartments();
        }

        public async Task<Departments> GetDepartment(int id)
        {
            return await _departmentsRepository.GetDepartment(id);
        }
    }
}
