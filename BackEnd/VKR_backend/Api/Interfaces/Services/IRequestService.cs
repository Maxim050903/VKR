using Core.Models;
using static Core.Types.Types;

namespace Api.Interfaces.Services
{
    public interface IRequestService
    {
        Task<Guid> CreateRequest(Guid IdUser, RequestType requestType, string Description);
        Task<Guid> DeleteRequest(Guid id);
        Task<Guid> FinishRequest(Guid id);
        Task<List<Request>> GetRequests();
    }
}