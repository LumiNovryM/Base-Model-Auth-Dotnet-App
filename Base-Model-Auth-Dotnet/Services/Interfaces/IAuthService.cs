using Base_Model_Auth_Dotnet.Models.DTOs.Requests;
using Base_Model_Auth_Dotnet.Models.Responses;

namespace Base_Model_Auth_Dotnet.Services.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse<object>> Register(RegisterRequest request);
    }
}