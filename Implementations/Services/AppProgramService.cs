using APIApplication.DTOs;
using APIApplication.DTOs.RequestModel;
using APIApplication.DTOs.ResponseModel;
using APIApplication.Interfaces.Repositories;
using APIApplication.Interfaces.Services;
using APIApplication.Model;

namespace APIApplication.Implementations.Services
{
    public class AppProgramService : IAppProgramService
    {
        private readonly IAppProgramRepository _appProgramReposittory;

        public AppProgramService(IAppProgramRepository appProgramRepository)
        {
            _appProgramReposittory = appProgramRepository;
        }

        public async Task<BaseResponseModel> CreateAppProgram(CreateAppProgramRequestModel model)
        {
            var check = await _appProgramReposittory.Get(x => x.ProgramTitle == model.ProgramTitle);
            if (check != null)
            {
                return new BaseResponseModel
                {
                    Message = "A Program with this Title already Exist",
                    Success = false,
                };
            }
            var appProgram = new AppProgram
            {
                ProgramTitle = model.ProgramTitle,
                ProgramBenefits = model.ProgramBenefits,
                ProgramDescription = model.ProgramDescription,
                ProgramLocation = model.ProgramLocation,
                ProgramStart = model.ProgramStart,
                ProgramType = model.ProgramType,
                SummaryOfTheProgram = model.SummaryOfTheProgram,
                KeySkillsRequiredForTheProgram = model.KeySkillsRequiredForTheProgram,
                ApplicationClose = model.ApplicationClose,
                ApplicationCriteria = model.ApplicationCriteria,
                ApplicationOpen = model.ApplicationOpen,
                MaxNumberOfApplication = model.MaxNumberOfApplication,
                MinQualification = model.MinQualification,
                Duration = model.Duration,
            };
            await _appProgramReposittory.Register(appProgram);
            return new BaseResponseModel
            {
                Message = "A Program Registered Successfully",
                Success = false,
            };
        }

        public async Task<AppProgramsResponseModel> GetAll()
        {
            var check = await _appProgramReposittory.GetAll();
            var form = check.Where(x => x.IsDeleted == false).Select(x => new AppProgramDTO
            {
                ProgramTitle = x.ProgramTitle,
                ProgramBenefits = x.ProgramBenefits,
                ProgramDescription = x.ProgramDescription,
                ProgramLocation = x.ProgramLocation,
                ProgramStart = x.ProgramStart,
                ProgramType = x.ProgramType,
                SummaryOfTheProgram = x.SummaryOfTheProgram,
                KeySkillsRequiredForTheProgram = x.KeySkillsRequiredForTheProgram,
                ApplicationClose = x.ApplicationClose,
                ApplicationCriteria = x.ApplicationCriteria,
                ApplicationOpen = x.ApplicationOpen,
                MaxNumberOfApplication = x.MaxNumberOfApplication,
                MinQualification = x.MinQualification,
                Duration = x.Duration,
            }).ToList();
            if (check == null)
            {
                return new AppProgramsResponseModel
                {
                    Message = "Form not Fund",
                    Success = true
                };
            }
            return new AppProgramsResponseModel
            {
                Success = true,
                Data = form,
                Message = "List of Forms",
            };
        }

        public async Task<AppProgramResponseModel> GetById(int id)
        {
            var appProgram = await _appProgramReposittory.GetInfo(id);
            if (appProgram == null)
            {
                return new AppProgramResponseModel
                {
                    Message = "Program not Available",
                    Success = true
                };
            }
            var appProgramDTO = new AppProgramDTO
            {
                ProgramTitle = appProgram.ProgramTitle,
                ProgramBenefits = appProgram.ProgramBenefits,
                ProgramDescription = appProgram.ProgramDescription,
                ProgramLocation = appProgram.ProgramLocation,
                ProgramStart = appProgram.ProgramStart,
                ProgramType = appProgram.ProgramType,
                SummaryOfTheProgram = appProgram.SummaryOfTheProgram,
                KeySkillsRequiredForTheProgram = appProgram.KeySkillsRequiredForTheProgram,
                ApplicationClose = appProgram.ApplicationClose,
                ApplicationCriteria = appProgram.ApplicationCriteria,
                ApplicationOpen = appProgram.ApplicationOpen,
                MaxNumberOfApplication = appProgram.MaxNumberOfApplication,
                MinQualification = appProgram.MinQualification,
                Duration = appProgram.Duration,
            };
            return new AppProgramResponseModel
            {
                Message = "Program fund",
                Success = true,
            };
        }

        public async Task<BaseResponseModel> UpdateAppProgram(UpdateAppProgramRequestModel model, int id)
        {
            var appProgram = await _appProgramReposittory.Get(x => x.Id == id);
            if (appProgram == null)
            {
                return new BaseResponseModel
                {
                    Message = "form not found",
                    Success = false
                };
            }
            appProgram.ProgramTitle = model.ProgramTitle;
            appProgram.ProgramBenefits = model.ProgramBenefits;
            appProgram.ProgramDescription = model.ProgramDescription;
            appProgram.ProgramLocation = model.ProgramLocation;
            appProgram.ProgramStart = model.ProgramStart;
            appProgram.ProgramType = model.ProgramType;
            appProgram.SummaryOfTheProgram = model.SummaryOfTheProgram;
            appProgram.KeySkillsRequiredForTheProgram = model.KeySkillsRequiredForTheProgram;
            appProgram.ApplicationClose = model.ApplicationClose;
            appProgram.ApplicationCriteria = model.ApplicationCriteria;
            appProgram.ApplicationOpen = model.ApplicationOpen;
            appProgram.MaxNumberOfApplication = model.MaxNumberOfApplication;
            appProgram.MinQualification = model.MinQualification;
            appProgram.Duration = model.Duration;
            await _appProgramReposittory.Update(appProgram);
            return new BaseResponseModel
            {
                Message = "Program Updated Successfully",
                Success = false
            };
        }
    }
}