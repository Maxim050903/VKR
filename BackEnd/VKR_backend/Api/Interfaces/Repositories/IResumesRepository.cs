using Core.Models;

namespace DataBase.Repositories
{
    public interface IResumesRepository
    {
        Task<Guid> CreateResume(Resume resume);
        Task<Resume> GetUserResume(Guid id);
        Task<Guid> DeleteForUserId(Guid userId);
        Task<Guid> UpdateResume(Resume resume);
    }
}