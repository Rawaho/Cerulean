namespace Cerulean.Network.API.Model
{
    public class AuthoriseCharacterResponse
    {
        public enum ErrorCode
        {
            None,
            DatabaseError,
            InvalidCharacterId,
            ServiceError
        }

        public ErrorCode Error { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
