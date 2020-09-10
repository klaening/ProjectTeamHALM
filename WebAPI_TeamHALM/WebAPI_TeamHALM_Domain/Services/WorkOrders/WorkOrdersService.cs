using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_TeamHALM_Domain.Models;

namespace WebAPI_TeamHALM_Domain
{
    public class WorkOrdersService : IWorkOrdersService
    {
        private readonly IWorkOrdersRepository _workOrdersRepository;

        public WorkOrdersService(IWorkOrdersRepository workOrdersRepository)
        {
            _workOrdersRepository = workOrdersRepository;
        }

        public async Task<bool> AddWorkOrder(WorkOrders workOrder)
        {
            return await _workOrdersRepository.AddWorkOrder(workOrder);
        }

        public async Task<bool> DeleteWorkOrder(int id)
        {
            return await _workOrdersRepository.DeleteWorkOrder(id);
        }

        public async Task<IEnumerable<WorkOrders>> GetWorkOrders()
        {
            return await _workOrdersRepository.GetWorkOrders();
        }

        public async Task<WorkOrders> GetWorkOrder(int id)
        {
            return await _workOrdersRepository.GetWorkOrder(id);
        }

        public async Task<bool> UpdateWorkOrder(WorkOrders workOrder)
        {
            return await _workOrdersRepository.UpdateWorkOrder(workOrder);
        }
    }
}
