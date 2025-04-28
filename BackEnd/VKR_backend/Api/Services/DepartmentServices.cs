using Api.Interfaces.Repositories;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class DepartmentServices
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
            //Department department = new Department()
            //{
            //    Id = new Guid(),
            //    Name = Name,
            //    IdBoss = IdBoss,
            //    Members = IdMembers
            //};

            var department = Department.CreateDepartment(Name, IdBoss, IdMembers);

            var result = await _departmentRepository.CreateDepartment(department.department);

            return result;
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
            //Department department = new Department()
            //{
            //    Id = Id,
            //    Name = Name,
            //    IdBoss = IdBoss,
            //    Members = IdMembers
            //};

            var department = Department.CreateDepartment(Name, IdBoss, IdMembers);

            if (await _departmentRepository.FindById(Id))
            {
                return await _departmentRepository.UpdateDepartment(department.department);
            }
            else
            {
                throw new Exception("UnFind Department");
            }
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
