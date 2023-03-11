using System.Data.Entity;
using APIApplication.Contexts;
using APIApplication.Interfaces.Repositories;
using APIApplication.Model;
using CMSApp.Implementations.Repositories;

namespace APIApplication.Implementations.Repositories
{
    public class PreviewRepository : BaseRepository<Preview>, IPreviewRepository
    {
          public PreviewRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Preview>> GetAll()
        {
            var previews = await _context.Previews.Where(x => x.IsDeleted == false).ToListAsync();
            return previews;
        }

        public async Task<Preview> GetPreview(int Id)
        {
            var preview = await _context.Previews.Where(x => x.Id == Id).SingleOrDefaultAsync();
            return preview;
        }
    }
}