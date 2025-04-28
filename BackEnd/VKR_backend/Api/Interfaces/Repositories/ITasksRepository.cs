using Core.Models;
using Core.Types;

namespace Api.Interfaces.Repositories
{
    public interface ITasksRepository
    {
        Task<Guid> AddTask(_Task task);
        Task<Guid> DeleteTask(Guid id);
        Task<List<_Task>> GetTasksForUser(Guid IdUser, Guid IdDepartment, int page);
        Task<Guid> UpdateTask(Guid Id, string Name, Guid IdBoss, Guid IdAgragete, Types.TaskType type, Guid IdUorD);
        Task<_Task> GetTask(Guid IdTask);
    }
}