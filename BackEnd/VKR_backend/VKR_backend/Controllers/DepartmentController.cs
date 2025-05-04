using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VKR_backend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Boss")]
    public class DepartmentController: ControllerBase
    {
        
    }
}
