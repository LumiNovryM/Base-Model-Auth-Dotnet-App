using Base_Model_Auth_Dotnet.Models.DTOs.Requests;
using Base_Model_Auth_Dotnet.Models.Entities;
using Base_Model_Auth_Dotnet.Models.Responses;
using Base_Model_Auth_Dotnet.Services.Interfaces;

namespace Base_Model_Auth_Dotnet.Services
{
    public class AuthService : IAuthService
    {
        // temporary fake database
        private static List<User> users = new();

        public BaseResponse<object> Register(RegisterRequest request)
        {
            // VALIDATION START

            if (string.IsNullOrWhiteSpace(request.Username))
            {
                return BaseResponse<object>.ErrorResponse("Username tidak boleh kosong");
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return BaseResponse<object>.ErrorResponse("Password tidak boleh kosong");
            }

            if (request.Password.Length < 8)
            {
                return BaseResponse<object>.ErrorResponse("Password harus minimal 8 karakter");
            }

            if (!request.Password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return BaseResponse<object>.ErrorResponse("Password harus mengandung minimal 1 simbol");
            }

            // VALIDATION END

            var existingUser = users.FirstOrDefault(x => x.Username == request.Username);

            if (existingUser != null)
            {
                return BaseResponse<object>.ErrorResponse("Username already registered");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = request.Password
            };

            users.Add(user);

            return BaseResponse<object>.SuccessResponse(
                new
                {
                    user.Id,
                    user.Username
                },
                "Register success"
            );
        }
    }
}