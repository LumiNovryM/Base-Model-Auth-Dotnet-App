using Base_Model_Auth_Dotnet.Data;
using Base_Model_Auth_Dotnet.Models.DTOs.Requests;
using Base_Model_Auth_Dotnet.Models.Entities;
using Base_Model_Auth_Dotnet.Models.Responses;
using Base_Model_Auth_Dotnet.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Base_Model_Auth_Dotnet.Services
{
    public class AuthService : IAuthService
    {
        // Dependency Injection of AppDbContext
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<object>> Register(RegisterRequest request)
        {
            // Validation Register Logic Start Here

            // Username & Password Empty Validation
            if (string.IsNullOrWhiteSpace(request.Username) && string.IsNullOrWhiteSpace(request.Password))
            {
                return BaseResponse<object>.ErrorResponse("Username dan Password tidak boleh kosong", 400);
            }

            // Username Empty Validation
            if (string.IsNullOrWhiteSpace(request.Username))
            {
                return BaseResponse<object>.ErrorResponse("Username tidak boleh kosong", 400);
            }

            // Password Empty Validation
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return BaseResponse<object>.ErrorResponse("Password tidak boleh kosong", 400);
            }

            // Password Length Validation
            if (request.Password.Length < 8)
            {
                return BaseResponse<object>.ErrorResponse("Password harus minimal 8 karakter", 400);
            }

            // Password Must Contain At Least 1 Symbol Validation
            if (!request.Password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return BaseResponse<object>.ErrorResponse("Password harus mengandung minimal 1 simbol", 400);
            }

            // Check User From Database
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == request.Username);

            if (existingUser != null)
            {
                return BaseResponse<object>.ErrorResponse("Username sudah terdaftar", 409);
            }

            // Validation Register Logic End Here

            // Hashing Password Before Save To Database
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = hashedPassword
            };

            // SAVE TO DATABASE
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return BaseResponse<object>.SuccessResponse(
                new
                {
                    user.Id,
                    user.Username
                },
                "Register berhasil"
            );
        }
    }
}