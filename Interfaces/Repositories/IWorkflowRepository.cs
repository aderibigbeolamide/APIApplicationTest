using APIApplication.Model;

namespace APIApplication.Interfaces.Repositories
{
    public interface IWorkflowRepository : IRepository<Workflow>
    {
       Task<Workflow> GetWorkflow(string Name);  
       Task<IList<Workflow>> GetAll();
    }
}