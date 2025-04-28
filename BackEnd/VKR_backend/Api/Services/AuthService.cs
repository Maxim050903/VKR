using Api.Interfaces.Repositories;
using Api.Interfaces.Services;
using Core.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> LogIn(string IndividualNumber, string password)
        {
            var (user, err) = _userRepository.GetByIndividualNumber(IndividualNumber).Result;

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result)
            {
                var token = _jwtProvider.GenerateToken(user);

                return token;
            }
            throw new Exception("Faild LogIn");
        }

    }
}
