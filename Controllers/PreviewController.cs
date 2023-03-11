using APIApplication.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private readonly IPreviewService _previewService;
        public PreviewController(IPreviewService previewService)
        {
            _previewService = previewService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var get = await _previewService.GetAll();
            if (get.Success == false)
            {
                return BadRequest(get);
            }
            return Ok(get);
        }

        [HttpGet("GetPreview/{id}")]
        public async Task<IActionResult> GetPreviewById([FromRoute] int id)
        {
            var get = await _previewService.GetById(id);
            if (get.Success == false)
            {
                return BadRequest(get);
            }
            return Ok(get);
        }
    }
}