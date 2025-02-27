using Core.Models;
using DataBase.Repositories;

namespace Api.Interfaces
{
    public interface IUserServices
    {
        Task<Guid> Register(string IndividualNumber,string Name, string Surname, string Otchestvo, string Password, Guid IdDepartment, Guid IdBoss, string Role);
        Task<string> LogIn(string IndividualNumber, string password);
        Task<Guid> ChangePassword(Guid id, string password);
        Task<Guid> UpdateUser(Guid Id, string IndividualNumber);
        Task<Guid> DeleteUser(Guid id);
    }
}