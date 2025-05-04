using Api.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VKR_backend.DTOs;
using Core.Models;
using System.Runtime.CompilerServices;
using System.IdentityModel.Tokens.Jwt;
using Infrastructure;
using static Core.Types.Types;
using System.Xml.Linq;

namespace VKR_backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ITasksService _tasksService;
        private readonly IRequestService _requestService;
        private readonly ICertificatesService _certificatesService;
        private readonly IResumeService _resumeService;

        public UserController(IUserServices userServices,
            ITasksService tasksService, IRequestService requestService,
            ICertificatesService certificatesService, IResumeService resumeService)

        {
            _userServices = userServices;
            _tasksService = tasksService;
            _requestService = requestService;
            _certificatesService = certificatesService;
            _resumeService = resumeService;
        }

        [HttpGet]
        [Route("/getTasks")]
        [Authorize]
        public async Task<ActionResult<List<_Task>>> GetUserTasks(int page)
        {

            var jwtReader = new JwtReader(HttpContext);

            var idUser = jwtReader.TakeId();

            var user = _userServices.GetUser(idUser);

            var IdDepartment = user.Result.IdDepartment;

            var TaskList = await _tasksService.GetTasksForUser(idUser, IdDepartment, page);

            return Ok(TaskList);
        }

        [HttpPost]
        [Route("/CreateRequest")]
        [Authorize]
        public async Task<ActionResult> CreateRequest([FromBody] RequestCreateRequest requestZap)
        {
            var jwtReader = new JwtReader(HttpContext);

            var idUser = jwtReader.TakeId();

            var request = _requestService.CreateRequest(idUser, requestZap.RequestType, requestZap.Description);
            return Ok();
        }

        [HttpGet]
        [Route("/GetCertificate")]
        [Authorize]
        public async Task<ActionResult<Resume>> GetResume()
        {
            var jwtReader = new JwtReader(HttpContext);

            var idUser = jwtReader.TakeId();

            var resume = await _resumeService.GetUserResume(idUser);

            return Ok(resume);
        }

        [HttpGet]
        [Route("/GetUserCertificate")]
        [Authorize]
        public async Task<ActionResult<List<Certificate>>> GetCertificate()
        {
            var jwtReader = new JwtReader(HttpContext);

            var idUser = jwtReader.TakeId();

            var resume = await _resumeService.GetUserResume(idUser);

            var Certificates = await _certificatesService.GetCertificates(resume.IdSertificates);

            return Ok(Certificates);
        }

        [HttpGet]
        [Route("/GetUserInfo")]
        [Authorize]
        public async Task<ActionResult<UserResponse>> GetUser()
        {
            var jwtReader = new JwtReader(HttpContext);

            var idUser = jwtReader.TakeId();

            var user = await _userServices.GetUser(idUser);

            var response = new UserResponse
            (
                user.Name,
                user.Surname,
                user.Otchestvo,
                user.IdDepartment,
                user.IdDepartment,
                user.Role,
                user.Mail,
                user.Telegram,
                user.Photo
            );

            return Ok(response);
        }
    }
}
