using APIApplication.Model;

namespace APIApplication.Interfaces.Repositories
{
    public interface IPreviewRepository : IRepository<Preview>
    {
         Task<Preview> GetPreview(int Id);
         Task<IList<Preview>> GetAll();
    }
}