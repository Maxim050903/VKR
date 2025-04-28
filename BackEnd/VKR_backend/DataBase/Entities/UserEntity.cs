using static Core.Types.Types;

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
        public Roles Role { get; set; }
        public string Mail {  get; set; } = string.Empty;
        public string Telegram {  get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;//?
    }
}
