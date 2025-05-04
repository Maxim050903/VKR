using Core.Models;

namespace Api.Interfaces.Services
{
    public interface IDepartmentServices
    {
        Task<Guid> AddMembers(Guid IdDepartment, List<Guid> IdMembers);
        Task<Guid> CreateDepartment(string Name, Guid IdBoss, List<Guid> IdMembers);
        Task<Guid> DeleteDepartment(Guid Id);
        Task<Guid> UpdateDepartment(Guid Id, string Name, Guid IdBoss, List<Guid> IdMembers);
        Task<List<Department>> GetAllDepartment(int page);
        Task<Department> GetDepartmentByBossId(Guid idBoss);
        Task<Department> GetDepartmentById(Guid id);
    }
}