namespace DataBase.Entities
{
    public class ContractsEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdManufacturer { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
