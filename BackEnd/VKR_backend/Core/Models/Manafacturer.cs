namespace Core.Models
{
    public class Manafacturer
    {
        public Guid id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid IdContract { get; set; }

        private Manafacturer(string Name, Guid IdContract) 
        {
            this.id = new Guid();
            this.Name = Name;
            this.IdContract = IdContract;
        }

        public static (string Error, Manafacturer manafacture) CreateManafacture(string Name, Guid IdContract)
        {
            var error = string.Empty;

            error = Utils.CheckValidData(Name);

            if (error == "None")
            {
                var manafacture = new Manafacturer(Name, IdContract);
                return (error, manafacture);
            }
            else
            {
                return (error, null);
            }
        }
    }
}
