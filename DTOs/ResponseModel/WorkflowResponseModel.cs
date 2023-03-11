namespace APIApplication.DTOs.ResponseModel
{
    public class WorkflowResponseModel : BaseResponseModel
    {
        public WorkflowDTO Data { get; set; }
    }

    public class WorkflowsResponseModel : BaseResponseModel
    {
        public ICollection<WorkflowDTO> Data { get; set; } = new HashSet<WorkflowDTO>();
    }
}