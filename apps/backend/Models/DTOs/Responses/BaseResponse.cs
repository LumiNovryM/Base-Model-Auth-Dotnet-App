namespace Base_Model_Auth_Dotnet.Models.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public int StatusCode { get; set; }

        public static BaseResponse<T> SuccessResponse(T data, string message = "Success")
        {
            return new BaseResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = 200
            };
        }

        public static BaseResponse<T> ErrorResponse(string message, int statusCode = 400)
        {
            return new BaseResponse<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = statusCode
            };
        }
    }
}