using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_TeamHALM_Domain
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetStaff();
        Task<Staff> GetStaff(int id);
    }
}
