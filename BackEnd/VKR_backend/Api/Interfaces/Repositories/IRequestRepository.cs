using Core.Types;

namespace DataBase.Repositories
{
    public interface IRequestRepository
    {
        Task<Guid> AddRequest(Request request);
        Task<Guid> DeleteRequest(Guid id);
        Task<Guid> FinishRequest(Guid Id);
        Task<List<Request>> GetRequests(int page);
    }
}