using Base_Model_Auth_Dotnet.Constants;
using Base_Model_Auth_Dotnet.Extensions;
using Base_Model_Auth_Dotnet.Models.DTOs.Requests;
using Base_Model_Auth_Dotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Base_Model_Auth_Dotnet.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Auth.Root)]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // Register Method
        [HttpPost("register-exec")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.Register(request);

            return result.ToActionResult();
        }

        // Login Method
        [HttpPost("login-exec")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.Login(request);

            return result.ToActionResult();
        }

        // GetProfile Method (Just for testing JWT)
        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok(new
            {
                Message = "Authorized access success",
                User = User.Identity?.Name
            });
        }
    }
}