using Core.Models;

namespace Api.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> AddUser(User user);
        Task<(User, string)> GetByIndividualNumber(string IndividualNumber);
        Task<Guid> UpdatePassword(Guid id, string passwordHash);
        Task<Guid> DeleteUser(Guid id);
        Task<Guid> UpdateUser(Guid Id, string IndividualNumber);
        Task<List<Guid>> GetAllUsersId();
        Task<User> TakeUser(Guid id);
    }
}