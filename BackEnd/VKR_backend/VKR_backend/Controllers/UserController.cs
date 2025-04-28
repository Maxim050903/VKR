using Api.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VKR_backend.DTOs;

namespace VKR_backend.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class UserController: ControllerBase 
    {
        private readonly IUserServices _userServices;
        private readonly ITasksService _tasksService;
        //private readonly IRequestService _requestService;

        public UserController(IUserServices userServices,
            ITasksService tasksService)
        {
            _userServices = userServices;
            _tasksService = tasksService;
        }

        [HttpGet]
        [Route("/getTasks")]
        public async Task<ActionResult> GetUserTasks(Guid idUser, int page)
        {
            var user = _userServices.GetUser(idUser);

            var IdDepartment = user.Result.IdDepartment;

            var TaskList = _tasksService.GetTasksForUser(idUser, IdDepartment ,page);
            
            return Ok();
        }

        [HttpPost]
        [Route("/CreateRequest")]
        [Authorize]
        public async Task<ActionResult> CreateRequest([FromBody] RequestCreateRequest request)
        {



            return Ok();
        }
    }
}
