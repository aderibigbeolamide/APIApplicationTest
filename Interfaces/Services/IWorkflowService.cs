using APIApplication.DTOs.RequestModel;
using APIApplication.DTOs.ResponseModel;

namespace APIApplication.Interfaces.Services
{
    public interface IWorkflowService
    {
        Task<BaseResponseModel> UpdateWorkflow(UpdateWorkflowRequestModel model, string stageName);
        Task<WorkflowsResponseModel> GetAll();
        Task<WorkflowResponseModel> GetById(string Name);
    }
}