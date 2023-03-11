using APIApplication.DTOs;

namespace APIApplication.DTOs.ResponseModel
{
    
    public class AppProgramResponseModel : BaseResponseModel
    {
        public AppProgramDTO Data { get; set; }
    }

    public class AppProgramsResponseModel : BaseResponseModel
    {
        public ICollection<AppProgramDTO> Data { get; set; } = new HashSet<AppProgramDTO>();
    }
}