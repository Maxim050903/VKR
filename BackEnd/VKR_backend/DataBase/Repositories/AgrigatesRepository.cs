using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
namespace DataBase.Repositories
{
    public class AgrigatesRepository : IAgrigatesRepository
    {
        private readonly VKRDBContext _context;

        public AgrigatesRepository(VKRDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAgrigate(Agragetes agragete)
        {
            var AgregateEntity = new AgragetesEntity
            {
                Id = agragete.Id,
                IdManufacturer = agragete.IdManufacturer,
                Name = agragete.Name
            };

            await _context.Agragetes.AddAsync(AgregateEntity);

            await _context.SaveChangesAsync();

            return AgregateEntity.Id;
        }

        public async Task<List<Agragetes>> GetAgragetes()
        {
            var AgregateEntity = await _context.Agragetes.AsNoTracking().ToListAsync();

            var agregates = AgregateEntity.Select(x => Agragetes.CreateAgregate(x.Id, x.Name, x.IdManufacturer).agregate).ToList();

            return agregates;
        }

        public async Task<Guid> UpdateAgregate(Agragetes agregate)
        {
            await _context.Agragetes
               .Where(x => x.Id == agregate.Id)
               .ExecuteUpdateAsync(s => s
               .SetProperty(b => b.Name, b => agregate.Name)
               .SetProperty(b => b.IdManufacturer, b => agregate.IdManufacturer));

            await _context.SaveChangesAsync();

            return agregate.Id;
        }

        public async Task<Guid> DeleteAgregate(Guid id)
        {
            await _context.Agragetes.Where(x => x.Id == id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
