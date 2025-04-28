namespace Core.Models
{
    public class Department
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public Guid IdBoss { get; set; } = Guid.Empty;
        public List<Guid> Members { get; set; }


        private Department(string name, Guid idBoss, List<Guid> members)
        {
            Id = new Guid();
            Name = name;
            IdBoss = idBoss;
            Members = members;
        }

        public static (string error, Department department) CreateDepartment(string Name, Guid idBoss, List<Guid> members)
        {
            var error = string.Empty;

            error = Utils.CheckValidData(Name);

            if (error == "None")
            {
                var department = new Department(Name, idBoss, members);
                return (error, department);
            }
            else
            {
                return (error, null);
            }
        }
    }
}
