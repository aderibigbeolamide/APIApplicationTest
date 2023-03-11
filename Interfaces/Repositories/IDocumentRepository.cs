using APIApplication.Interfaces.Repositories;
using APIApplication.DTOs;
using APIApplication.Entities;

namespace CMSApp.Interfaces.Repositories
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task<DocumentDTO> GetWithForm(int id);
        Task<IList<DocumentDTO>> GetAllWithForm();
    }
}
