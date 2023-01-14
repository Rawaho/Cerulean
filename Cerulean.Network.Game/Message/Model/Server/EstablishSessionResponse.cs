using Cerulean.Network.Game.Message.Model.Shared;
using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Server
{
    [Message(MessageOpcode.EstablishSessionResponse, MessageDirection.Server)]
    [ProtoContract]
    public class EstablishSessionResponse
    {
        public enum ErrorCode
        {
            Undefined,
            ApplicationInvalid,
            ApplicationOutOfDate,
            AuthenticationTokenInvalid,
            AccountBanned,
            MaintenanceActive,
            AccountInUse,
            CharacterInUse
        }

        [ProtoMember(1)]
        public bool Success { get; set; }

        [ProtoMember(2)]
        public ErrorCode Error { get; set; }

        [ProtoMember(3)]
        public long ClientTimestamp { get; set; }

        [ProtoMember(4)]
        public long MasterTimestamp { get; set; }

        [ProtoMember(5)]
        public AccountInfo Account { get; set; }

        [ProtoMember(6)]
        public CharacterInfo Character { get; set; }
    }
}
