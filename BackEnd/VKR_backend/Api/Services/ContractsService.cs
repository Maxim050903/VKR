using Api.Interfaces.Services;
using Core.Models;
using DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class ContractsService : IContractsService
    {
        private readonly IContractsRepository _contractsRepository;

        public ContractsService(IContractsRepository contractsRepository)
        {
            _contractsRepository = contractsRepository;
        }

        public async Task<Guid> CreateContract(string Name, Guid IdManufacturer, DateTime DateStart, DateTime DateFinish, string Description)
        {
            var id = Guid.NewGuid();
            
            var contract = Contracts.CreateContract(id, Name, IdManufacturer, DateStart, DateFinish, Description);

            if (contract.error == "None")
            {
                return await _contractsRepository.CreateContract(contract.contract);
            }
            else
            {
                throw new Exception(contract.error);
            }
        }

        public async Task<List<Contracts>> GetContracts()
        {
            return await GetContracts();
        }

        public async Task<Guid> UpdateContract(Contracts contract)
        {
            return await UpdateContract(contract);
        }

        public async Task<Guid> DeleteContract(Guid id)
        {
            return await DeleteContract(id);
        }
    }
}
