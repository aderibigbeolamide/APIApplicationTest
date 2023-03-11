using APIApplication.Model;

namespace APIApplication.Interfaces.Repositories
{
    public interface IFormRepository:IRepository<Form>
    {
         Task<Form> GetForm(int Id);
         Task<IList<Form>> GetAll();
    }
}