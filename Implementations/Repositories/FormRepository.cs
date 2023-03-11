using System.Data.Entity;
using APIApplication.Contexts;
using APIApplication.Interfaces.Repositories;
using APIApplication.Model;
using CMSApp.Implementations.Repositories;

namespace APIApplication.Implementations.Repositories
{
    public class FormRepository : BaseRepository<Form>, IFormRepository
    {
        public FormRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Form>> GetAll()
        {
           var forms = await _context.Forms.Where(x => x.IsDeleted == false).ToListAsync();
            return forms;
        }

        public async Task<Form> GetForm(int Id)
        {
            var form = await _context.Forms.Where(x => x.Id == Id).SingleOrDefaultAsync();
            return form;
        }
    }
}