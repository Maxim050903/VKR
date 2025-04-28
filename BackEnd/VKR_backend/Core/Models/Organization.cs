namespace Core.Models
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Weighty { get; set; } = false;

        private Organization(Guid id,string Name, bool Weighty)
        {
            this.Id = id;
            this.Name = Name;
            this.Weighty = Weighty;
        }

        public static (string error,  Organization organization) CreateOrganization(Guid id,string Name, bool Weighty)
        {
            var error = string.Empty;

            error = Utils.CheckValidData(Name);

            if(error == "None")
            {
                var organization = new Organization(id,Name, Weighty);
                return (error, organization);
            }
            else
            {
                return (error, null);
            }
        }
    }
}
