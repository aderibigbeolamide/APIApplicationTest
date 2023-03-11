using APIApplication.DTOs.RequestModel;
using APIApplication.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIApplication.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;
        public WorkflowController(IWorkflowService workflowService)
        {
            _workflowService = workflowService;
        }


        [HttpPut("UpdateWorkflow/{id}")]
        public async Task<IActionResult> UpdateWorkflow([FromForm] UpdateWorkflowRequestModel model, [FromRoute] string Name)
        {
            var update = await _workflowService.UpdateWorkflow(model, Name);
            if (update.Success == false)
            {
                return BadRequest(update);
            }
            return Ok(update);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var get = await _workflowService.GetAll();
            if (get.Success == false)
            {
                return BadRequest(get);
            }
            return Ok(get);
        }

        [HttpGet("GetWorkflow/{id}")]
        public async Task<IActionResult> GetWorkflowById([FromRoute] string stageName)
        {
            var get = await _workflowService.GetById(stageName);
            if (get.Success == false)
            {
                return BadRequest(get);
            }
            return Ok(get);
        }
    }
}