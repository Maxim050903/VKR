using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    [Flags]
    public enum RequestType
    {
        Edit = 1,
        Delete = 2,
        ChangeDepartment = 3,
        ChangePassword = 4
    };

    public class RequestsEntity
    {
        public Guid id { get; set; } = Guid.Empty;
        public RequestType RequestType { get; set; }
        public string Description { get; set; }
    }
}
