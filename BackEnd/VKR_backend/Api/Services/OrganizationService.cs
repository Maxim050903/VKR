using Api.Interfaces.Services;
using Core.Models;
using DataBase.Repositories;

namespace Api.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<Guid> CreateOrganization(string Name,bool Weighty)
        {
            var Id = Guid.NewGuid();

            var organization = Organization.CreateOrganization(Id, Name, Weighty);

            if (organization.error == "None")
            {
                return await _organizationRepository.CreateOrganization(organization.organization);
            }
            else
            {
                throw new Exception(organization.error);
            }
        }

        public async Task<List<Organization>> GetOrganizations()
        {
            return await GetOrganizations();
        }

        public async Task<Guid> UpdateOrganization(Organization organization)
        {
            return await UpdateOrganization(organization);
        }

        public async Task<Guid> DeleteOrganization(Guid id)
        {
            return await DeleteOrganization(id);
        }
    }
}
