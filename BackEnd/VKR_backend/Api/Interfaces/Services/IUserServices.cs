using Core.Models;
using static Core.Types.Types;

namespace Api.Interfaces.Services
{
    public interface IUserServices
    {
        Task<Guid> Register(Guid Id, string IndividualNumber, string Name, string Surname, string Otchestvo, string Password, Guid IdDepartment, Guid IdBoss, Roles Role);
        Task<Guid> ChangePassword(Guid id, string password);
        Task<Guid> UpdateUser(Guid Id, string IndividualNumber);
        Task<Guid> DeleteUser(Guid id);
        Task<User> GetUser(Guid id);

    }
}