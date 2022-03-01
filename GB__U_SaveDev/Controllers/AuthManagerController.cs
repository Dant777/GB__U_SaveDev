using Domain.Core.Entities.Configuration;
using Domain.Core.RequestEntities;
using Domain.Core.ResponseEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GB__U_SaveDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagerController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthManagerController(
            UserManager<IdentityUser> userManager, 
            IOptionsMonitor<JwtConfig>  optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegistrationRequest  user)
        {
            if (ModelState.IsValid)
            {
                    

            }

            return BadRequest(new RegistrationResponse()
            {
                Erorrs = new List<string>()
                {
                    "Error registration"

                }

            });
        }
    }
}
