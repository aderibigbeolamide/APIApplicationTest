using APIApplication.Contracts;

namespace APIApplication.Model
{
    public class Preview : AuditableEntity
    {
        public string  Publish { get; set; }
        public int ProgramId { get; set; }
        public AppProgram appProgram { get; set; }
    }
}