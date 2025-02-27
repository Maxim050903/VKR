using Core.Models;

namespace DataBase.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Guid> AddMembers(Guid IdDepartment, List<Guid> UsersId);
        Task<Guid> CreateDepartment(Department department);
        Task<Guid> DeleteDepartment(Guid id);
        Task<Guid> UpdateDepartment(Department department);
        Task<bool> FindById(Guid id);
    }
}