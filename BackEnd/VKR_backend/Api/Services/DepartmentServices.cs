using Api.Interfaces.Repositories;
using Api.Interfaces.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository
            , IUserRepository userRepository)
        {
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateDepartment(string Name, Guid IdBoss, List<Guid> IdMembers)
        {
            var id = Guid.NewGuid(); 

            var department = Department.CreateDepartment(id,Name, IdBoss, IdMembers);

            if (department.error == "None")
            {
                return await _departmentRepository.CreateDepartment(department.department);
            }
            else
            {
                throw new Exception(department.error);
            }
        }

        public async Task<Guid> DeleteDepartment(Guid Id)
        {
            if (await _departmentRepository.FindById(Id))
            {
                return await _departmentRepository.DeleteDepartment(Id);
            }
            else
            {
                throw new Exception("AnFind department");
            }
        }

        public async Task<Guid> UpdateDepartment(Guid Id, string Name, Guid IdBoss, List<Guid> IdMembers)
        {
            var department = Department.CreateDepartment(Id,Name, IdBoss, IdMembers);

            if (await _departmentRepository.FindById(Id))
            {
                return await _departmentRepository.UpdateDepartment(department.department);
            }
            else
            {
                throw new Exception("UnFind Department");
            }
        }

        public async Task<List<Department>> GetAllDepartment(int page)
        {
            return await _departmentRepository.GetAllDepartment(page);
        }

        public async Task<Department> GetDepartmentByBossId(Guid idBoss)
        {
            return await _departmentRepository.GetDepartment(idBoss,Guid.Empty);
        }

        public async Task<Department> GetDepartmentById(Guid id)
        {
            return await _departmentRepository.GetDepartment(Guid.Empty,id);
        }

        public async Task<Guid> AddMembers(Guid IdDepartment, List<Guid> IdMembers)
        {
            if (await _departmentRepository.FindById(IdDepartment))
            {
                return await _departmentRepository.AddMembers(IdDepartment, IdMembers);
            }
            else
            {
                throw new Exception("UnFind Department");
            }
        }
    }
}
