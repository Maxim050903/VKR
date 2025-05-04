using Core.Models;

namespace Api.Interfaces.Services
{
    public interface IAgrigatesService
    {
        Task<Guid> CreateAgrigate(string Name, Guid IdManafacturer);
        Task<Guid> DeleteAgregate(Guid id);
        Task<List<Agragetes>> GetAgragetes();
        Task<Guid> UpdateAgregate(Agragetes agregate);
    }
}