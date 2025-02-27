using Api.Interfaces;
using Core.Models;
using DataBase.Repositories;
using Infrastructure;

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

        public async Task<Guid> Register(string IndividualNumber,string Name,string Surname,string Otchestvo,string Password,Guid IdDepartment,Guid IdBoss,string Role)
        {
            var hashedPassword = _passwordHasher.Generate(Password);

            var user = new User();
            user.CreateUser(IndividualNumber,Name, Surname, Otchestvo, hashedPassword, IdDepartment, IdBoss, Role);
        
            await _userRepository.AddUser(user);

            return user.Id;
        }

        public async Task<List<Guid>> GetAllUsers()
        {
            return await _userRepository.GetAllUsersId();
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

        public async Task<string> LogIn(string IndividualNumber, string password)
        {
            var user = new User();
            string err = string.Empty;
            (user,err) = _userRepository.GetByIndividualNumber(IndividualNumber).Result;

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result)
            {
                var token = _jwtProvider.GenerateToken(user);

                return token;
            }
            throw new Exception("Faild LogIn");
        }

        public async Task<Guid> UpdateUser(Guid Id,string IndividualNumber)
        {
            await _userRepository.UpdateUser(Id, IndividualNumber);

            return Id;
        }

    }
}
