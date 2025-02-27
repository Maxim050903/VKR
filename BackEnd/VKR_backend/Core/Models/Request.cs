using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    [Flags]
    public enum RequestType
    {
        Edit = 1,
        Delete = 2,
        ChangeDepartment = 3,
        ChangePassword = 4
    };

    public class Request
    {
        public Guid id { get; set; } = Guid.Empty;
        public RequestType RequestType { get; set; }
        public string Description { get; set; }

        public Request() { }
            

        public Guid CreateRequest(RequestType type, string description)
        {
            this.id = new Guid();
            this.RequestType = type;
            this.Description = description;

            return this.id;
        }
    }
}
