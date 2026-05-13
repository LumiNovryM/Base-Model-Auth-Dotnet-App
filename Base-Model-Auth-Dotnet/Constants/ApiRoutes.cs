namespace Base_Model_Auth_Dotnet.Constants
{
    public static class ApiRoutes
    {
        public const string Base = "api/v1";

        // Hello Endpoint For Testing Sample
        public static class Hello
        {
            public const string Root = Base + "/hello";
        }

        // Auth Endpoints
        public static class Auth
        {
            public const string Root = Base + "/auth";
            public const string Register = Root + "/register";
            public const string Login = Root + "/login";
        }
    }
}