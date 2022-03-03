using System.IdentityModel.Tokens.Jwt;
using Domain.Core.RequestEntities;
using Domain.Core.ResponseEntities;
using System.Security.Claims;
using System.Text;
using Domain.Core.Entities.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace SignLibrary.Lesson_3
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        public AuthManager(UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }
        public async Task<RegistrationResponse> Login(UserLoginRequest user)
        {

            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser == null)
            {
                return new RegistrationResponse()
                {
                    Errors = new List<string>()
                        {
                            "Error!!!"
                        },
                    Success = false
                };

            }

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

            if (!isCorrect)
            {
                return new RegistrationResponse()
                {
                    Errors = new List<string>()
                        {
                            "Error!!!"
                        },
                    Success = false
                };
            }

            var jwtToken = GenerateJwtToken.Generate(existingUser, _jwtConfig);

            return new RegistrationResponse()
            {
                Success = true,
                Token = jwtToken
            };

        }
        
        public async Task<RegistrationResponse> Register( UserRegistrationRequest user)
        {
            
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if (existingUser != null)
                {
                    return new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Email already in use"

                        },
                        Success = false


                    };
                }

                var newUser = new IdentityUser() { Email = user.Email, UserName = user.UserName };
                var isCreated = await _userManager.CreateAsync(newUser, user.Password);
                if (isCreated.Succeeded)
                {
                    var jwtToken = GenerateJwtToken.Generate(newUser, _jwtConfig);
                    return new RegistrationResponse()
                    {
                        Success = true,
                        Token = jwtToken
                    };
                }
                else
                {
                    return new RegistrationResponse()
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false

                    };
                }
                
        }


      
    }
}