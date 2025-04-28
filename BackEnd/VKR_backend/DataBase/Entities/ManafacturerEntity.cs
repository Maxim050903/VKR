using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class ManafacturerEntity
    {
        public Guid id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid IdContract { get; set; }
    }
}
