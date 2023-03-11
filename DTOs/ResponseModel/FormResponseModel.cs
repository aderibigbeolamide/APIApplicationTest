using APIApplication.DTOs;

namespace APIApplication.DTOs.ResponseModel
{
    public class FormResponseModel : BaseResponseModel
    {
        public FormDTO Data { get; set; }
    }

    public class FormsResponseModel : BaseResponseModel
    {
        public ICollection<FormDTO> Data { get; set; } = new HashSet<FormDTO>();
    }
}