using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.RequestEntities;
using Domain.Core.ResponseEntities;

namespace SignLibrary.Lesson_3
{
    public interface IAuthManager
    {
        Task<RegistrationResponse> Login(UserLoginRequest user);
        Task<RegistrationResponse> Register(UserRegistrationRequest user);
    }
}
