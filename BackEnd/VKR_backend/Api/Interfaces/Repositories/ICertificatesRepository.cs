using Core.Models;

namespace DataBase.Repositories
{
    public interface ICertificatesRepository
    {
        Task<Guid> CreateCertificate(Certificate certificate);
        Task<Guid> DeleteCertificate(Guid Id);
        Task<List<Certificate>> GetCertificates();
        Task<Guid> UpdateCertificate(Certificate certificate);
    }
}