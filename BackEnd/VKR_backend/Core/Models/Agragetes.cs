namespace Core.Models
{
    public class Agragetes
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid IdManufacturer { get; set; }

        private Agragetes(Guid id,string Name,Guid IdManufactorer)
        {
            this.Id = id;
            this.Name = Name;
            this.IdManufacturer = IdManufactorer;
        }

        public static (string error,Agragetes agregate) CreateAgregate(Guid id,string Name,Guid IdManufactorer)
        {
            var error = string.Empty;

            error = Utils.CheckValidData(Name);
            
            if (error == "None")
            {
                var agragete = new Agragetes(id,Name, IdManufactorer);
                return (error, agragete);
            }
            else
            {
                return (error, null);
            }
        }
    }
}
