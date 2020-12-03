using System.Threading.Tasks;
using AspNetIdentity.Api.Interfaces;
using AspNetIdentity.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AspNetIdentity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if(result.IsSuccess) return Ok(result);
                return BadRequest(result);
            }
            return BadRequest("Not valid");
        } 
    }
}