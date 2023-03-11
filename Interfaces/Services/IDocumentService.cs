using APIApplication.DTOs.ResponseModel;

namespace APIApplication.Interfaces.Services
{
    public interface IDocumentService
    {
        Task<BaseResponseModel> Resume(string model);
    }
}
