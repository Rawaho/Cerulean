namespace Cerulean.Network.API.Model
{
    public class AuthoriseAccountRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Expires { get; set; }
    }
}
