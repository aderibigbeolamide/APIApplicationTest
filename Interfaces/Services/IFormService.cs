using APIApplication.DTOs.RequestModel;
using APIApplication.DTOs.ResponseModel;

namespace APIApplication.Interfaces.Services
{
    public interface IFormService
    {
        Task<BaseResponseModel> CreateForm(CreateFormRequestModel model);
        Task<BaseResponseModel> UpdateForm(UpdateFormRequestModel model, int id);
        Task<FormsResponseModel> GetAll();
        Task<FormResponseModel> GetById(int id);
    }
}