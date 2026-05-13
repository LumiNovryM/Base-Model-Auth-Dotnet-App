using Base_Model_Auth_Dotnet.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Base_Model_Auth_Dotnet.Extensions
{
    public static class BaseResponseExtensions
    {
        public static IActionResult ToActionResult<T>(this BaseResponse<T> response)
        {
            return response.StatusCode switch
            {
                200 => new OkObjectResult(response),
                201 => new ObjectResult(response) { StatusCode = 201 },
                400 => new BadRequestObjectResult(response),
                401 => new UnauthorizedObjectResult(response),
                404 => new NotFoundObjectResult(response),
                409 => new ConflictObjectResult(response),
                _ => new ObjectResult(response) { StatusCode = response.StatusCode }
            };
        }
    }
}