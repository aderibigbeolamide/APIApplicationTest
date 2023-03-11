using APIApplication.DTOs.RequestModel;
using APIApplication.DTOs.ResponseModel;

namespace APIApplication.Interfaces.Services
{
    public interface IAppProgramService
    {
        Task<BaseResponseModel> CreateAppProgram(CreateAppProgramRequestModel model);
        Task<BaseResponseModel> UpdateAppProgram(UpdateAppProgramRequestModel model, int id);
        Task<AppProgramsResponseModel> GetAll();
        Task<AppProgramResponseModel> GetById(int id);
    }
}