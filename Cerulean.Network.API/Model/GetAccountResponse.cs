using Cerulean.Network.API.Shared;

namespace Cerulean.Network.API.Model
{
    public class GetAccountResponse
    {
        public enum ErrorCode
        {
            None,
            DatabaseError,
            NotFound,
            ServiceError,
        }

        public ErrorCode Error { get; set; }
        public Account Account { get; set; }
    }
}
