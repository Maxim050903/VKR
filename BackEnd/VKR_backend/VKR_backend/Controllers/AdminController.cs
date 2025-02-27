using Api.Interfaces;
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

        public AdminController(IUserServices userServices)
        {  
            _userServices = userServices; 
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] UserCreateResponse user)
        {
            try
            {
                var number = new UInt32();
                string IndividualNumber = number.ToString(); 
                await _userServices.Register(IndividualNumber,user.Name, user.Surname, user.Otchestvo, user.Password, user.IdDepartment, user.IdBoss, user.Role);
                return Ok();            
            }
            catch
            {
                return BadRequest("Can't create user");
            }
        }

        [Route("/Delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userServices.DeleteUser(id);
                return Ok();
            }
            catch
            {
                return BadRequest("takogo nelzia udalit");
            }
        }

        [Route("/Update/{id}/{IndividualNumber}")]
        [HttpPut]
        public async Task<ActionResult> UpdateUser(Guid id, string IndividualNumber)
        {
            try
            {
                await _userServices.UpdateUser(id, IndividualNumber);
                return Ok();
            }
            catch 
            {
                return BadRequest("OshibkaObnovlenia");
            }
        }

    }
}
