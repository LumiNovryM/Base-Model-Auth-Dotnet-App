using Base_Model_Auth_Dotnet.Constants;
using Base_Model_Auth_Dotnet.Models.DTOs.Requests;
using Base_Model_Auth_Dotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Base_Model_Auth_Dotnet.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Auth.Register)]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register-exec")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var result = _authService.Register(request);

            if (!result.Success)
            {
                return BadRequest(result); 
            }

            return Ok(result);
        }
    }
}