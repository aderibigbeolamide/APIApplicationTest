using APIApplication.DTOs;
using APIApplication.DTOs.ResponseModel;
using APIApplication.Interfaces.Repositories;
using APIApplication.Interfaces.Services;

namespace APIApplication.Implementations.Services
{
    public class PreviewService : IPreviewService
    {
        private readonly IPreviewRepository _previewRepository;

        public PreviewService(IPreviewRepository previewRepository)
        {
            _previewRepository = previewRepository;
        }

        public async Task<PreviewsResponseModel> GetAll()
        {
            var check = await _previewRepository.GetAll();
            var previews = check.Select(x => new PreviewDTO
            {
               ProgramId = x.ProgramId,
               Publish = x.Publish,
            }).ToList();
            if (check == null)
            {
                return new PreviewsResponseModel
                {
                    Message = "No Preview Available",
                    Success = true
                };
            }
            return new PreviewsResponseModel
            {
                Success = true,
                Data = previews,
                Message = "List of Forms",
            };
        }

        public async Task<PreviewResponseModel> GetById(int id)
        {
            var preview = await _previewRepository.GetPreview(id);
            if (preview == null)
            {
                return new PreviewResponseModel
                {
                    Message = "Preview not Available",
                    Success = true
                };
            }
            var previewDTO = new PreviewDTO
            {
                ProgramId = preview.ProgramId,
                Publish = preview.Publish,
            };
            return new PreviewResponseModel
            {
                Message = "Preview fund",
                Success = true,
            };
        }
    }
}