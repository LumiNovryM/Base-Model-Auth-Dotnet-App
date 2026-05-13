using Base_Model_Auth_Dotnet.Models.DTOs.Requests;
using Base_Model_Auth_Dotnet.Models.DTOs.Responses;

namespace Base_Model_Auth_Dotnet.Services.Interfaces
{
    public interface IAuthService
    {
        RegisterResponse Register(RegisterRequest request);
    }
}