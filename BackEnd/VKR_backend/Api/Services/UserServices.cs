using Api.Interfaces.Repositories;
using Api.Interfaces.Services;
using Core.Models;
using Infrastructure;
using static Core.Types.Types;

namespace Api.Services
{
    public class UserServices : IUserServices
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public UserServices(IUserRepository userRepository,IPasswordHasher passwordHasher,IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<Guid> Register(Guid Id,string IndividualNumber,string Name,string Surname,string Otchestvo,string Password,Guid IdDepartment,Guid IdBoss, Roles Role)
        {
            
            var hashedPassword = _passwordHasher.Generate(Password);

            var user = User.CreateUser( Id,  IndividualNumber,  Name,  Surname,  Otchestvo,  Password,  IdDepartment,  IdBoss,  Role).user;

            await _userRepository.AddUser(user);

            return user.Id;
        }

        public async Task<List<Guid>> GetAllUsers()
        {
            return await _userRepository.GetAllUsersId();
        }

        public async Task<User> GetUser(Guid Id)
        {
            return await _userRepository.TakeUser(Id);
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            await _userRepository.DeleteUser(id); 
            return id;
        }

        public async Task<Guid> ChangePassword(Guid id, string password)
        {
            var newPasswordHash = _passwordHasher.Generate(password);

            await _userRepository.UpdatePassword(id, newPasswordHash);

            return id;
        }

        public async Task<Guid> UpdateUser(Guid Id,string IndividualNumber)
        {
            await _userRepository.UpdateUser(Id, IndividualNumber);

            return Id;
        }
    }
}
