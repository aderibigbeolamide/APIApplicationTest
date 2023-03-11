using APIApplication.Model;

namespace APIApplication.Interfaces.Repositories
{
    public interface IAppProgramRepository : IRepository<AppProgram>
    {
         Task<AppProgram> GetInfo(int Id);
         Task<IList<AppProgram>> GetAll();
         
    }
}