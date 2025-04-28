using Api.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace VKR_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController:ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IAuthService _authService;

        public AuthController(IUserServices userServices, IAuthService authService)
        {
            _userServices = userServices;
            _authService = authService;
        }

        [HttpGet]
        [Route("/LogIn")]
        public async Task<ActionResult> LogIn(string IndividualNumber,string password)
        {   
            var token = await _authService.LogIn(IndividualNumber, password);

            HttpContext.Response.Cookies.Append("token", token);

            return Ok();
        }
    }
}
