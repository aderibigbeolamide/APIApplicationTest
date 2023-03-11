using APIApplication.Contracts;
using APIApplication.Model;

namespace APIApplication.Entities
{
    public class Document : AuditableEntity
    {
        public string? Path { get; set; }
        public int? FormId { get; set; }
        public Form? form { get; set; }
    }
}