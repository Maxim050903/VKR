using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class OrganizationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Weighty { get; set; } = false;
    }
}
