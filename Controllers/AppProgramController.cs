using APIApplication.DTOs.RequestModel;
using APIApplication.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppProgramController : ControllerBase
    {
        private readonly IAppProgramService _appProgramService;
        public AppProgramController(IAppProgramService appProgramService)
        {
            _appProgramService = appProgramService;
        }

        [HttpPost("CreateProgram")]
        public async Task<IActionResult> CreateAppProgram([FromForm] CreateAppProgramRequestModel model)
        {
            var appProgram = await _appProgramService.CreateAppProgram(model);
            if (appProgram.Success == false)
            {
                return BadRequest(appProgram);
            }
            return Ok(appProgram);
        }

        [HttpPut("UpdateAppProgram/{id}")]
        public async Task<IActionResult> UpdateAppProgram([FromForm] UpdateAppProgramRequestModel model, [FromRoute] int id)
        {
            var update = await _appProgramService.UpdateAppProgram(model, id);
            if (update.Success == false)
            {
                return BadRequest(update);
            }
            return Ok(update);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var get = await _appProgramService.GetAll();
            if (get.Success == false)
            {
                return BadRequest(get);
            }
            return Ok(get);
        }

        [HttpGet("GetAppProgram/{id}")]
        public async Task<IActionResult> GetByAppProgramId([FromRoute] int id)
        {
            var get = await _appProgramService.GetById(id);
            if (get.Success == false)
            {
                return BadRequest(get);
            }
            return Ok(get);
        }
    }
}