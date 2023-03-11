namespace APIApplication.DTOs.ResponseModel
{
    public class PreviewResponseModel : BaseResponseModel
    {
        public PreviewDTO Data { get; set; }
    }

    public class PreviewsResponseModel : BaseResponseModel
    {
        public ICollection<PreviewDTO> Data { get; set; } = new HashSet<PreviewDTO>();
    }
}