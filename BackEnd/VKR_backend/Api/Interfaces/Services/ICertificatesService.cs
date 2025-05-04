using Core.Models;

namespace Api.Interfaces.Services
{
    public interface ICertificatesService
    {
        Task<Guid> CertificateCreate(string Name, Guid IdOrganization, string Description);
        Task<Guid> DeleteCertificate(Guid id);
        Task<List<Certificate>> GetCertificates(List<Guid> IdCertificates);
        Task<Guid> UpdateCertificate(Certificate certificate);
    }
}