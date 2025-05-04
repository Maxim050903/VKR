using static Core.Types.Types;

namespace DataBase.Entities
{
    
    public class RequestEntity
    {
        public Guid id { get; set; } = Guid.Empty;
        public Guid idUser { get; set; } = Guid.Empty;
        public RequestType RequestType { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
