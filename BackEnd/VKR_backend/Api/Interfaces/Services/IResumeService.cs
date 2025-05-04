using Core.Models;

namespace Api.Interfaces.Services
{
    public interface IResumeService
    {
        Task<Guid> CreateResume(Guid IdUser,
            DateOnly DateStart, string JobTitle,
            Guid IdDpartment, DateOnly Experience,
            DateOnly ExperienceOnCompany, List<Guid> IdSertificates);
        Task<Resume> GetUserResume(Guid Id);
        Task<Guid> DeleteResume(Guid id);
        Task<Guid> UpdateResume(Resume resume);
    }
}