using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly VKRDBContext _context;

        public RequestRepository(VKRDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateRequest(Request request)
        {
            var requestEntity = new RequestEntity
            {
                id = request.id,
                idUser = request.idUser,
                RequestType = request.RequestType,
                Description = request.Description,
            };

            await _context.Requests.AddAsync(requestEntity);

            await _context.SaveChangesAsync();

            return request.id;
        }

        public async Task<List<Request>> GetRequests(int page)
        {
            var RequestsEntity = await _context.Requests.Skip((page - 1) * 5).Take(5).ToListAsync();

            var Requests = RequestsEntity.Select(x => Request.CreateRequest(x.id, x.idUser, x.RequestType, x.Description).request).ToList();

            return Requests;
        }

        public async Task<Guid> FinishRequest(Guid Id)
        {
            await _context.Requests.Where(x => x.id == Id).ExecuteDeleteAsync();

            return Id;
        }

        public async Task<Guid> DeleteRequest(Guid id)
        {
            await _context.Requests.Where(x => x.id == id).ExecuteDeleteAsync();

            return id;
        }
    }
}
