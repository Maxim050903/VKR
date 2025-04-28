using Core.Models;

namespace Api.Interfaces.Services
{
    public interface ITasksService
    {
        Task<Guid> AddNewTask(_Task task);
        Task<_Task> GetTask(Guid IdTask);
        Task<List<_Task>> GetTasksForUser(Guid IdUser, Guid IdDepartment, int page);
    }
}