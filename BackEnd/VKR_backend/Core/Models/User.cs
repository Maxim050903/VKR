using static Core.Types.Types;

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
        public Roles Role { get; set; }
        public string Mail { get; set; } = string.Empty;
        public string Telegram { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;//?

        public User(Guid Id,string IndividualNumber, string Name,
            string Surname, string Otchestvo,
            string PasswordHash, Guid IdDepartment,
            Guid IdBoss, Roles Role)
        {
            this.Id = Id;
            this.IndividualNumber = IndividualNumber;
            this.Name = Name;
            this.Surname = Surname;
            this.Otchestvo = Otchestvo;
            this.PasswordHash = PasswordHash;
            this.IdDepartment = IdDepartment;
            this.IdBoss = IdBoss;
            this.Role = Role;
        }

        public static (User user,string error) CreateUser (Guid Id,
            string IndividualNumber, string Name,
            string Surname, string Otchestvo,
            string PasswordHash, Guid IdDepartment,
            Guid IdBoss, Roles Role)
        {
            var error = string.Empty;

            error = Utils.CheckValidData (Name);

            if (error == "None")
            {
                var user = new User(Id, IndividualNumber, Name, Surname, Otchestvo, PasswordHash, IdDepartment, IdBoss, Role);
                return (user, error);
            }
            else
            {
                return (null, error);
            }
        }
    }
}
