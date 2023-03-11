using APIApplication.DTOs.ResponseModel;

namespace APIApplication.Interfaces.Services
{
    public interface IPreviewService
    {
        Task<PreviewsResponseModel> GetAll();
        Task<PreviewResponseModel> GetById(int id);
    }
}