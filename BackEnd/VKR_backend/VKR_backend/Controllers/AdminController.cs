using Api.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using VKR_backend.DTOs;

namespace VKR_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController:ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IRequestService _requestService;

        public AdminController(IUserServices userServices,IRequestService requestService)
        {  
            _userServices = userServices;
            _requestService = requestService;
        }

        [Route("/Register")]
        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] UserCreateRequest user)
        {
            try
            {
                var number = new UInt32();
                var Id = Guid.NewGuid();
                string IndividualNumber = number.ToString(); 
                await _userServices.Register(Id,user.IndividualNumber,user.Name, user.Surname, user.Otchestvo, user.Password, user.IdDepartment, user.IdBoss, user.Role);
                return Ok();            
            }
            catch
            {
                return BadRequest("Can't create user");
            }
        }

        [Route("/AcceptRequest")]
        [HttpPost]
        public async Task<ActionResult> AcceptRequest([FromBody] RequestCreateRequest request)
        {
            bool isWork = true;
            switch ((int)request.RequestType)
            {
                case 1:
                    {
                        
                        break;
                    }
                case 2:
                    {
                        await _userServices.DeleteUser(request.id);
                        break;
                    }
                case 4:
                    {
                        
                        break;
                    }
                default:
                    {
                        isWork = false;
                        break;
                    }
            }
            if (isWork)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Неизвестный запрос");
            }
        }

        [Route("/CancellationRequest")]
        [HttpDelete]
        public async Task<ActionResult<Guid>> CancellationRequest(Guid id)
        {
            return Ok(await _requestService.DeleteRequest(id));
        }
    }
}
