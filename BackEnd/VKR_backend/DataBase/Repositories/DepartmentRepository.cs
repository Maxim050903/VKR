using Api.Interfaces.Repositories;
using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataBase.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly VKRDBContext _context;
        public DepartmentRepository(VKRDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateDepartment(Department department)
        {
            var DepartmmentEntity = new DepartmentEntity()
            {
                Id = department.Id,
                Name = department.Name,
                IdBoss = department.IdBoss,
                Members = department.Members
            };

            await _context.Departments.AddAsync(DepartmmentEntity);
            await _context.SaveChangesAsync();

            return department.Id;
        }

        public async Task<Guid> DeleteDepartment(Guid id)
        {
            await _context.Departments.Where(x => x.Id == id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> UpdateDepartment(Department department)
        {
            await _context.Departments
                .Where(x => x.Id == department.Id)
                .ExecuteUpdateAsync(dep => dep
                .SetProperty(d => d.Name, d => department.Name)
                .SetProperty(d => d.IdBoss, d => department.IdBoss)
                .SetProperty(d => d.Members, d => department.Members)
                );

            await _context.SaveChangesAsync();

            return department.Id;
        }

        public async Task<Guid> AddMembers(Guid IdDepartment, List<Guid> UsersId)
        {
            var Department = await _context.Departments.Where(x => x.Id == IdDepartment).FirstOrDefaultAsync();

            var members = Department.Members;

            members.AddRange(UsersId);

            await _context.Departments
                .Where(x => x.Id == IdDepartment)
                .ExecuteUpdateAsync(dep => dep
                .SetProperty(d => members, d => members));

            await _context.SaveChangesAsync();

            return Department.Id;
        }

        public async Task<bool> FindById(Guid id)
        {
            var department = await _context.Departments.Where(x =>  id == x.Id).FirstOrDefaultAsync();

            return department == null ? false : true;
        }
    }
}
