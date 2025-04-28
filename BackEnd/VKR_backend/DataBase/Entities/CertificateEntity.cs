using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class CertificateEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid Organization {  get; set; }
        public string Description {  get; set; } = string.Empty;
    }
}
