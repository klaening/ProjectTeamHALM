using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_TeamHALM_Domain
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<IEnumerable<Staff>> GetStaff()
        {
            return await _staffRepository.GetStaff();
        }

        public async Task<Staff> GetStaff(int id)
        {
            return await _staffRepository.GetStaff(id);
        }
    }
}
