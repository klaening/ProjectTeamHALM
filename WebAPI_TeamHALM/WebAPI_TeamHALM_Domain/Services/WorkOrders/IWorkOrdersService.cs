using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public interface IWorkOrdersService
    {
        Task<bool> AddWorkOrder(WorkOrders workOrder);
        Task<IEnumerable<WorkOrders>> GetWorkOrders();
        Task<WorkOrders> GetWorkOrder(int id);
        Task<bool> UpdateWorkOrder(WorkOrders workOrder);
        Task<bool> DeleteWorkOrder(int id);
    }
}
