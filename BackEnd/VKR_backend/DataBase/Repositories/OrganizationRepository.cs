using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly VKRDBContext _context;

        public OrganizationRepository(VKRDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateOrganization(Organization organization)
        {
            var OrganizationEntity = new OrganizationEntity
            {
                Id = organization.Id,
                Name = organization.Name,
                Weighty = organization.Weighty
            };

            await _context.Organizations.AddAsync(OrganizationEntity);

            await _context.SaveChangesAsync();

            return organization.Id;
        }

        public async Task<List<Organization>> GetOrganization()
        {
            var OrganizationEntity = await _context.Organizations.AsNoTracking().ToListAsync();

            var organization = OrganizationEntity.Select(x => Organization.CreateOrganization(x.Id, x.Name, x.Weighty).organization).ToList();

            return organization;
        }

        public async Task<Guid> OrganizationUpdate(Guid Id, string Name)
        {
            await _context.Organizations
               .Where(x => x.Id == Id)
               .ExecuteUpdateAsync(s => s
               .SetProperty(b => b.Name, b => Name));

            await _context.SaveChangesAsync();

            return Id;
        }

        public async Task<Guid> DeleteOrganization(Guid Id)
        {
            await _context.Organizations.Where(x => x.Id == Id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return Id;
        }
    }
}
