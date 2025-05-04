using static Core.Types.Types;

namespace Core.Models
{

    public class Request
    {
        public Guid id { get; set; } = Guid.Empty;
        public Guid idUser { get; set; } = Guid.Empty;
        public RequestType RequestType { get; set; }
        public string Description { get; set; } = string.Empty;
            
        private Request(Guid id,Guid idUser, RequestType requestType, string description)
        {
            this.id = id;
            this.idUser = idUser;
            RequestType = requestType;
            Description = description;
        }

        public static(string error,Request request) CreateRequest(Guid id,Guid idUser,RequestType type, string description)
        {
            string error = string.Empty;

            error = Utils.CheckValidData(description);

            if (error == "None")
            {
                var request = new Request(id, idUser, type, description);
                return (error, request);
            }
            else
            {
                return (error, null);
            }
        }
    }
}
