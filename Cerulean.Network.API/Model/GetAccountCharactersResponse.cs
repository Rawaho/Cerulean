using Cerulean.Game.Abstract.Entity;
using Cerulean.Network.API.Shared;

namespace Cerulean.Network.API.Model
{
    public class GetAccountCharactersResponse
    {
        public enum ErrorCode
        {
            None,
            DatabaseError,
            ServiceError,
        }

        public ErrorCode Error { get; set; }
        public List<Character> Characters { get; set; }
        public Dictionary<long, Dictionary<CharacterAppearancePart, long>> Appearances { get; set; }
    }
}
