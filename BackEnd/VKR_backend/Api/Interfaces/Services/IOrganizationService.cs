using Core.Models;

namespace Api.Interfaces.Services
{
    public interface IOrganizationService
    {
        Task<Guid> CreateOrganization(string Name, bool Weighty);
        Task<Guid> DeleteOrganization(Guid id);
        Task<List<Organization>> GetOrganizations();
        Task<Guid> UpdateOrganization(Organization organization);
    }
}