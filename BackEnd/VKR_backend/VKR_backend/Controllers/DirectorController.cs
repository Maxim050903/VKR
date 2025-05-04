using Api.Interfaces.Services;
using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using VKR_backend.DTOs;

namespace VKR_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorController:ControllerBase
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly ITasksService _tasksService;

        public DirectorController(ITasksService tasksService,
            IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
            _tasksService = tasksService;
        }

        [Route("/GetAllDepartment")]
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAllDepartment(int page)
        {
            var departments = _departmentServices.GetAllDepartment(page);

            return Ok(departments);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTaskForDepartmentBoss(TaskCreateRequest request)
        {
            var jwtReader = new JwtReader(HttpContext);

            var idBoss = jwtReader.TakeId();
                
            await _tasksService.CreateTask(request.Name, idBoss,
                request.IdAgregate, request.tasktype, request.IdForHim);

            return Ok();
        }
    }
}
