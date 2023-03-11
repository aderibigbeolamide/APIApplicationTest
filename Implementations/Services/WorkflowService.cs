using APIApplication.DTOs;
using APIApplication.DTOs.RequestModel;
using APIApplication.DTOs.ResponseModel;
using APIApplication.Interfaces.Repositories;
using APIApplication.Interfaces.Services;

namespace APIApplication.Implementations.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _workflowRepository;

        public WorkflowService(IWorkflowRepository workflowRepository)
        {
            _workflowRepository = workflowRepository;
        }

        public async Task<WorkflowsResponseModel> GetAll()
        {
            var check = await _workflowRepository.GetAll();
            var workflows = check.Select(x => new WorkflowDTO
            {
                StageName = x.StageName,
                StageType = x.StageType,
            }).ToList();
            if (check == null)
            {
                return new WorkflowsResponseModel
                {
                    Message = "Form not Fund",
                    Success = true
                };
            }
            return new WorkflowsResponseModel
            {
                Success = true,
                Data = workflows,
                Message = "List of Forms",
            };
        }

        public async Task<WorkflowResponseModel> GetById(string Name)
        {
            var workflow = await _workflowRepository.GetWorkflow(Name);
            if (workflow == null)
            {
                return new WorkflowResponseModel
                {
                    Message = "Workflow not Available",
                    Success = true
                };
            }
            var workflowDTO = new WorkflowDTO
            {
                StageName = workflow.StageName,
                StageType = workflow.StageType,
            };
            return new WorkflowResponseModel
            {
                Message = "Workflow fund",
                Success = true,
            };
        }

        public async Task<BaseResponseModel> UpdateWorkflow(UpdateWorkflowRequestModel model, string stageName)
        {
            var workflow = await _workflowRepository.Get(x => x.StageName == stageName);
            if (workflow == null)
            {
                return new BaseResponseModel
                {
                    Message = "Workflow not found",
                    Success = false
                };
            }
            workflow.StageName = model.StageName;
            workflow.StageType = model.StageType;
            await _workflowRepository.Update(workflow);
            return new BaseResponseModel
            {
                Message = "Workflow Updated Successfully",
                Success = false
            };
        }
    }
}