using Api.Interfaces.Services;
using Api.Services;
using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VKR_backend.DTOs;

namespace VKR_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BossController : ControllerBase
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IUserServices _userServices;

        public BossController(IDepartmentServices departmentServices,IUserServices userServices)
        {
            _departmentServices = departmentServices;
            _userServices = userServices;
        }

        [HttpGet]
        [Route("/GetDepartment")]
        public async Task<ActionResult<List<User>>> GetUsersInDepartment()
        {
            var jwtReader = new JwtReader(HttpContext);

            var IdBoss = jwtReader.TakeId();

            var department = await _departmentServices.GetDepartmentByBossId(IdBoss);

            var users = await _userServices.GetAllUsersInDepartment(department.Members);
            
            return Ok(department);
        }
    }
}
