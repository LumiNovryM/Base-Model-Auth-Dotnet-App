using Base_Model_Auth_Dotnet.Models.DTOs.Requests;
using Base_Model_Auth_Dotnet.Models.Responses;

namespace Base_Model_Auth_Dotnet.Services.Interfaces
{
    public interface IAuthService
    {
        // Register 
        Task<BaseResponse<object>> Register(RegisterRequest request);

        // Login
        Task<BaseResponse<object>> Login(LoginRequest request);
    }
}