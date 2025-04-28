using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Types.Types;

namespace DataBase.Entities
{
    public class _TaskEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid IdBoss { get; set; }
        public Guid IdAgragete { get; set; } //?
        public TaskType Type { get; set; }
        public Guid idUorD { get; set; }
    }
}
