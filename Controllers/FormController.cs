using APIApplication.DTOs.RequestModel;
using APIApplication.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FormController(IFormService formService, IWebHostEnvironment webHostEnvironment)
        {
            _formService = formService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("CreateForm")]
        public async Task<IActionResult> CreateForm([FromForm]CreateFormRequestModel model)
        {
            var files = HttpContext.Request.Form;

            if (files != null && files.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                Directory.CreateDirectory(imageDirectory);
                foreach (var file in files.Files)
                {
                    FileInfo info = new FileInfo(file.FileName);
                    string image = Guid.NewGuid().ToString() + info.Extension;
                    string path = Path.Combine(imageDirectory, image);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    model.Image = (image);
                }
            }

            var createForm = await _formService.CreateForm(model);
            if (createForm.Success == false)
            {
                return BadRequest(createForm);
            }
            return Ok(createForm);
        }

        [HttpPut("UpdateAdmin/{id}")]
        public async Task<IActionResult> UpdateForm([FromForm]UpdateFormRequestModel model, [FromRoute]int id)
        {
            var files = HttpContext.Request.Form;

            if (files != null && files.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                Directory.CreateDirectory(imageDirectory);
                foreach (var file in files.Files)
                {
                    FileInfo info = new FileInfo(file.FileName);
                    string image = Guid.NewGuid().ToString() + info.Extension;
                    string path = Path.Combine(imageDirectory, image);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    model.Image = (image);
                }
            }

            var updateForm = await _formService.UpdateForm(model, id);
            if (updateForm.Success == false)
            {
                return BadRequest(updateForm);
            }
            return Ok(updateForm);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _formService.GetAll();
            if (list.Success == false)
            {
                return BadRequest(list);
            }
            return Ok(list);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var admin = await _formService.GetById(id);
            if (admin.Success == false)
            {
                return BadRequest(admin);
            }
            return Ok(admin);
        }
    }
}
