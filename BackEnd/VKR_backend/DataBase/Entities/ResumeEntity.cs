namespace DataBase.Entities
{
    public class ResumeEntity
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public DateTime DateStart { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public Guid idDepartment { get; set; }
        public DateTime Experience {  get; set; }
        public DateTime ExperienceOnCompany { get; set; }
        public List<Guid> IdSertificates { get; set; } = new List<Guid>();
    }
}
