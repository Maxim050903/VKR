using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string IndividualNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Otchestvo { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Guid IdDepartment { get; set; } = Guid.Empty;
        public Guid IdBoss { get; set; } = Guid.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
