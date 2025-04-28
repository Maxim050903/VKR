using Api.Interfaces.Repositories;
using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VKRDBContext _context;

        public UserRepository(VKRDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddUser(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                IdBoss = user.IdBoss,
                IdDepartment = user.IdDepartment,
                Name = user.Name,
                Otchestvo = user.Otchestvo,
                Surname = user.Surname,
                Role = user.Role,
                PasswordHash = user.PasswordHash
            };

            await _context.Users.AddAsync(userEntity);

            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<User> TakeUser(Guid id)
        {
            var UserEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            var user = User.CreateUser(UserEntity.Id,
                UserEntity.IndividualNumber,
                UserEntity.Name,
                UserEntity.Surname,
                UserEntity.Otchestvo,
                UserEntity.PasswordHash,
                UserEntity.IdDepartment,
                UserEntity.IdBoss,
                UserEntity.Role).user;

            return user;
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            await _context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;    
        }

        public async Task<Guid> UpdateUser(Guid Id, string IndividualNumber)
        {
            await _context.Users
                .Where(x => x.Id == Id)
                .ExecuteUpdateAsync(u => u
                .SetProperty(b => b.IndividualNumber, b => IndividualNumber));

            return Id;
        }


        public async Task<Guid> UpdatePassword(Guid id,string passwordHash)
        {
            await _context.Users.Where(u => u.Id == id).
                ExecuteUpdateAsync(b => b
                .SetProperty(b => b.PasswordHash, b => passwordHash));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<List<Guid>> GetAllUsersId()
        {
            var Users = await _context.Users
                .Select(p => p.Id)
                .ToListAsync();
            return Users;
        }

        
        public async Task<(User,string)> GetByIndividualNumber(string IndividualNumber)
        {
            var UserEntity = await _context.Users.FirstOrDefaultAsync(x => x.IndividualNumber == IndividualNumber);
            string error = string.Empty;
            if (UserEntity != null)
            {
                var user = User.CreateUser(UserEntity.Id, UserEntity.IndividualNumber, UserEntity.Name, UserEntity.Surname,
                    UserEntity.Otchestvo, UserEntity.PasswordHash, UserEntity.IdDepartment, UserEntity.IdBoss, UserEntity.Role).user; 
                error = "ok";
                return (user, error);
            }
            else
            {
                error = "Takogo polsovatelia net";
                return (null, error);
            }
        }
    }
}
