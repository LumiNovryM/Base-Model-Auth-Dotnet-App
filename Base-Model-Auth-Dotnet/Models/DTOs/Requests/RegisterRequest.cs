namespace Base_Model_Auth_Dotnet.Models.DTOs.Requests
{
    public class RegisterRequest
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}