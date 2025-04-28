using Core.Models;

namespace DataBase.Repositories
{
    public interface IContractsRepository
    {
        Task<Guid> CreateContract(Contracts contract);
        Task<Guid> DeleteContract(Guid id);
        Task<List<Contracts>> GetContracts();
        Task<Guid> UpdateContract(Contracts contract);
    }
}