using Core.Models;
using static Core.Types.Types;

namespace Api.Interfaces.Services
{
    public interface ITasksService
    {
        Task<Guid> CreateTask(string Name, Guid IdBoss, Guid IdAgregate, TaskType Type, Guid idUorD);
        Task<_Task> GetTask(Guid IdTask);
        Task<List<_Task>> GetTasksForUser(Guid IdUser, Guid IdDepartment, int page);
    }
}