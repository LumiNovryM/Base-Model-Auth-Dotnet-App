using Base_Model_Auth_Dotnet.Models.DTOs.Requests;
using Base_Model_Auth_Dotnet.Models.DTOs.Responses;
using Base_Model_Auth_Dotnet.Models.Entities;
using Base_Model_Auth_Dotnet.Services.Interfaces;

namespace Base_Model_Auth_Dotnet.Services
{
    public class AuthService : IAuthService
    {
        // temporary fake database
        private static List<User> users = new();

        public RegisterResponse Register(RegisterRequest request)
        {

            // VALIDATION START
            // Empty Username & Password
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = "Username & Password tidak boleh kosong"
                };
            }


            // Empty Username
            if (string.IsNullOrWhiteSpace(request.Username))
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = "Username tidak boleh kosong"
                };
            }

            // Empty Password
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = "Password tidak boleh kosong"
                };
            }

            // Validasi Minimal 8 Karakter
            if (request.Password.Length < 8)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = "Password harus memiliki minimal 8 karakter"
                };
            }

            // Validasi Minimal 1 Karakter Khusus (Symbol atau Punctuation)
            if (!request.Password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = "Password harus mengandung minimal 1 karakter khusus (simbol)"
                };
            }
            // VALIDATION END

            var existingUser = users.FirstOrDefault(x =>
     x.Username == request.Username);

            if (existingUser != null)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = "Username already registered"
                };
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = request.Password
            };

            users.Add(user);

            return new RegisterResponse
            {
                Success = true,
                Message = "Register success"
            };
        }
    }
}