using Core.Models;

namespace DataBase.Repositories
{
    public interface ICertificatesRepository
    {
        Task<Guid> CreateCertificate(Certificate certificate);
        Task<Guid> DeleteCertificate(Guid Id);
        Task<List<Certificate>> GetCertificates(List<Guid> IdCertificates);
        Task<Guid> UpdateCertificate(Certificate certificate);
    }
}