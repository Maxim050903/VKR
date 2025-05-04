using Api.Interfaces.Services;
using Core.Models;
using DataBase.Repositories;
using static Core.Types.Types;


namespace Api.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Guid> CreateRequest(Guid IdUser, RequestType requestType, string Description)
        {
            var Id = Guid.NewGuid();
            
            var request = Request.CreateRequest(Id,IdUser,requestType, Description);

            if (request.error == "None")
            {
                return await _requestRepository.CreateRequest(request.request);
            }
            else
            {
                throw new Exception(request.error);
            }
        }

        public async Task<List<Request>> GetRequests()
        {
            return await GetRequests();
        }

        public async Task<Guid> FinishRequest(Guid id)
        {
            return await FinishRequest(id);
        }

        public async Task<Guid> DeleteRequest(Guid id)
        {
            return await DeleteRequest(id);
        }
    }
}
