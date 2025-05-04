namespace DataBase.Entities
{
    public class OrganizationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Weighty { get; set; } = false;
    }
}
