using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User
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
        
        
        public User()
        {
        }

        public Guid CreateUser(string IndividualNumber,string Name,
            string Surname, string Otchestvo,
            string PasswordHash, Guid IdDepartment,
            Guid IdBoss, string Role)
        {

            Id = new Guid();
            this.IndividualNumber = IndividualNumber;
            this.Name = Name;
            this.Surname = Surname;
            this.Otchestvo = Otchestvo;
            this.PasswordHash = PasswordHash;
            this.IdDepartment = IdDepartment;
            this.IdBoss = IdBoss;
            this.Role = Role;   
            return Id;
        }
    }
}
