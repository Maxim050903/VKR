using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace VKR_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IUserServices _userServices;

        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [Route("/LogIn")]
        public async Task<ActionResult> LogIn(string IndividualNumber,string password)
        {   
            var token = await _userServices.LogIn(IndividualNumber, password);

            HttpContext.Response.Cookies.Append("token", token);

            return Ok();
        }
    }
}
