namespace Core.Models
{
    public class Certificate
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid Organization { get; set; }
        public string Description { get; set; } = string.Empty;

        private Certificate(Guid Id,string name, Guid organization, string description)
        {
            this.Id = Id;
            Name = name;
            Organization = organization;
            Description = description;
        }

        public static (string error,Certificate certificate) CreateCertificate(Guid Id,string name, Guid organization, string description)
        {
            var error = string.Empty;

            error = Utils.CheckValidData(name);

            if (error == "None")
            {
                var certificate = new Certificate(Id,name, organization, description);
                return (error, certificate);
            }
            else
            {
                return (error, null);
            }
        }
    }
}
