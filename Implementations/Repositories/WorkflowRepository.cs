using System.Data.Entity;
using APIApplication.Contexts;
using APIApplication.Interfaces.Repositories;
using APIApplication.Model;
using CMSApp.Implementations.Repositories;

namespace APIApplication.Implementations.Repositories
{
    public class WorkflowRepository : BaseRepository<Workflow>, IWorkflowRepository
    {
         public WorkflowRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Workflow>> GetAll()
        {
            var workflow = await _context.Workflows.ToListAsync();
            return workflow;
        }

        public async Task<Workflow> GetWorkflow(string Name)
        {
            var workflow = await _context.Workflows.Where(x => x.StageName == Name).SingleOrDefaultAsync();
            return workflow;
        }
    }
}