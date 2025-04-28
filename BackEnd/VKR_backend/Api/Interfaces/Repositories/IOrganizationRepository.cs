using Core.Models;

namespace DataBase.Repositories
{
    public interface IOrganizationRepository
    {
        Task<Guid> CreateOrganization(Organization organization);
        Task<Guid> DeleteOrganization(Guid Id);
        Task<List<Organization>> GetOrganization();
        Task<Guid> OrganizationUpdate(Guid Id, string Name);
    }
}