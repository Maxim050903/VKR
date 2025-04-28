using Core.Models;

namespace DataBase.Repositories
{
    public interface IResumesRepository
    {
        Task<Guid> AddResume(Resume resume);
        Task<Guid> DeleteForUserId(Guid userId);
        Task<Guid> UpdateResume(Resume resume);
    }
}