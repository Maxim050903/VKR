namespace DataBase.Entities
{
    public class DepartmentEntity
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public Guid IdBoss { get; set; } = Guid.Empty;
        public List<Guid> Members { get; set; }
    }
}
