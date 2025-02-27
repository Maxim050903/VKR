using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Department
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public Guid IdBoss { get; set; } = Guid.Empty;
        public List<Guid> Members { get; set; } = new List<Guid>();


        public void CreateDepartment(Guid Id, string Name,Guid IdBoss, List<Guid> Members)
        {
            this.Id = Id;
            this.Name = Name;
            this.IdBoss = IdBoss;
            this.Members = Members;
        }

    }
}
