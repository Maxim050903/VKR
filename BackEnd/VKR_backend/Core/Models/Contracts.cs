using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Contracts
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid IdManufacturer { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public string Description { get; set; } = string.Empty;

        private Contracts(Guid id,string name, Guid idManufacturer, DateTime dateStart, DateTime dateFinish, string description)
        {
            Id = id;
            Name = name;
            IdManufacturer = idManufacturer;
            DateStart = dateStart;
            DateFinish = dateFinish;
            Description = description;
        }

        public static (string error, Contracts contract) CreateContract(Guid Id,string name, Guid idManufacturer, DateTime dateStart, DateTime dateFinish, string description)
        {
            var error = string.Empty;

            error = Utils.CheckValidData(error);

            if (error == "None")
            {
                var contract =new Contracts(Id,name, idManufacturer, dateStart, dateFinish, description);
                return (error, contract);
            }
            else
            {
                return (error, null);
            }
        }
    }
}
