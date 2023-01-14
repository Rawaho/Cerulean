namespace Cerulean.Network.API.Model
{
    public class AuthoriseAccountResponse
    {
        public enum ErrorCode
        {
            None,
            DatabaseError,
            InvalidCredentials,
            EmailNotVerified,
            ServiceError,
        }

        public ErrorCode Error { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
