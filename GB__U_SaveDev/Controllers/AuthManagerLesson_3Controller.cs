using Domain.Core.RequestEntities;
using Domain.Core.ResponseEntities;
using Microsoft.AspNetCore.Mvc;
using SignLibrary.Lesson_3;

namespace GB__U_SaveDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagerLesson_3Controller : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthManagerLesson_3Controller(IAuthManager authManager)
        {
            _authManager = authManager;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var result = await _authManager.Login(user);
                return Ok(result);
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>()
                {
                    "Error!!!"
                },
                Success = false
            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest user)
        {
            if (ModelState.IsValid)
            {
                var result = await _authManager.Register(user);
                return Ok(result);
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>()
                {
                    "Error registration"

                },
                Success = false


            });
        }
    }
}
