using System.Data.Entity;
using APIApplication.Contexts;
using APIApplication.Interfaces.Repositories;
using APIApplication.Model;
using CMSApp.Implementations.Repositories;

namespace APIApplication.Implementations.Repositories
{
    public class AppProgramRepository : BaseRepository<AppProgram>, IAppProgramRepository
    {
        public AppProgramRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<AppProgram>> GetAll()
        {
            var appPrograms = await _context.AppPrograms.Where(x => x.IsDeleted == false).ToListAsync();
            return appPrograms;
        }

        public async Task<AppProgram> GetInfo(int Id)
        {
            var appProgram = await _context.AppPrograms.Where(x => x.Id == Id).SingleOrDefaultAsync();
            return appProgram;
        }
    }
}