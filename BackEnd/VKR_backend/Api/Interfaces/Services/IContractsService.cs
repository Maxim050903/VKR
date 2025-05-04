using Core.Models;

namespace Api.Interfaces.Services
{
    public interface IContractsService
    {
        Task<Guid> CreateContract(string Name, Guid IdManufacturer, DateTime DateStart, DateTime DateFinish, string Description);
        Task<Guid> DeleteContract(Guid id);
        Task<List<Contracts>> GetContracts();
        Task<Guid> UpdateContract(Contracts contract);
    }
}