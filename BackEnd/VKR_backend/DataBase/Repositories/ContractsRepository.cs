using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories
{
    public class ContractsRepository : IContractsRepository
    {
        private readonly VKRDBContext _context;

        public ContractsRepository(VKRDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateContract(Contracts contract)
        {
            var ContractEntity = new ContractsEntity
            {
                Id = contract.Id,
                Name = contract.Name,
                IdManufacturer = contract.IdManufacturer,
                DateStart = contract.DateStart,
                DateFinish = contract.DateFinish,
                Description = contract.Description
            };

            await _context.Contracts.AddAsync(ContractEntity);

            await _context.SaveChangesAsync();

            return contract.Id;
        }

        public async Task<List<Contracts>> GetContracts()
        {
            var ContractsEntity = await _context.Contracts.AsNoTracking().ToListAsync();

            var contracts = ContractsEntity.Select(x => Contracts.CreateContract(x.Id, x.Name, x.IdManufacturer, x.DateStart, x.DateFinish, x.Description).contract).ToList();

            return contracts;
        }

        public async Task<Guid> UpdateContract(Contracts contract)
        {
            await _context.Contracts
               .Where(x => x.Id == contract.Id)
               .ExecuteUpdateAsync(s => s
               .SetProperty(b => b.Name, b => contract.Name)
               .SetProperty(b => b.Description, b => contract.Description)
               .SetProperty(b => b.DateFinish, b => contract.DateFinish));

            await _context.SaveChangesAsync();

            return contract.Id;
        }

        public async Task<Guid> DeleteContract(Guid id)
        {
            await _context.Contracts.Where(x => x.Id == id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
