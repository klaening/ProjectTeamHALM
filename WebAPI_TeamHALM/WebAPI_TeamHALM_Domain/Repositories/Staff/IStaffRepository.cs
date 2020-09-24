using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_TeamHALM_Domain
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetStaff();
        Task<Staff> GetStaff(int id);
    }
}
