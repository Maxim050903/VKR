using Core.Models;

namespace DataBase.Repositories
{
    public interface IAgrigatesRepository
    {
        Task<Guid> CreateAgrigate(Agragetes agragete);
        Task<Guid> DeleteAgregate(Guid id);
        Task<List<Agragetes>> GetAgragetes();
        Task<Guid> UpdateAgregate(Agragetes agregate);
    }
}