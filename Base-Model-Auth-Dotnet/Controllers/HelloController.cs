using Base_Model_Auth_Dotnet.Constants;
using Base_Model_Auth_Dotnet.Models.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Base_Model_Auth_Dotnet.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Hello.Root)]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var response = new HelloResponse
            {
                Message = "Hello World"
            };

            return Ok(response);
        }
    }
}